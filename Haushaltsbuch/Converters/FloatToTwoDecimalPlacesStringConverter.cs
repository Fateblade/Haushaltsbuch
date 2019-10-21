using System;
using System.Globalization;
using System.Windows.Data;

namespace Fateblade.Haushaltsbuch.UI.Haushaltsbuch.Converters
{
    public class FloatToTwoDecimalPlacesStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return "No Value";
            }
            else if (value is float f)
            {
                return f.ToString("F", CultureInfo.CurrentCulture);
            }

            throw new ArgumentException($"value of type '{value.GetType()}' is not supported");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("TwoWay conversion is not supported by this converter");
            //if need arises create a new one that uses Math.Round instead of just shortening it via string formatting and name it accordingly
        }
    }
}
