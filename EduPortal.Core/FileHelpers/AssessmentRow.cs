using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace EduPortal.Core.FileHelpers
{
    [DelimitedRecord(",")]
    public class AssessmentRow
    {
        public AssessmentRow()
        {
            _scores = new decimal[] { };
        }

        public string _studentAdmissionNo;

        [FieldArrayLength(1, 10)]
        public decimal[] _scores;
    }
}