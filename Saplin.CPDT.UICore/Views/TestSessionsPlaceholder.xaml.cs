using Saplin.CPDT.UICore.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestSessionsPlaceholder : StackLayout
    {
        private bool? testSessionsNarrow;

        public TestSessionsPlaceholder()
        {
            InitializeComponent();
        }

        public void AdaptLayoytToScreenWidth(bool narrow)
        {
            if (narrow && (!testSessionsNarrow.HasValue || !testSessionsNarrow.Value))
            { 
                ClearBindings();
                testSessionsNarrow = true;

                var ts = new TestSessionsNarrow();

                Children.Clear();
                Children.Add(ts);
            }
            else if (!narrow && (!testSessionsNarrow.HasValue || testSessionsNarrow.Value))
            {
                ClearBindings();
                testSessionsNarrow = false;

                var ts = new TestSessions();

                Children.Clear();
                Children.Add(ts);
            }
        }

        private void ClearBindings()
        {
            if (Children.Count > 0)
            {
                var c = Children[0] as StackRepeater;
                c.ClearBindnings();
                c.ItemsSource = null;
                c.IsVisible = false;
                c.Refresh = null;
            }
        }
    }
}
