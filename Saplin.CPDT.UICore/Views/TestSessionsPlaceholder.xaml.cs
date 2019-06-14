using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestSessionsPlaceholder : StackLayout
    {
        private bool testSessionsNarrow = true;

        public TestSessionsPlaceholder()
        {
            InitializeComponent();
        }

        public void AdaptLayoytToScreenWidth(bool narrow)
        {
            if (narrow && !testSessionsNarrow)
            {
                testSessionsNarrow = true;

                var ts = new TestSessionsNarrow();

                this.Children.Clear();
                this.Children.Add(ts);
            }
            else if (!narrow && testSessionsNarrow)
            {
                testSessionsNarrow = false;

                var ts = new TestSessions();

                this.Children.Clear();
                this.Children.Add(ts);
            }
        }
    }
}
