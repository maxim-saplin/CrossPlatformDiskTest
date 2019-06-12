using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        public NavigationViewModel()
		{
			PropertyChangedEventHandler isVisisbleChanged = (s, e) =>
			{
                if (e.PropertyName == nameof(PopupViewModel.IsVisible))
                {
                    IsAnyPopupVisible = (s as PopupViewModel).IsVisible;
                }
			};

            ViewModelContainer.OptionsViewModel.PropertyChanged += isVisisbleChanged;
            ViewModelContainer.AboutViewModel.PropertyChanged += isVisisbleChanged;
            ViewModelContainer.ErrorViewModel.PropertyChanged += isVisisbleChanged;
        }

        private bool isAnyPopupVisible = false;

        public bool IsAnyPopupVisible
        {
            get
            {
                return isAnyPopupVisible;
            }
            set
            {
                if (value != isAnyPopupVisible)
                {
                    isAnyPopupVisible = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool isNarrowView = false;

        public bool IsNarrowView
        {
            get
            {
                return isNarrowView;
            }
            set
            {
                if (value != isNarrowView)
                {
                    isNarrowView = value;
                    RaisePropertyChanged();
                }
            }
        }

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
