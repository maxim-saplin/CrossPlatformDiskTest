using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public abstract class PopupViewModel : BaseViewModel
    {
        private bool isVisible = false;

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                if (value != isVisible)
                {
                    if (!OnVisibilityChanging(value)) return;
                    isVisible = value;
                    RaisePropertyChanged();
                    OnVisibilityChanged(value);
                }
            }
        }

        private ICommand show;

        public ICommand Show
        {
            get
            {
                if (show == null)
                    show = new Command((object param) => { showData = param;  IsVisible = true; });

                return show;
            }
        }

        public virtual void DoShow(object param)
        {
            Show.Execute(param);
        }

        protected object showData;

        private ICommand close;

        public ICommand Close
        {
            get
            {
                if (close == null)
                    close = new Command(() => { IsVisible = false; });

                return close;
            }
        }

        protected virtual bool OnVisibilityChanging(bool visible)
        {
            return true;
        }

        protected virtual void OnVisibilityChanged(bool visible)
        {
        }

    }
}
