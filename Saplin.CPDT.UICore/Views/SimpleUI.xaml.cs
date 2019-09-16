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
                if (width > 399)
                {
                    label1.WidthRequest += 10;
                    label2.WidthRequest += 10;
                    cursor.WidthRequest += 10;
                }
            } 
        }
    }
}
