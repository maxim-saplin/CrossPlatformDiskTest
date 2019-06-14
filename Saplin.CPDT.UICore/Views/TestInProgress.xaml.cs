using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestInProgress : StackLayout
    {
        private bool testResultsNarrow = true;

        public TestInProgress()
        {
            InitializeComponent();
        }

        public void AdaptLayoytToScreenWidth(bool narrow)
        {
            if (narrow && !testResultsNarrow)
            {
                testResultsNarrow = true;

                var tr = new TestResultsNarrow()
                {
                    BindingContext = ViewModelContainer.DriveTestViewModel,
                    IsFooterVisible = true,
                    ShowFooterIfEmptyItems = true
                };

                tr.SetBinding(GridRepeater.ItemsSourceProperty, nameof(ViewModelContainer.DriveTestViewModel.TestResults));

                testResultsPlaceholder.Children.Clear();
                testResultsPlaceholder.Children.Add(tr);

            }
            else if (!narrow && testResultsNarrow)
            {
                testResultsNarrow = false;

                var tr = new TestResults()
                {
                    BindingContext = ViewModelContainer.DriveTestViewModel,
                    IsFooterVisible = true,
                    ShowFooterIfEmptyItems = true
                };

                tr.SetBinding(GridRepeater.ItemsSourceProperty, nameof(ViewModelContainer.DriveTestViewModel.TestResults));

                testResultsPlaceholder.Children.Clear();
                testResultsPlaceholder.Children.Add(tr);

            }
        }
    }
}
