using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;

namespace Saplin.CPDT.UICore
{
    public partial class OnlineDb : SimpleLayout
    {
        public OnlineDb()
        {
            InitializeComponent();
            ViewModelContainer.ResultsDbViewModel.BindWebView(webView);
        }
    }
}
