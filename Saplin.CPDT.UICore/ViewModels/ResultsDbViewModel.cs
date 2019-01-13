using Saplin.CPDT.UICore.Misc;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class ResultsDbViewModel : PopupViewModel
    {
        const string cpdt_web_url = @"https://maxim-saplin.github.io/cpdt_results/";
        //const string cpdt_web_url = @"https2://maxim-saplin2.github2.io/cpdt_results/";
        //const string cpdt_web_url = @"http://localhost:3000/";
        const string white_theme_param = "theme=white";
        const string locale_param = "lang=";
        const string inapp_param = "inapp=";
        const string yd_param = "yd=";
        const string buf_param = "buf=";
        const string cach_param = "cach=";
        const string i_param = "i=";
        const string cpu_param = "cpu=";
        const string ram_param = "ram=";
        const string mdl_param = "mdl=";
        const string close_param = "close";

        WebView webView;

        public void BindWebView(WebView webView)
        {
            this.webView = webView;
            webView.Navigating += Navigating;
            webView.Navigated += Navigated;
            webView.Source = Url;

            ViewModelContainer.L11n.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == nameof(L11n._Locale))
                {
                    webView.Source = Url;
                }
            };
        }

        private ICommand compare;
        public ICommand Compare
        {
            get
            {
                if (compare == null)
                    compare = new Command((object param) =>
                    {
                        var session = param as TestSession;
                        PreLoadComparison(session);
                        IsVisible = true;
                    });

                return compare;
            }
        }

        public void PreLoadComparison(TestSession session)
        {
            var url = GetCompareUrl(session);
            if ((webView.Source as UrlWebViewSource).Url != url) webView.Source = url;
        }

        private string GetParams()
        {
            var prms =  locale_param + ViewModelContainer.L11n._Locale +
                        (ViewModelContainer.OptionsViewModel.WhiteThemeBool ?
                            "&" + white_theme_param :
                            "") +
                         "&" + i_param + ViewModelContainer.OptionsViewModel.IID;

            var di = DependencyService.Get<IDeviceInfo>();

            if (di != null)
            {
                prms += "&" + cpu_param + Uri.EscapeUriString(di.GetCPU());
                prms += "&" + mdl_param + Uri.EscapeUriString(di.GetModelName());
                prms += "&" + ram_param + Uri.EscapeUriString(Math.Round(di.GetRamSizeGb(),1).ToString());
            }

            return prms;
        }

        private string TrimQueryString(string prms)
        {
            if (prms.Length > 1023)
            {
                return prms.Substring(0, 1023);
            }

            return prms;
        }

        public string Url
        {
            get
            {
                var prms = inapp_param + Device.RuntimePlatform + "&" + GetParams();

                prms = TrimQueryString(prms);

                return cpdt_web_url + "?" + prms;
            }
        }

        public string UrlNotInApp
        {
            get
            {
                var prms = GetParams();

                prms = TrimQueryString(prms);

                return cpdt_web_url + "?" + prms;
            }
        }

        [DataContract]
        internal class CompareJson
        {
            [DataMember] public double seqWrite; // MB/s
            [DataMember] public double seqRead; // MB/s
            [DataMember] public double randWrite; // MB/s
            [DataMember] public double randRead; // MB/s
            [DataMember] public double memCopy; // GB/s
            [DataMember] public double free; // Free space GB
            [DataMember] public double total; // Total space GB
            [DataMember] public double size; // file size GB
        }

        public string GetCompareUrl(TestSession session)
        {
            var compare = new CompareJson()
            {
                seqWrite = Math.Round(session.SeqWrite, 2),
                seqRead = Math.Round(session.SeqRead, 2),
                randWrite = Math.Round(session.RandWrite, 2),
                randRead = Math.Round(session.RandRead, 2),
                memCopy = Math.Round(session.MemCopy/1024, 2),
                free = Math.Round((double)session.FreeSpaceBytes /1024/1024/1024, 1),
                total = Math.Round((double)session.TotalSpaceBytes / 1024 / 1024 / 1024, 1),
                size = Math.Round((double)session.FileSizeBytes / 1024 / 1024 / 1024, 1),
            };

            var json = "";

            var mem = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(CompareJson));
            ser.WriteObject(mem, compare);
            mem.Position = 0;
            var sr = new StreamReader(mem);
            json = sr.ReadToEnd();

            json = Uri.EscapeDataString(json);

            var prms = inapp_param + Device.RuntimePlatform + 
                "&" + yd_param + json + 
                "&" + buf_param + (session.WriteBuffering ? "1" : "0") +
                "&" + cach_param + (session.MemCache ? "1" : "0") +
                "&" + GetParams();

            prms = TrimQueryString(prms);

            return cpdt_web_url + "?" + prms;
        }

        public void Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Source != null)
            {
                //if (e.Url.Contains(close_param)) this.IsVisible = false;
                if (!e.Url.StartsWith(cpdt_web_url)) NavigatedNotSuccesfully(); // WPF, IE11 - if the URL is incorrect, the page is being redirected to some other URL, though Navigated will still get Success and original URL
            }
            else if (e.NavigationEvent == WebNavigationEvent.Forward) NavigatedSuccesfully(); // macOS hack
        }

        public void Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Result == WebNavigationResult.Success) NavigatedSuccesfully();
            else NavigatedNotSuccesfully();
        }

        private void NavigatedSuccesfully()
        {
            if (navigatedNotSuccesfully) return;
            IsEnabled = true;
        }

        private bool navigatedNotSuccesfully = false;
        private void NavigatedNotSuccesfully()
        {
            IsEnabled = false;
            navigatedNotSuccesfully = true;
            RaisePropertyChanged(nameof(NotAvailable));
        }

        public bool NotAvailable
        {
            get
            {
                return navigatedNotSuccesfully;
            }
        }

        private bool isEnabled = false;

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (value != isEnabled)
                {
                    isEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override void DoShow(object param)
        {
            if ((webView.Source as UrlWebViewSource).Url != Url) webView.Source = Url;
            base.DoShow(param);
        }

        protected override bool OnVisibilityChanging(bool visible)
        {
            if (Device.RuntimePlatform == Device.WPF)
            {
                var di = DependencyService.Get<IWpfWebViewInfo>();
                if (di != null)
                {
                    var v = di.GetIEVersion();
                    if (!v.StartsWith("11"))
                    {
                        Device.OpenUri(new System.Uri(UrlNotInApp));
                        return false;
                    }
                }
            }

            return true;
        }
    }
}