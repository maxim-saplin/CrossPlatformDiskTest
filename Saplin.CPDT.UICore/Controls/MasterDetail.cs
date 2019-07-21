using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    public class MasterDetail : StackLayout
    {
        public static readonly BindableProperty MasterTemplateProperty =
            BindableProperty.Create(
                nameof(MasterTemplate),
                typeof(DataTemplate),
                typeof(MasterDetail),
                default(DataTemplate)
         );

        public static readonly BindableProperty DetailTemplateProperty =
            BindableProperty.Create(
                nameof(DetailTemplate),
                typeof(DataTemplate),
                typeof(MasterDetail),
                default(DataTemplate)
         );

        public DataTemplate MasterTemplate
        {
            get { return (DataTemplate)GetValue(MasterTemplateProperty); }
            set { SetValue(MasterTemplateProperty, value); }
        }

        public DataTemplate DetailTemplate
        {
            get { return (DataTemplate)GetValue(DetailTemplateProperty); }
            set { SetValue(DetailTemplateProperty, value); }
        }

        public static readonly BindableProperty DetailBindingContextProperty =
            BindableProperty.Create(
                nameof(DetailBindingContext),
                typeof(object),
                typeof(MasterDetail),
                null
         );

        public object DetailBindingContext
        {
            get { return GetValue(DetailBindingContextProperty); }
            set { SetValue(DetailBindingContextProperty, value); }
        }

        public static readonly BindableProperty IsMasterVisibleProperty =
            BindableProperty.Create(
                propertyName: nameof(IsMasterVisible),
                returnType: typeof(bool),
                declaringType: typeof(MasterDetail),
                defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: MasterIsVisibleChanged
             );

        public bool IsMasterVisible
        {
            get { return (bool)GetValue(IsMasterVisibleProperty); }
            set { SetValue(IsMasterVisibleProperty, value); }
        }

        public static readonly BindableProperty IsDetailVisibleProperty =
            BindableProperty.Create(
                propertyName: nameof(IsDetailVisible),
                returnType: typeof(bool),
                declaringType: typeof(MasterDetail),
                defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: DetailIsVisibleChanged
             );

        public bool IsDetailVisible
        {
            get { return (bool)GetValue(IsDetailVisibleProperty); }
            set { SetValue(IsDetailVisibleProperty, value); }
        }

        private Layout masterView, detailView;
        private bool masterAdded = false, detailAdded = false;
        private bool toggleClickAssigned = false;

        private void ToggleClicked(object sender, EventArgs e)
        {
            if (MasterDetail.GetToggleDetailOnClicked(sender as View) || ToggleOnMasterClick)
            {
                if (!string.IsNullOrEmpty(SelectionGroup) && !IsDetailVisible)
                {
                    if (selectionGroups.ContainsKey(SelectionGroup))
                    {
                        var list = selectionGroups[SelectionGroup];

                        foreach(var c in list)
                        {
                            c.IsDetailVisible = false;
                        }
                    }
                }

                IsDetailVisible = !IsDetailVisible;
            }
        }

        /// <summary>
        /// Clicking in any place of Master will toggle teh Master/Detail, ToggleDetailOnClicked is an attached property which can be used to track clicks on specific chile items within Master
        /// </summary>
        public bool ToggleOnMasterClick { get; set; }

        private static void MasterIsVisibleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as MasterDetail;

            if (control.MasterTemplate == null) return;

            if ((bool)newValue)
            {
                if (control.masterView == null)
                {
                    control.masterView = control.ViewFromTemplate(control.MasterTemplate, control.BindingContext);

                    if (control.ToggleOnMasterClick)
                    {
                        var g = new TapGestureRecognizer();
                        g.Tapped += (s, e) => { control.ToggleClicked(s, e); };
                        control.masterView.GestureRecognizers.Add(g);
                    }

                    if (control.detailAdded) control.Children.Clear();
                    SetOnMasterClick(control);
                    control.Children.Add(control.masterView);

                    if (control.detailAdded) // JIC, order of calls to master and detail visible change can be any
                    {
                        if (control.detailView != null)
                        {
                            control.Children.Add(control.detailView);
                        }
                        else
                        {
                            control.detailAdded = false;
                        }
                    }

                    control.masterAdded = true;
                }
                else if (!control.masterAdded)
                {
                    SetOnMasterClick(control);
                    if (!control.detailAdded)
                    {
                        control.Children.Add(control.masterView);
                    }
                    else
                    {
                        control.Children.Clear();
                        control.Children.Add(control.masterView);
                        if (control.detailView != null) control.Children.Add(control.detailView);
                    }
                    control.masterAdded = true;
                }
                else
                {
                    control.masterView.IsVisible = true;
                }
            }
            else // hide Master
            {
                if (control.MasterDestroyInvisible && control.masterAdded)
                {
                    control.Children.Remove(control.masterView);
                    control.masterAdded = false;
                }
                else if (control.masterView != null)
                {
                    control.masterView.IsVisible = false;
                }
            }
        }

        private static void SetOnMasterClick(MasterDetail control)
        {
            if (!control.toggleClickAssigned && !control.ToggleOnMasterClick)
            {
                control.toggleClickAssigned = true;

                //allow 2 level indentation
                Func<Element, bool> assignClick = (Element c) =>
                {
                    if (MasterDetail.GetToggleDetailOnClicked(c))
                    {
                        if (c is Button) (c as Button).Clicked += control.ToggleClicked;
                        else if (c is ExtendedLabel) (c as ExtendedLabel).Clicked += control.ToggleClicked;

                        return true;
                    }
                    return false;
                };

                foreach (var c in control.masterView.Children)
                {
                    if (c is Layout<View>)
                    {
                        foreach (var c2 in (c as Layout<View>).Children)
                        {
                            if (assignClick(c2)) break;
                        }
                    }
                    else if (assignClick(c)) break;
                }
            }
        }

        protected WeakReference<Layout> detailViewCached = null;

        private static void DetailIsVisibleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as MasterDetail;

            if (control.DetailTemplate == null) return;

            if ((bool)newValue)
            {
                if (control.detailView == null)
                {
                    Layout cached = null;
                    control.detailViewCached?.TryGetTarget(out cached);

                    if (cached != null)
                    {
                        control.detailView = cached;
                    }
                    else
                    {
                        control.detailView = control.ViewFromTemplate(control.DetailTemplate, control.DetailBindingContext ?? control.BindingContext);
                        if (control.detailViewCached == null) control.detailViewCached = new WeakReference<Layout>(control.detailView);
                        else control.detailViewCached.SetTarget(control.detailView);
                    }

                    //control.detailView.IsVisible = false;
                    control.Children.Add(control.detailView);
                    //control.detailView.IsVisible = true;
                    control.detailAdded = true;
                }
                else if (!control.detailAdded)
                {
                    control.Children.Add(control.detailView);
                    control.detailAdded = true;
                }
                else
                {
                    control.detailView.IsVisible = true;
                }
            }
            else // hide Detail
            {
                if (control.DetailDestroyInvisible && control.detailAdded)
                {
                    control.Children.Remove(control.detailView);
                    control.detailAdded = false;
                }
                else if (control.detailView != null)
                {
                    control.detailView.IsVisible = false;
                }
            }
        }

        private Layout ViewFromTemplate(DataTemplate template, object bindingContext = null)
        {
            View view = null;

            if (template != null)
            {
                view = template.CreateContent() as View;

                if (!(view is Layout)) throw new InvalidOperationException("MasterDetail.(Master,Detail)Template.DataTemplate must be a container element dervied from Xamarin.Forms.Layout");

                view.BindingContext = bindingContext;
            }

            return view as Layout;
        }

        public static readonly BindableProperty MasterDestroyInvisibleProperty =
            BindableProperty.Create(
                propertyName: nameof(MasterDestroyInvisible),
                returnType: typeof(bool),
                declaringType: typeof(MasterDetail),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay
            );

        /// <summary>
        /// Whether to remove child controls or simply hide them
        /// </summary>
        /// <value><c>true</c> removes controls from container; otherwise, <c>false</c> set's their IsVisible property to false.</value>
        public bool MasterDestroyInvisible
        {
            get { return (bool)GetValue(MasterDestroyInvisibleProperty); }
            set { SetValue(MasterDestroyInvisibleProperty, value); }
        }

        public static readonly BindableProperty DetailDestroyInvisibleProperty =
            BindableProperty.Create(
                propertyName: nameof(DetailDestroyInvisible),
                returnType: typeof(bool),
                declaringType: typeof(MasterDetail),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay
            );

        /// <summary>
        /// Whether to remove child controls or simply hide them
        /// </summary>
        /// <value><c>true</c> removes controls from container; otherwise, <c>false</c> set's their IsVisible property to false.</value>
        public bool DetailDestroyInvisible
        {
            get { return (bool)GetValue(DetailDestroyInvisibleProperty); }
            set { SetValue(DetailDestroyInvisibleProperty, value); }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent != null)
            {
                MasterIsVisibleChanged(this, null, IsMasterVisible);
                DetailIsVisibleChanged(this, null, IsDetailVisible);
            }
            else
            {
                Children.Clear();
                BindingContext = null;
            }
        }

        public static readonly BindableProperty ToggleDetailOnClickedProperty =
            BindableProperty.CreateAttached(
            "ToggleDetailOnClicked",
            typeof(bool),
            typeof(MasterDetail),
            false,
            propertyChanged: ToggleDetailOnClickedChanged
        );

        public static bool GetToggleDetailOnClicked(BindableObject view)
        {
            return (bool)view.GetValue(ToggleDetailOnClickedProperty);
        }

        public static void SetToggleDetailOnClicked(BindableObject view, bool value)
        {
            view.SetValue(ToggleDetailOnClickedProperty, value);
        }

        private static void ToggleDetailOnClickedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Button || bindable is ExtendedLabel)) throw new InvalidOperationException("MasterDetail.ToggleDetailOnClicked attached property can only be used with Xamarin.Formsn.Button or Saplin.CPDT.Control.ExtendedLabel or container containing those");
        }

        private static Dictionary<string, List<MasterDetail>> selectionGroups = new Dictionary<string, List<MasterDetail>>();

        public static readonly BindableProperty SelectionGroupProperty =
            BindableProperty.Create(
            propertyName: nameof(SelectionGroup),
            returnType: typeof(string),
            declaringType: typeof(MasterDetail),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: SelectionGroupChanged
        );


        /// <summary>
        /// If not empty/null then toggling on clcik (via ToggleDetailOnClicked attached property) alows only one MasterDetail control within SelectionGroup to be expanded
        /// </summary>
        public string SelectionGroup
        {
            get { return (string)GetValue(SelectionGroupProperty); }
            set { SetValue(SelectionGroupProperty, value); }
        }

        private static void SelectionGroupChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var selectionGroup = newValue as string;
            var selectionGroupOld = oldValue as string;
            var control = bindable as MasterDetail;

            if (!string.IsNullOrEmpty(selectionGroup))
            {
                if (!selectionGroups.ContainsKey(selectionGroup))
                {
                    selectionGroups.Add(selectionGroup, new List<MasterDetail>());
                }

                var list = selectionGroups[selectionGroup];

                if (!list.Contains(control)) list.Add(control);
            }
            else if (!string.IsNullOrEmpty(selectionGroupOld))
            {
                if (!selectionGroups.ContainsKey(selectionGroupOld))
                {
                    var list = selectionGroups[selectionGroupOld];

                    list.Remove(control);
                }
            }
        }
    }
}