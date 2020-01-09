using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdvancedUI : StackLayout
    {
        public AdvancedUI()
        {
            InitializeComponent();
        }

        public void AdaptLayoytToScreenWidth(bool narrow)
        {
            buttons.AdaptLayoytToScreenWidth(narrow);
        }

        public void MakeDbButtonRedirecting()
        {
            buttons.MakeDbButtonRedirecting();
        }
    }
}
