using System;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class ErrorViewModel : PopupViewModel
    {
        protected override void OnVisibilityChanged(bool visible)
        {
            base.OnVisibilityChanged(visible);

            if (visible && showData is Exception)
            {
                var ex = (showData as Exception);
                ExceptionName = ex.GetType().ToString();
                Message = ex.Message;
            }
        }

        private string message;

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (value != message)
                {
                    message = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string exceptionName;

        public string ExceptionName
        {
            get
            {
                return exceptionName;
            }
            set
            {
                if (value != exceptionName)
                {
                    exceptionName = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}

