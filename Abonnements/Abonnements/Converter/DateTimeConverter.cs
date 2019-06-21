using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Abonnements.Converter
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
            {
                throw new InvalidOperationException("La cible doit être une date");
            }

            var date = (DateTime)value;
            bool converToLocal = (string)parameter == "ToLocal";

            var result = converToLocal
                            ? date.ToLocalTime().ToString("dd/MM/yyyy")
                            : date.ToString("dd/MM/yyyy");
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
