using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    public class ExtendedLabel : Label
    {
        private event EventHandler click;

        public string Name
        {
            get; set;
        }

        public void DoClick()
        {
            click.Invoke(this, null);
            
        }

        public event EventHandler Clicked
        {
            add
            {
                lock (this)
                {
                    click += value;

                    var g = new TapGestureRecognizer();

                    g.Tapped += (s, e) => click?.Invoke(s, e);

                    GestureRecognizers.Add(g);
                }
            }
            remove
            {
                lock (this)
                {
                    click -= value;

                    GestureRecognizers.Clear();
                }
            }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: nameof(Command),
                returnType: typeof(ICommand),
                declaringType: typeof(ExtendedLabel),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: CommandChanged
             );

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private static void CommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ExtendedLabel)bindable;
            var command = newValue as ICommand;

            if (command == null) control.Clicked -= control.ExecuteCommand;
            else control.Clicked += control.ExecuteCommand;
        }

        private void ExecuteCommand(object sender, EventArgs e)
        {
            if (IsEnabled)
                Command.Execute(CommandParameter);
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                propertyName: nameof(CommandParameter),
                returnType: typeof(Object),
                declaringType: typeof(ExtendedLabel),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay
             );

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty ChangeCursorOnMouseHoverProperty =
            BindableProperty.Create(
                propertyName: nameof(ChangeCursorOnMouseHover),
                returnType: typeof(Boolean),
                declaringType: typeof(ExtendedLabel),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay
         );

        public bool ChangeCursorOnMouseHover
        {
            get { return (Boolean)GetValue(ChangeCursorOnMouseHoverProperty); }
            set { SetValue(ChangeCursorOnMouseHoverProperty, value); }
        }
    }
}
