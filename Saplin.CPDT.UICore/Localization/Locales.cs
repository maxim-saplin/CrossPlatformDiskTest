namespace Saplin.CPDT.UICore.Localization
{
    public static class Locales
    {
        public const string en = "en";
        public const string ru = "ru";
        public const string pl = "pl";
        public const string fr = "fr";
        public const string zh = "zh";
        public const string zht = "zht"; // zh-tw

        // Adding new locale requres changing
        // 1. L11n.cs _NextLocale()
        // 2. and platform specific IGetSystemLocale implementations.
        // 3. Adding Locale icon
        // 4. Update Options.xaml
        // <x:Array Type = "{x:Type ctrl:KeyValue}" x:Key="LanguageKeys">
        //    <ctrl:KeyValue Key = "{x:Static l11n:Locales.en}" Value="(English)"/>
        //    <ctrl:KeyValue Key = "{x:Static l11n:Locales.ru}" Value="(Русский)"/>
        //    <ctrl:KeyValue Key = "{x:Static l11n:Locales.fr}" Value="(Français)"/>
        //    <ctrl:KeyValue Key = "{x:Static l11n:Locales.zh}" Value="(简体中文)"/>
        //    <ctrl:KeyValue Key = "{x:Static l11n:Locales.zht}" Value="(繁體中文)"/>
        //</x:Array>
        public static bool IsValid(string locale)
        {
            if (locale == en) return true;
            if (locale == ru) return true;
            if (locale == pl) return true;
            if (locale == fr) return true;
            if (locale == zh) return true;
            if (locale == zht) return true;

            return false;
        }
    };
}
