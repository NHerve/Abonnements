using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Validations
{
    public class CardYearRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            int year = 2000 + Convert.ToInt32(str);
            int yearNow = DateTime.Now.Year;
            int diffYear = year - yearNow;
            return diffYear >= 0 && diffYear <= 5;
        }
    }
}
