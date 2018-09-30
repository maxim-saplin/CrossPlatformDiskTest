using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private ICommand showOptions = new Command(() => { ViewModelContainer.OptionsViewModel.IsVisible = true; });

        public ICommand ShowOptions
        {
            get
            {
                return showOptions;
            }
        }

        private ICommand showAbout = new Command(() => { ViewModelContainer.AboutViewModel.IsVisible = true; });

        public ICommand ShowAbout
        {
            get
            {
                return showAbout;
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
