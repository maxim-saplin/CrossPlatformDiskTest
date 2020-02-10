using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class L11n : L11nBase 
    {
        public string locale = Locales.en;
        public bool needInit = true;
        private readonly NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

        public L11n()
        {
            if (!App.Current.Properties.ContainsKey(nameof(_Locale)) || !Locales.IsValid(App.Current.Properties[nameof(_Locale)].ToString()))
            {
                var sysLocaleService = DependencyService.Get<IGetSystemLocale>();
                var sysLocale = "";

                if (sysLocaleService != null)
                {
                    sysLocale = sysLocaleService.GetLocale();
                }

                if (Locales.IsValid(sysLocale)) App.Current.Properties[nameof(_Locale)] = sysLocale;
                else App.Current.Properties[nameof(_Locale)] = Locales.en;
            }

            _Locale = App.Current.Properties[nameof(_Locale)].ToString();

            MinFreeSpaceInit();
        }

        private void MinFreeSpaceInit()
        {
            MinFreeSpaceGb = 1.5f;
            float i;
            if (float.TryParse(ViewModelContainer.OptionsViewModel.FileSizeGb, NumberStyles.Any, nfi, out i))
                MinFreeSpaceGb = i + 0.5f;

            ViewModelContainer.OptionsViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(OptionsViewModel.FileSizeGb))
                {
                    if (float.TryParse(((OptionsViewModel)s).FileSizeGb, NumberStyles.Any, nfi, out i))
                        MinFreeSpaceGb = i + 0.5f;
                }
            };
        }

        public string _Locale
        {
            get
            {
                return locale;
            }
            set
            {
                if ((value != locale || needInit) && Locales.IsValid(value))
                {
                    needInit = false;
                    locale = value;
                    App.Current.Properties[nameof(_Locale)] = value;
                    App.Current.SavePropertiesAsync();

                    L11nBase.Culture = new System.Globalization.CultureInfo(locale);
                    Thread.CurrentThread.CurrentCulture = L11nBase.Culture;
                    Thread.CurrentThread.CurrentUICulture = L11nBase.Culture;

                    var properties = typeof(L11nBase).GetProperties().Where(p => p.PropertyType == typeof(string));

                    OnOff = new KeyValue[] { new KeyValue { Key = "true", Value = On }, new KeyValue { Key = "false", Value = Off} };

                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(_LocaleIcon));
                    foreach (var p in properties)
                    {
                        RaisePropertyChanged(p.Name);
                    }
                }
            }
        }

        public ImageSource _LocaleIcon
        {
            get
            {
                var resourceId = string.Format("Saplin.CPDT.UICore.Img.{0}.png", _Locale);
        
                if (Device.RuntimePlatform == Device.WPF)
                {
                    var assembly = GetType().GetTypeInfo().Assembly;
                    ImageSource imageSource = null;

                    var resourceStream = assembly.GetManifestResourceStream(resourceId);

                    if (resourceStream == null)
                        return null;
                    imageSource = ImageSource.FromStream(() => resourceStream);

                    return imageSource;
                }
                else return ImageSource.FromResource(resourceId, GetType().GetTypeInfo().Assembly);
            }
        }

        private ICommand _nextLocale;

        public ICommand _NextLocale
        {
            get
            {
                if (_nextLocale == null)
                    _nextLocale = new Command(() =>
                        {
                            switch(_Locale)
                            {
                                case Locales.en:
                                    _Locale = Locales.ru;
                                    break;
                                case Locales.ru:
                                    _Locale = Locales.en;
                                    break;
                                case Locales.fr:
                                    _Locale = Locales.zh;
                                    break;
                                case Locales.zh:
                                    _Locale = Locales.en;
                                    break;
                            }
                        }
                    );

                return _nextLocale;
            }
        }

        public IEnumerable<KeyValue> onOff = new KeyValue[] { new KeyValue { Key="true", Value="(On)" }, new KeyValue { Key = "false", Value = "(Off)" } };

        public IEnumerable<KeyValue> OnOff
        {
            get
            {
                return onOff;
            }
            set
            {
                if (onOff != value)
                {
                    onOff = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string this[string key]
        {
            get
            {
                if (key == nameof(CantTestNotEnough)) return CantTestNotEnough;

                return ResourceManager.GetString(key, resourceCulture);
            }
        }

        public string CantTestNotEnough
        {
            get
            {
                return string.Format(ResourceManager.GetString("CantTestNotEnough", resourceCulture), MinFreeSpaceGb);
            }
        }

        private float MinFreeSpaceGb
        {
            get;
            set;
        }
    }
}
