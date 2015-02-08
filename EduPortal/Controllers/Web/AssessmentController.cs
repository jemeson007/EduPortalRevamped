using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduPortal.Core.Entity;
using EduPortal.Client;
using System.IO;
using EduPortal.Core.FileHelpers;
using EduPortal.Core.ViewModels;

namespace EduPortal.Controllers.Web
{
    /// <summary>
    /// Controller to handle all user input related to student assessment
    /// </summary>
    public class AssessmentController : Controller
    {
        
        public ActionResult SpecifyComponents()
        {
            /*In the view, we need the following components
             * Dropdown with list of subjects
             * Multi-select which populates component values
             */
            return View();
        }

        // POST: /School/Create
        [HttpPost]
        public ActionResult SpecifyComponents(AssessmentComponentsView model)
        {
            if (ModelState.IsValid)
            {
                int nc = model.numberOfComponents;
                return RedirectToAction("DefineComponents", new { numComps = nc, s = model.subjectID });
            }
            return View();
        }

        public ActionResult DefineComponents(int numComps, long s)
        {
            /*In the view, we need the following components
             * Dropdown with list of subjects
             * Multi-select which populates component values
             */
            ViewBag.NumberofComponents = numComps;

            IList<SubjectAssessmentComponent> components = new List<SubjectAssessmentComponent>();
            var model = new AssessmentComponentsView();
            model.numberOfComponents = numComps;
            model.subjectID = s;

            for (int i = 0; i < numComps; i++)
            {
                components.Add(new SubjectAssessmentComponent());

            }

            model.theComponents = components;
            return View(model);
        }

        [HttpPost]
        public ActionResult DefineComponents(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var names = collection.GetValues("item.Name") as IList<string>;
                var descriptions = collection.GetValues("item.Description") as IList<string>;
                var weights = collection.GetValues("item.PercentageWeight").Select(x => decimal.Parse(x)).ToList();//.Cast<decimal>().ToList();

                var batch = new List<SubjectAssessmentComponent>();
                var subject = new SubjectClient().Get(long.Parse(collection["s"]));

                for (int i = 0; i < int.Parse(collection["nc"]); i++)
                {
                    batch.Add(
                        new SubjectAssessmentComponent()
                        {
                            Name = names[i],
                            PercentageWeight = weights[i],
                            Description = descriptions[i],
                            Subject = subject
                        }
                        );
                }
                client.SaveBatch(batch);
                return RedirectToAction("SpecifyComponents");
            }

            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        public ActionResult UploadAssessmentScores(UploadScoresView inputModel)
        {
            ViewBag.IsbtnOkVisible = true;
            var assessmentComponents = new AssessmentClient().GetAssessmentComponents(inputModel.SubjectID);

            if (assessmentComponents.Count > 0)
            {
                ViewBag.IsbtnOkVisible = false;
            }

            var model = new UploadScoresView();
            model.SubjectID = inputModel.SubjectID;
            model.AssessmentComponents = assessmentComponents;
            return View(model);
        }

        /// <summary>
        /// Action for uploading results spreadsheet; receive the following paramters from the view
        /// </summary>
        /// <param name="results">This holds the spreadsheet containing the results</param>
        /// <param name="chosen_components">This is a string containing a '|' separated list of IDs of selected assessment components</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadScores(HttpPostedFileBase results, string chosen_components)
        {
            var isFileSupplied = results != null && results.ContentLength != 0;
            string subjectID = "0";

            if (string.IsNullOrWhiteSpace(chosen_components) || !isFileSupplied)
            {
                //TO DO: Throw Validation Error; fields are required
            }

            else
            {
                var componentIDs = chosen_components.Trim('|').Split('|');
                string fileName = results.FileName;

                //Get selected subject assessment components
                var selectedComponents = new AssessmentClient().GetAssessmentComponents(componentIDs.ToList());

                //parse the file into a list of item; each item representing a row of the document (student, assessment component 1, assessment component 2, ...)
                FileHelperEngine engine = new FileHelperEngine(typeof(AssessmentRow));
                var textReader = new StreamReader(results.InputStream);

                IList<AssessmentRow> deserializedScores;

                using (textReader)
                {
                    deserializedScores = (AssessmentRow[])engine.ReadStream(textReader, Int32.MaxValue);// .ReadFile(@"..\Data\CustomersDelimited.txt");
                }

                //for each item in the list, generate assessment scores entities equal to the number of assessment components
                var assessmentScores = GenerateAssessmentScores(selectedComponents, deserializedScores);
                subjectID = assessmentScores.First().Assessment.Subject.ID.ToString();
                client.SaveScores(assessmentScores);
            }

            return RedirectToAction("ViewSubjectScores", new { ddlSubject = subjectID });
        }

        private IList<AssessmentScore> GenerateAssessmentScores(IList<SubjectAssessmentComponent> assessmentComponents, IList<AssessmentRow> scores)
        {
            //Get all students
            var studentsOfferingSubject = new StudentClient().GetSubjectStudents(assessmentComponents[0].Subject.ID);

            var studentNumbers = studentsOfferingSubject.Select(x => x.AdmissionNumber);

            var invalidAdmissionNumbers = new List<string>();

            var scoresToSave = new List<AssessmentScore>();

            foreach (var row in scores)
            {
                var admNum = row._studentAdmissionNo;
                var isNumberValid = studentNumbers.Contains(admNum);

                if (isNumberValid)
                {
                    //generate an assessment score for each item in list of scores for each student :-) this sucks though
                    for (int i = 0; i < assessmentComponents.Count; i++)
                    {
                        var newScore = new AssessmentScore()
                                              {
                                                  Score = row._scores[i],
                                                  Assessment = assessmentComponents[i],
                                                  Student = studentsOfferingSubject.Single(x => x.AdmissionNumber == row._studentAdmissionNo)
                                              };
                        scoresToSave.Add(newScore);
                    }



                    //create method that ensures that are no student-assessmentcompnent-score duplicates before saving a new studentscore
                    //also, check that the score is not higher than the percentage weight of the assessment component that it corresponds to
                }

                else
                {
                    invalidAdmissionNumbers.Add(admNum);
                }


            }

            //remove scores attached to invalid numbers from 
            //scores = scores.Where(x => !invalidAdmissionNumbers.Contains(x._studentAdmissionNo)).ToList();




            return scoresToSave;
        }

        public ActionResult ViewSubjectScores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewSubjectScores(string ddlSubject)
        {
            ViewScoresView model = new ViewScoresView();
            long subjectID = 0;

            if (long.TryParse(ddlSubject, out subjectID))
            {
                //Get all assessment components for subject
                //var components = client.GetAssessmentComponents(subjectID);
                //Get all scores tied to each of the assessment components
                var scores = client.GetSubjectScores(subjectID);
                //Group the scores per student
                //Generate assessment row for each student for each available component; order is row list should be order of assessment components hitherto retrieved
                model = GenerateScoresModel(scores);
            }

            return View(model);
        }

        private ViewScoresView GenerateScoresModel(IList<AssessmentScore> scores)
        {
            var result = new ViewScoresView();
            //get all assessment components for which scores exists
            IList<SubjectAssessmentComponent> assessmentComponents = scores.Select(x => x.Assessment).Distinct().ToList();

            #region Group scores into students
            var scoresByStudentGroup = scores.GroupBy(x => x.Student);

            foreach (var group in scoresByStudentGroup)
            {
                //sort assessment scores in ascending order of assessment components
                var newRow = new AssessmentRow()
                    {
                        _studentAdmissionNo = group.Key.AdmissionNumber
                    };

                #region Populate scores for each assessment components
                IList<decimal> discreteScores = new List<decimal>();
                foreach (var component in assessmentComponents)
                {
                    var matchingScore = group.FirstOrDefault(x => x.Assessment.Equals(component));
                    if (matchingScore != null)
                    {
                        discreteScores.Add(matchingScore.Score);
                    }
                    else
                    {
                        discreteScores.Add(0); //consider making this obvious that scores does not exist for this component
                    }
                }
                newRow._scores = discreteScores.ToArray();
                #endregion

                result.TheScores.Add(newRow);
            }
            #endregion

            result.AssessmentComponents = assessmentComponents;
            //group scores per student
            return result;
        }


    }
}
