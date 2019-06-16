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

            //if (ViewModelContainer.DriveTestViewModel.AvailableDrivesCount < 1) IsSimpleUI = false;

            ViewModelContainer.OptionsViewModel.PropertyChanged += isVisisbleChanged;
            ViewModelContainer.AboutViewModel.PropertyChanged += isVisisbleChanged;
            ViewModelContainer.ErrorViewModel.PropertyChanged += isVisisbleChanged;

            ViewModelContainer.DriveTestViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(DriveTestViewModel.TestStarted))
                {
                    RaisePropertyChanged(nameof(IsSimpleUIStartPageVisible));
                    RaisePropertyChanged(nameof(IsSimpleUIHeaderVisible));
                    RaisePropertyChanged(nameof(IsAdvancedUIVisible));
                    RaisePropertyChanged(nameof(IsStatusVisible));
                }
            };

            ViewModelContainer.TestSessionsViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TestSessionsViewModel.HasItems))
                {
                    RaisePropertyChanged(nameof(IsStatusVisible));
                }
            };
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

        private const string True = "true";
        private const string False = "false";

        private bool isNarrowView = true;

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

        public bool IsSimpleUI
        {
            get
            {
                if (ViewModelContainer.DriveTestViewModel.AvailableDrivesCount < 1) return false;

                if (!Application.Current.Properties.ContainsKey(nameof(IsSimpleUI))) Application.Current.Properties[nameof(IsSimpleUI)] = True;

                return Application.Current.Properties[nameof(IsSimpleUI)] as string == True;
            }
            set
            {
                if (value != (Application.Current.Properties[nameof(IsSimpleUI)] as string == True))
                {
                    Application.Current.Properties[nameof(IsSimpleUI)] = value ? True : False;

                    RaisePropertyChanged(nameof(IsSimpleUI));
                    RaisePropertyChanged(nameof(IsSimpleUIStartPageVisible));
                    RaisePropertyChanged(nameof(IsSimpleUIHeaderVisible));
                    RaisePropertyChanged(nameof(IsAdvancedUIVisible));
                    RaisePropertyChanged(nameof(IsTitleVisible));
                    RaisePropertyChanged(nameof(IsStatusVisible));

                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        public bool IsSimpleUIStartPageVisible
        {
            get
            {
                if (ViewModelContainer.DriveTestViewModel.AvailableDrivesCount < 1) return false;
                if (ViewModelContainer.TestSessionsViewModel.HasItems) return false;
                if (ViewModelContainer.DriveTestViewModel.TestStarted) return false;

                return IsSimpleUI;
            }
        }

        public bool IsSimpleUIHeaderVisible
        {
            get
            {
                if (ViewModelContainer.DriveTestViewModel.AvailableDrivesCount < 1) return false;
                if (!ViewModelContainer.TestSessionsViewModel.HasItems) return false;
                if (ViewModelContainer.DriveTestViewModel.TestStarted) return false;

                return IsSimpleUI;
            }
        }

        public bool IsAdvancedUIVisible
        {
            get
            {
                if (!IsSimpleUI && !ViewModelContainer.DriveTestViewModel.TestStarted) return true;

                return false;
            }
        }

        public bool IsTitleVisible
        {
            get
            {
                if (Device.RuntimePlatform == Device.Android && IsSimpleUI) return false;

                return true;
            }
        }

        public bool IsStatusVisible
        {
            get
            {
                if (ViewModelContainer.DriveTestViewModel.TestStarted) return false;
                if (IsSimpleUI && !ViewModelContainer.TestSessionsViewModel.HasItems) return false;

                return true;
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

        ICommand switchToAdvancedUI;

        public ICommand SwitchToAdvancedUI
        {
            get
            {
                return switchToAdvancedUI != null ? switchToAdvancedUI :

                    switchToAdvancedUI = switchToAdvancedUI = new Command((param) =>
                    {
                        bool aUI = false;

                        if (param is string && bool.TryParse(param as string, out aUI))
                        {
                            if (aUI && IsSimpleUI) IsSimpleUI = false;
                            else if (!aUI && !IsSimpleUI) IsSimpleUI = true;
                        }
                    });
            }
        }
    }
}
