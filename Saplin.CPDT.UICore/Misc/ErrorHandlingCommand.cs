using Saplin.CPDT.UICore.ViewModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public class ErrorHandlingCommand : Command, ICommand
    {
        private Action fallBack;

        public ErrorHandlingCommand(Action<object> execute, Action fallBack = null) : base(execute)
        {
            this.fallBack = fallBack;
        }

        void ICommand.Execute(object parameter)
        {
            try
            {
                base.Execute(parameter);
            }
            catch(Exception ex)
            {
                fallBack?.Invoke();
                ViewModelContainer.ErrorViewModel.DoShow(ex);
            }
        }
    }
}
