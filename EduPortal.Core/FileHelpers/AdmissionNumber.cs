using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace EduPortal.Core.FileHelpers
{
    [DelimitedRecord(",")]
    public class AdmissionNumber
    {
        public AdmissionNumber()
        {
        }

        [FieldConverter(typeof(AdmissionNumberFormatter))]
        public string _theNumber;
    }

    #region "  Admission Number Padder  "

    internal class AdmissionNumberFormatter : ConverterBase
    {
        public override object StringToField(string from)
        {
            return from.PadLeft(9, '0');
        }

        public override string FieldToString(object from)
        {
            var d = (string)from;
            return d.PadLeft(9, '0');
        }
    }

    #endregion
}