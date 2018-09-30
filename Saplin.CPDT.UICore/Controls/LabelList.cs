using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    public class LabelList : StackLayout
    {
        public bool ChangeCursorOnMouseHover { get; set; }

        private bool subscribedToCollectionChanges = false;

        public string ControlName
        {
            get; set;
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                propertyName: nameof(ItemsSource),
                returnType: typeof(IEnumerable<KeyValuePair<object, string>>),
                declaringType: typeof(LabelList),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ItemsChanged
             );

        public IEnumerable<KeyValuePair<object, string>> ItemsSource
        {
            get { return GetValue(ItemsSourceProperty) as IEnumerable<KeyValuePair<object, string>>; }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly BindableProperty ItemClickCommandProperty =
            BindableProperty.Create(
                propertyName: nameof(ItemClickCommand),
                returnType: typeof(ICommand),
                declaringType: typeof(LabelList),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ItemsChanged
             );

        public ICommand ItemClickCommand
        {
            get { return (ICommand)GetValue(ItemClickCommandProperty); }
            set { SetValue(ItemClickCommandProperty, value); }
        }

        private void ItemsChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Item[]")
                ItemsChanged(this, null, sender);
        }

        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LabelList)bindable;

            var items = newValue as IEnumerable<KeyValuePair<object, string>>;

            if (items is INotifyPropertyChanged) // Hack since ObservableCollection notifications are not working with Xamarin.Forms change tracking
            {
                if (!control.subscribedToCollectionChanges)
                {
                    control.subscribedToCollectionChanges = true;
                    (items as INotifyPropertyChanged).PropertyChanged += control.ItemsChanged;
                }
            }

            if (oldValue != null && oldValue is INotifyPropertyChanged && oldValue != newValue) (oldValue as INotifyPropertyChanged).PropertyChanged -= control.ItemsChanged;

            if (items != null)
            {
                control.Children.Clear();
                foreach (var item in items)
                {
                    var label = new ExtendedLabel();

                    label.Text = item.Value;
                    label.HorizontalOptions = LayoutOptions.Start;
                    label.Name = item.Key as string;

                    control.Children.Add(label);
                }
            }

            if (newValue is ICommand && control.ItemClickCommand != null)
            {
                foreach (var item in control.ItemsSource as IEnumerable<KeyValuePair<object, string>>)
                {
                    if (item.Key != null)
                    {
                        var g = new TapGestureRecognizer();
                        g.Tapped += (s, e) =>
                        {
                            control.ItemClickCommand?.Execute(item.Key);
                        };

                        var label = control.Children.Cast<ExtendedLabel>().First(l => l.Name == (string)item.Key);
                                           
                        label.GestureRecognizers.Add(g);

                        label.ChangeCursorOnMouseHover = control.ChangeCursorOnMouseHover;
                    }
                }
            }
        }
    }
}