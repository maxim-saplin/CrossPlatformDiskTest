using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public partial class OnlineDb : StackLayout
    {
        public OnlineDb()
        {
            InitializeComponent();
            ViewModelContainer.ResultsDbViewModel.BindWebView(webView);
        }
    }
}
