using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class RollingSelector : ExtendedLabel
    {
        private bool clickAssigned = false;

        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(
                propertyName: nameof(Items),
                returnType: typeof(KeyValue[]),
                declaringType: typeof(ExtendedLabel),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ItemsPropertyChanged
             );

        private int count = 0;
        private int selectedIndex = 0;

        public int Count
        {
            get { return count;}
        }

        private void UpdateSelectedIndex()
        {
            selectedIndex = 0;

            var selectedKey = !string.IsNullOrEmpty(SelectedItemKey) ? SelectedItemKey.ToLower() : string.Empty;

            foreach (var kv in Items)
            {
                if (kv.Key.ToLower() == selectedKey) break;
                selectedIndex++;
            }
        }

        private static void ItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as RollingSelector;

            if (newValue == null) control.count = 0; else control.count = (newValue as KeyValue[]).Length;

            var selectedKey = !string.IsNullOrEmpty(control.SelectedItemKey) ? control.SelectedItemKey.ToLower() : string.Empty;

            if (!string.IsNullOrEmpty(selectedKey))
            {
                if (!((IEnumerable<KeyValue>)control.Items).Any(kv => kv.Key.ToLower() == selectedKey as string))
                    throw new InvalidOperationException("Can't select key which is not presetn as key in Items collection");

                control.Text = ((IEnumerable<KeyValue>)control.Items)
                    .Where(kv => kv.Key.ToLower() == selectedKey)
                    .Select<KeyValue, string>(kv => kv.Value as string)
                    .Single();

                control.UpdateSelectedIndex();
            }

            if (!control.clickAssigned)
            {
                control.clickAssigned = true;
                control.Clicked += (s, e) =>
                {
                    if (control.count != 0)
                    {
                        if (control.selectedIndex + 1 == control.count) control.selectedIndex = 0; else control.selectedIndex++;

                        control.Text = (newValue as KeyValue[])[control.selectedIndex].Value;
                        control.SelectedItemKey = (newValue as KeyValue[])[control.selectedIndex].Key;
                    }
                };
            }
        }

        public IEnumerable<KeyValue> Items
        {
            get { return GetValue(ItemsProperty) as IEnumerable<KeyValue>; }
            set
            {
                SetValue(ItemsProperty, value);
            }
        }

        public static readonly BindableProperty SelectedItemKeyProperty =
            BindableProperty.Create(
                propertyName: nameof(SelectedItemKey),
                returnType: typeof(string),
                declaringType: typeof(ExtendedLabel),
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: SelectedItemKeyChanged
             );

        public string SelectedItemKey
        {
            get { return GetValue(SelectedItemKeyProperty) as string; }
            set
            {
                SetValue(SelectedItemKeyProperty, value);
            }
        }

        private static void SelectedItemKeyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as RollingSelector;

            if (control.Items == null) return;

            var value = newValue is string ? (newValue as string).ToLower() : string.Empty;

            //TODO check unique keys
            if (!((IEnumerable<KeyValue>)control.Items).Any(kv => kv.Key == value))
                throw new InvalidOperationException("Can't select key which is not presetn as key in Items collection");

            if (string.IsNullOrEmpty(value))
            {
                control.Text = "";
            }

            control.Text = ((IEnumerable<KeyValue>)control.Items)
                .Where(kv => kv.Key == value as string)
                .Select<KeyValue, string>(kv => kv.Value as string)
                .Single();

            control.UpdateSelectedIndex();
        }
    }
}
