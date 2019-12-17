using Saplin.CPDT.UICore;
using Saplin.CPDT.UICore.Localization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Saplin.CPDT.Droid.GetSystemLocale))]
namespace Saplin.CPDT.Droid
{
    public class GetSystemLocale : IGetSystemLocale
    {

        public string GetLocale()
        {
            var l = Java.Util.Locale.Default.ToString();

            if (l.StartsWith("ru", System.StringComparison.InvariantCultureIgnoreCase)) return Locales.ru;
            else if (l.StartsWith("fr", System.StringComparison.InvariantCultureIgnoreCase)) return Locales.fr;

            return Locales.en;
        }
    }
}
