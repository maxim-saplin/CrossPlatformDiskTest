using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestInProgress : StackLayout
    {
        private bool? testResultsNarrow = null;

        public TestInProgress()
        {
            InitializeComponent();
        }

        public void AdaptLayoytToScreenWidth(bool narrow)
        {
            if (narrow && (!testResultsNarrow.HasValue || !testResultsNarrow.Value))
            {
                ClearBindings();
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
            else if (!narrow && (!testResultsNarrow.HasValue || testResultsNarrow.Value))
            {
                ClearBindings();
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

        //Bindings subsribe to PropertChanegd event of the parent and events keep getting triggered
        private void ClearBindings()
        {
            if (testResultsPlaceholder.Children.Count > 0)
            {
                if (testResultsPlaceholder.Children[0] is GridRepeater) (testResultsPlaceholder.Children[0] as GridRepeater).ClearBindnings();
            }
        }
    }
}
