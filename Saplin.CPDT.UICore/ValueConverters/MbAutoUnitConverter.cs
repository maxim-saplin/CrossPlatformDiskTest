using System;
using System.Globalization;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public class MbToAutoUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = System.Convert.ToDouble(value);

            if (v < 1) return ViewModelContainer.L11n.kb;
            else if (v < 1024) return ViewModelContainer.L11n.mb;
            else return ViewModelContainer.L11n.gb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}