using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ScrollView
    {
        public About()
        {
            InitializeComponent ();
            version.Text = "v. "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
