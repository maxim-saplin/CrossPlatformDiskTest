using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private ICommand showOptions = new Command(() => { ViewModelContainer.OptionsViewModel.DoShow(null); });

        public ICommand ShowOptions
        {
            get
            {
                return showOptions;
            }
        }

        private ICommand showAbout = new Command(() => { ViewModelContainer.AboutViewModel.DoShow(null); });

        public ICommand ShowAbout
        {
            get
            {
                return showAbout;
            }
        }

        private ICommand showDb = new Command(() => { ViewModelContainer.ResultsDbViewModel.DoShow(null); }, () =>  ViewModelContainer.ResultsDbViewModel.IsEnabled);

        public ICommand ShowDb
        {
            get
            {
                return showDb;
            }
        }

        private ICommand refresh = new Command(() => { ViewModelContainer.DriveTestViewModel.RefreshDrives(); });

        public ICommand Refresh
        {
            get
            {
                return refresh;
            }
        }
    }
}
