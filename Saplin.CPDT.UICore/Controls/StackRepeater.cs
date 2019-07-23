using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                view = ItemTemplate.CreateContent() as View;
                view.BindingContext = item;
            }

            return view;
        }

        private static void ItemTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ItemsChanged(bindable, null, (bindable as StackRepeater).ItemsSource);
        }

		private IList addToBeginningItems;

        private void ItemsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
                if (e.PropertyName == "Item[]")
                {
                    ItemsChanged(this, null, sender);
                }
        }

        private void ItemsObservableChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                addToBeginningItems = e.NewItems;
                ItemsChanged(this, null, null);
            }
        }

        private object subscribedToItems = null;

        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as StackRepeater;

            if (control.ItemTemplate == null) return;

            var items = (IEnumerable)newValue;

            if (control.addToBeginningItems != null && control.addToBeginningItems.Count > 0)
			{
                foreach (var item in control.addToBeginningItems)
				{
					var view = control.ViewFromTemplate(item);
                    control.Children.Insert(0, view);
				}

                control.addToBeginningItems = null;
			}
			else if (newValue != null)
			{
				control.Children.Clear();

				if (items.Cast<object>().Any())
				{
					foreach (var item in items)
					{
						if (item != null)
						{
							var view = control.ViewFromTemplate(item);
							control.Children.Add(view);
						}
					}
				}
			}

            if (items != control.subscribedToItems && items is INotifyPropertyChanged)
            {
                var itemsType = items.GetType();
                if (itemsType.IsGenericType && itemsType.GetGenericTypeDefinition().IsAssignableFrom(typeof(ObservableCollection2<>)))
                {
                    (items as INotifyCollectionChanged).CollectionChanged += control.ItemsObservableChanged;
                }
                else
                {
                    (items as INotifyPropertyChanged).PropertyChanged += control.ItemsPropertyChanged;
                }
                control.subscribedToItems = items;
            }

            //if (oldValue != null && oldValue is INotifyPropertyChanged && oldValue != newValue) (oldValue as INotifyPropertyChanged).ItemsPropertyChanged -= control.ItemsChanged;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (ItemsSource == null && BindingContext is IEnumerable && Parent != null)
            {
                ItemsSource = BindingContext as IEnumerable;
            }
            else if (Parent == null)
            {
                ItemsSource = null;
                Children.Clear();
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