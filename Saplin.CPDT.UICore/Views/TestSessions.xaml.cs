using System;
using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestSessions : StackRepeater
	{
		public TestSessions()
		{
			InitializeComponent();
		}

        public static EventHandler ShareHandler = (object sender, System.EventArgs e)
            =>
        {
            var share = DependencyService.Get<IShareViewAsImage>();

            if (share != null)
            {
                var masterDetail = ((sender as View)?.Parent?.Parent?.Parent?.Parent) as Layout;

                if (masterDetail != null && masterDetail.Children.Count > 1)
                {
                    var detail = masterDetail.Children[1] as View;

                    if (detail != null)
                    {
                        share.Share(detail, !ViewModelContainer.OptionsViewModel.WhiteThemeBool, ViewModelContainer.L11n.ShareTitle);
                        ViewModelContainer.ResultsDbViewModel.SendPageHit("share");
                    }
                }
            }
        };

        void Share_Clicked(object sender, System.EventArgs e)
        {
            ShareHandler(sender, e);
        }
    }
}