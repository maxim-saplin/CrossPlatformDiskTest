namespace Saplin.CPDT.UICore.Localization
{
    public static class Locales
    {
        public const string en = "en";
        public const string ru = "ru";
        public const string fr = "fr";
        public const string zh = "zh";

        public static bool IsValid(string locale)
        {
            if (locale == en) return true;
            if (locale == ru) return true;
            if (locale == fr) return true;
            if (locale == zh) return true;

            return false;
        }
    };
}