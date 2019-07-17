using System;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class ErrorViewModel : PopupViewModel
    {
        protected override void OnVisibilityChanged(bool visible)
        {
            base.OnVisibilityChanged(visible);

            if (visible)
                if (showData is Exception)
                {
                    var ex = (showData as Exception);
                    ExceptionName = ex.GetType().ToString();
                    Message = ex.Message;
                }
                else
                {
                    if (ex != null)
                    {
                        ExceptionName = ex.GetType().ToString();
                        if (!string.IsNullOrEmpty(title))
                        {
                            Message = ex.Message + "\n\n" + title;
                        }
                        else Message = ex.Message;
                    }
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

        private string title;
        private Exception ex;

        public virtual void DoShow(string title, Exception ex)
        {
            this.title = title;
            this.ex = ex;
            Show.Execute(null);
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

