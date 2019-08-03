using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    /// <summary>
    /// Dummy class for better naming in XAML when using Grid repaeter
    /// </summary>
    public class GridItem : SimpleLayout
    { }

    /// <summary>
    /// Creates row for each ItemSource entry. Control's order in the entry defines it's column
    /// </summary>
    public class GridRepeater : Grid
    {
        public GridRepeater()
        {
            Rows = new List<List<View>>();
            HeaderRow = -1;
            FooterRow = -1;
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(GridRepeater),
                default(DataTemplate)
         );

        public static readonly BindableProperty FooterTemplateProperty =
            BindableProperty.Create(
                nameof(FooterTemplate),
                typeof(DataTemplate),
                typeof(GridRepeater),
                default(DataTemplate)
         );

        public static readonly BindableProperty HeaderTemplateProperty =
            BindableProperty.Create(
                nameof(HeaderTemplate),
                typeof(DataTemplate),
                typeof(GridRepeater),
                default(DataTemplate)
         );

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(IEnumerable),
                typeof(GridRepeater),
                null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ItemsChanged
        );

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsEnabled))
            {
                foreach (var c in Children)
                    c.IsEnabled = IsEnabled;
            }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public DataTemplate FooterTemplate
        {
            get { return (DataTemplate)GetValue(FooterTemplateProperty); }
            set { SetValue(FooterTemplateProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private GridItem ViewFromTemplate(DataTemplate template, object bindingContext = null)
        {
            View view = null;
            if (template != null)
            {
                view = template.CreateContent() as View;

                if (!(view is Layout)) throw new InvalidOperationException("GreadRepater.(Item,Header,Footer)Template.DataTemplate must be a container element dervied from Xamarin.Forms.StackLayout");

                var layout = view as GridItem;

                foreach (var c in layout.Children)
                    c.BindingContext = bindingContext;
            }

            return view as GridItem;
        }

        public List<List<View>> Rows
        {
            get; private set;
        }

        public int HeaderRow
        {
            get; private set;
        }

        public int FooterRow
        {
            get; private set;
        }

        private IList addToTheEndItems;

        private void ItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                addToTheEndItems = e.NewItems;
            }

            ItemsChanged(this, null, sender);
        }

        private object subscribedToItems = null;

        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as GridRepeater;

            var row = 0;

            if (control.addToTheEndItems == null)
            {
                control.Children.Clear();
                control.Rows.Clear();
                control.RowDefinitions.Clear();
                control.HeaderRow = -1;
                control.FooterRow = -1;
            }
            else
            {
                control.RemoveFooter();
                row = control.Rows.Count;
            }
            
            IEnumerable items = newValue == null ? null : ((IEnumerable)newValue);

            var itemsNotEmpty = items != null && items.Cast<object>().Any();

            if (control.HeaderTemplate != null && control.addToTheEndItems == null && (control.ShowFooterIfEmptyItems || itemsNotEmpty))
            {
                AddHeaderOrFooter(control, control.HeaderTemplate, row);
                control.HeaderRow = row;
                row++;
            }

            if (itemsNotEmpty || control.addToTheEndItems != null)
            {
                items = control.addToTheEndItems == null ? items : control.addToTheEndItems;

                foreach (var item in items)
                {
                    if (control.MaxRows > 0 && row >= control.MaxRows) break;

                    var layout = control.ViewFromTemplate(control.ItemTemplate, item);
                    var children = layout.Children.ToArray();

                    var col = 0;

                    foreach (var child in children)
                    {
                        if (!(child is Animations.AnimationBase))
                        {
                            AddChildToRow(control, layout, row, col, child);
                            col++;
                        }
                    }

                    row++;
                }
            }

            if (control.MaxRows > 0 && row < control.MaxRows) control.AddFooter();

            if (items is INotifyCollectionChanged && items != control.subscribedToItems)
            {
                (items as INotifyCollectionChanged).CollectionChanged += control.ItemsChanged;
                control.subscribedToItems = items;
            }

            if (oldValue != null && oldValue is INotifyCollectionChanged && oldValue != newValue) (oldValue as INotifyCollectionChanged).CollectionChanged -= control.ItemsChanged;

            control.addToTheEndItems = null;
        }

        private static void AddHeaderOrFooter(GridRepeater control, DataTemplate template, int row)
        {
            var layout = control.ViewFromTemplate(template, control.BindingContext) as GridItem;
            var children = layout.Children.ToArray();

            var col = 0;

            foreach (var child in children)
            {
                if (!(child is Animations.AnimationBase))
                {
                    AddChildToRow(control, layout, row, col, child);
                    col++;
                }
            }
        }

        private static void AddChildToRow(GridRepeater control, GridItem layout, int row, int col, View child)
        {
            layout.Children.Remove(child);
            var colAttached = Grid.GetColumn(child);
            col = colAttached == 0 ? col : colAttached;

            var colSpanAttached = Grid.GetColumnSpan(child);

            control.Children.Add(child as View, col, col + colSpanAttached, row, row + 1);

            if (control.Rows.Count <= row)
            {
                control.Rows.Add(new List<View>());
                if (!control.RowHeight.IsAuto) control.RowDefinitions.Add(new RowDefinition() {Height = control.RowHeight });
            }

            control.Rows[row].Add(child);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            BuildControls();
        }

        private void BuildControls()
        {
            FixItemsSource();
            ItemsChanged(this, null, ItemsSource); // JIC render header and footer
        }

        private void FixItemsSource()
        {
            if (ItemsSource == null && BindingContext is IEnumerable)
            {
                ItemsSource = BindingContext as IEnumerable;
            }
        }

        public static readonly BindableProperty RefreshProperty =
            BindableProperty.Create(
                nameof(Refresh),
                typeof(object),
                typeof(GridRepeater),
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
            (bindable as GridRepeater).BuildControls();
        }

        public static readonly BindableProperty ShowHeadreIfEmptyItemsProperty =
            BindableProperty.Create(
                nameof(ShowHeaderIfEmptyItems),
                typeof(bool),
                typeof(GridRepeater),
                false,
                defaultBindingMode: BindingMode.OneWay
            );

        public bool ShowHeaderIfEmptyItems
        {
            get { return (bool)GetValue(ShowHeadreIfEmptyItemsProperty); }
            set { SetValue(ShowHeadreIfEmptyItemsProperty, value); }
        }

        public static readonly BindableProperty ShowFooterIfEmptyItemsProperty =
            BindableProperty.Create(
                nameof(ShowFooterIfEmptyItems),
                typeof(bool),
                typeof(GridRepeater),
                false,
                defaultBindingMode: BindingMode.OneWay
            );

        public bool ShowFooterIfEmptyItems
        {
            get { return (bool)GetValue(ShowFooterIfEmptyItemsProperty); }
            set { SetValue(ShowFooterIfEmptyItemsProperty, value); }
        }

        public static readonly BindableProperty IsFooterVisibleProperty =
            BindableProperty.Create(
                nameof(IsFooterVisible),
                typeof(bool),
                typeof(GridRepeater),
                true,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: IsFooterVisiblePropertyChanged
            );

        public bool IsFooterVisible
        {
            get { return (bool)GetValue(IsFooterVisibleProperty); }
            set { SetValue(IsFooterVisibleProperty, value); }
        }

        private static void IsFooterVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as GridRepeater;

            if (!(bool)newValue)
            {
                control.RemoveFooter();
            }
            else
            {
                control.AddFooter();
            }
        }

        private void RemoveFooter()
        {
            if (FooterRow > -1 && Rows[FooterRow] != null)
            {
                foreach (var c in Rows[FooterRow])
                {
                    c.BindingContext = null;
                    Children.Remove(c);
                }
                Rows.RemoveAt(FooterRow);
                if (RowDefinitions.Count > FooterRow) RowDefinitions.RemoveAt(FooterRow);
                FooterRow = -1;
            }
        }

        private void AddFooter()
        {
            var itemsNotEmpty = ItemsSource != null && ItemsSource.Cast<object>().Any();

            if (FooterTemplate != null && (ShowFooterIfEmptyItems || itemsNotEmpty) && IsFooterVisible)
            {
                var row = Rows.Count;
                AddHeaderOrFooter(this, FooterTemplate, row);
                FooterRow = row;
            }
        }

        public GridLength RowHeight { get; set; }

        public int MaxRows { get; set; } = -1; // hack to deal with hiding 6th line in 5 tests' result view

        public void ClearBindnings()
        {
            //UnapplyBindings();

            foreach (var c in Children)
                c.BindingContext = null;

            BindingContext = null;
        }
    }
}