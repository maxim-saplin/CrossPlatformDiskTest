using Saplin.CPDT.UICore.ViewModels;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public class BytesToAutoUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = System.Convert.ToDouble(value);

            if (v < 1024) return ViewModelContainer.L11n.b;
            else if (v < 1024*1024) return ViewModelContainer.L11n.kb;
            else if (v < 1024 * 1024 * 1024) return ViewModelContainer.L11n.mb;
            return ViewModelContainer.L11n.gb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}