using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class ResultsDbViewModel : PopupViewModel
    {
        const string cpdt_web_url = @"https://maxim-saplin.github.io/cpdt_results/";
        //const string cpdt_web_url = @"http://localhost:3000/";
        const string white_theme_param = "theme=white";
        const string locale_param = "lang=";
        const string inapp_param = "inapp=";
        const string close_param = "close";

        //private string url;

        public void BindWebView(WebView webView)
        {
            webView.Navigating += Navigating;
            webView.Navigated += Navigated;
            webView.Source = Url;
        }

        public string Url
        {
            get
            {
                //return url;
                return cpdt_web_url + "?" +
                        inapp_param + "&" +
                        locale_param + ViewModelContainer.L11n._Locale +
                        (ViewModelContainer.OptionsViewModel.WhiteThemeBool ?
                            "&" + white_theme_param :
                            "");
            }
            //set
            //{
            //    if (string.IsNullOrEmpty(value)) return;

            //    url = value;
            //    RaisePropertyChanged();
            //}
        }

        public void Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains(close_param)) this.IsVisible = false;
        }

        public void Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Url.Contains(close_param)) this.IsVisible = false;
        }

        //protected override void OnVisibilityChanged(bool visible)
        //{
        //    base.OnVisibilityChanged(visible);

        //    if (visible && string.IsNullOrEmpty(Url))
        //    { 
        //        Url = cpdt_web_url + "?" +
        //                inapp_param + "&" +
        //                locale_param + ViewModelContainer.L11n._Locale + 
        //                (ViewModelContainer.OptionsViewModel.WhiteThemeBool ? 
        //                    "&" + white_theme_param :
        //                    "")
        //        ;
        //    }
        //    else Url = "";
        //}
    }
}
