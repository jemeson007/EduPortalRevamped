using EduPortal.Core;
using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduPortal.DAO;

namespace EduPortal.Systems
{
    public class SubjectSystem: IBaseSystem<Subject>
    {
        public IList<Subject> GetWithAssessmentNotSpecified(string key)
        {
            return null;
            //return SubjectDAO.GetWithAssessmentNotSpecified(key);
        }
    }
}
