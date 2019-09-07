using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleUI : StackLayout
    {
        public SimpleUI()
        {
            InitializeComponent();
        }

        public void AdjustToWidth(double width)
        {
            if (width < 360)
            {
                label1.IsVisible = false;
                label2.IsVisible = false;
            }
            else
            {
                label1.IsVisible = true;
                label2.IsVisible = true;
            }
        }
    }
}
