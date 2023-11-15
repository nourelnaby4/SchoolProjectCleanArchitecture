using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Common
{
    public class GenericLocalizer
    {
        public string getLanguageData(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower() == "ar")
                return textAr;

            return textEn;
        }
    }
}
