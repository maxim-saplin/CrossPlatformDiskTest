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
            if (l.StartsWith("pl", System.StringComparison.InvariantCultureIgnoreCase)) return Locales.pl;
            else if (l.StartsWith("fr", System.StringComparison.InvariantCultureIgnoreCase)) return Locales.fr;
            else if (l.Equals("zh-tw", System.StringComparison.InvariantCultureIgnoreCase)) return Locales.zht;
            else if (l.StartsWith("zh", System.StringComparison.InvariantCultureIgnoreCase)) return Locales.zh;

            return Locales.en;
        }
    }
}
