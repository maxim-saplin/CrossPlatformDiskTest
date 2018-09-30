using System.Collections;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    public class StackRepeater : StackLayout
    {
        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(StackRepeater),
                default(DataTemplate),
                propertyChanged: ItemTemplateChanged
         );

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(IEnumerable),
                typeof(StackRepeater),
                null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ItemsChanged
            );

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private View ViewFromTemplate(object item)
        {
            View view = null;
            if (ItemTemplate != null)
            {
                var content = ItemTemplate.CreateContent();
                view = (content is View) ? content as View : ((ViewCell)content).View;

                view.BindingContext = item;
            }

            return view;
        }

        private static void ItemTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ItemsChanged(bindable, null, (bindable as StackRepeater).ItemsSource);
        }

        private void ItemsChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Item[]")
            {
                ItemsChanged(this, null, sender);
            }
        }

        private object subscribedToItems = null;


        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as StackRepeater;

            if (control.ItemTemplate == null || newValue == null) return;

            //TODO - do not clear items in case item is added
            control.Children.Clear();

            IEnumerable items = (IEnumerable)newValue;
            if (items.Cast<object>().Any())
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        control.Children.Add(control.ViewFromTemplate(item));
                    }
                }
            }

            if (items is INotifyPropertyChanged && items != control.subscribedToItems)
            {
                (items as INotifyPropertyChanged).PropertyChanged += control.ItemsChanged;
                control.subscribedToItems = items;
            }

            if (oldValue != null && oldValue is INotifyPropertyChanged && oldValue != newValue) (oldValue as INotifyPropertyChanged).PropertyChanged -= control.ItemsChanged;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (ItemsSource == null && BindingContext is IEnumerable)
            {
                ItemsSource = BindingContext as IEnumerable;
            }
        }

        public static readonly BindableProperty RefreshProperty =
            BindableProperty.Create(
                nameof(Refresh),
                typeof(object),
                typeof(StackRepeater),
                null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: RefreshPropertyChanged
            );

        public object Refresh
        {
            get { return GetValue(RefreshProperty); }
            set { SetValue(RefreshProperty, value); }
        }

        private static void RefreshPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ItemsChanged(bindable, null, (bindable as StackRepeater).ItemsSource);
        }
    }
}