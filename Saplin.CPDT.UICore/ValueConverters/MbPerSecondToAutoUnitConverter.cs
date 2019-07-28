using Saplin.CPDT.UICore.ViewModels;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public class MbPerSecondToAutoUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = System.Convert.ToDouble(value);

            if (v < 1) return ViewModelContainer.L11n.kbps;
            else if (v < 1000) return ViewModelContainer.L11n.mbps;
            else return ViewModelContainer.L11n.gbps;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}