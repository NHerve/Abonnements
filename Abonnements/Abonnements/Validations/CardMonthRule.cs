using System;
using System.Collections.Generic;
using System.Text;

namespace Abonnements.Validations
{
    public class CardMonthRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            int month = Convert.ToInt32(str);
            return month > 00 && month < 13;
        }
    }
}
