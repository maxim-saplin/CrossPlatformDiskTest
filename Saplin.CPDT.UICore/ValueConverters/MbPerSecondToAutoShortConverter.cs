using Saplin.CPDT.UICore.ViewModels;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public class MbPerSecondToAutoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = System.Convert.ToDouble(value);
            var s = "{0:0.00}";

            if (v < 1) s = string.Format(s, v*1024);
            else if (v < 1000) s = string.Format(s, v); // 999 is 3 cahrs, 1000 is 4, 0.99 is 3 chars
            else s = string.Format(s, v / 1024);

            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}