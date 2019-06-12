using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestSessionsNarrow : StackRepeater
	{
		public TestSessionsNarrow()
		{
			InitializeComponent();
		}

        void Share_Clicked(object sender, System.EventArgs e)
        {
            TestSessions.ShareHandler(sender, e);
        }
    }
}