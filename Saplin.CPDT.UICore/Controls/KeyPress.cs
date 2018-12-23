using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    /// <summary>
    /// Allows to attach key shortcut for Button or ExtendedLabel, store all short-cuts for controls and upon calling FindAndExecuteCommand method executed command of control corresponding to the shortcut
    /// </summary>
    public static class KeyPress
    {
        private class ExtendedBindable
        {
            public BindableObject bindable;
            public string[] keys;
            public List<VisualElement> parents;

            public bool AnyParentInvisible
            {
                get
                {
                    if (parents == null) parents = EnumAllParents(bindable as VisualElement);

                    return parents.Count == 0
                           ? false
                           : parents.Any(p => !p.IsVisible);
                }
            }

            public bool IsParent(Layout layout)
            {
                return parents.Any(p => p == layout);
            }
        }

        public static List<VisualElement> EnumAllParents(this VisualElement element)
        {
            var parents = new List<VisualElement>();
            var i = 0;
            const int maxParents = 24;
            var parent = element.Parent as VisualElement;

            while (i < maxParents)
            {
                if (parent == null) break;
                else
                {
                    parents.Add(parent);
                    parent = parent.Parent as VisualElement;
                }
                i++;
            }

            return parents;
        }

        private static List<ExtendedBindable> attachedControls = new List<ExtendedBindable>();
        private static Stack<Layout> modalParents = new Stack<Layout>();

        public static IEnumerable<BindableObject> AttachedControls
        {
            get { return attachedControls.Select<ExtendedBindable, BindableObject>(eb => eb.bindable); }
        }

        private static string[] GetCommandKeysFromText(BindableObject view)
        {
            if (!(view is Button || view is ExtendedLabel)) return null;

            var text = KeyPress.GetCommandText(view);

            if (string.IsNullOrEmpty(text)) text = view is Button ? (view as Button).Text : (view as ExtendedLabel).Text;

            if (!string.IsNullOrEmpty(text))
            {

                var firstPos = text.IndexOf('[');
                var secondPos = text.IndexOf(']');

                if (secondPos - firstPos - 1 <= 0) return null;

                text = text.Trim().ToLower().Substring(firstPos + 1, secondPos - firstPos - 1);

                if (text.Contains(","))
                {
                    var texts = text.Split(',');

                    for (int i = 0; i < texts.Length; i++)
                        texts[i] = texts[i].Trim();

                    return texts;
                }

                return new string[] { text };
            }

            return null;
        }

        public static void FindAndExecuteCommand(char key)
        {
            FindAndExecuteCommand(key.ToString().ToLower());
        }

        public static void FindAndExecuteCommand(SysKeys key)
        {
            FindAndExecuteCommand(key.ToString().ToLower());
        }

        public static void FindAndExecuteCommand(string key)
        {
            for (int i = 0; i < attachedControls.Count; i++)
            {
                for (int k = 0; k < attachedControls[i].keys.Length; k++)
                {
                    if (attachedControls[i].keys[k] == key)
                    {
                        var visibleEnabled = (attachedControls[i].bindable as VisualElement).IsEnabled
                                             && (attachedControls[i].bindable as VisualElement).IsVisible
                                             && !attachedControls[i].AnyParentInvisible;

                        if (visibleEnabled && modalParents.Count > 0) visibleEnabled = attachedControls[i].IsParent(modalParents.Peek());

                        if (visibleEnabled)
                        {
                            var clickControl = KeyPress.GetClickControl(attachedControls[i].bindable);

                            if (clickControl != null)
                            {
                                if (clickControl is ExtendedLabel)
                                    (clickControl as ExtendedLabel).DoClick();
                            }
                            else
                            {
                                if (attachedControls[i].bindable is Button)
                                {

                                    (attachedControls[i].bindable as Button)?.Command?.Execute((attachedControls[i].bindable as Button).CommandParameter);
                                }
                                else if (attachedControls[i].bindable is ExtendedLabel)
                                {
                                    (attachedControls[i].bindable as ExtendedLabel)?.Command?.Execute((attachedControls[i].bindable as ExtendedLabel).CommandParameter);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// If set to not empty string, than Text or FormattedText (if HighlightKeys is true and HighlightStyle is set) is set to this value and key presses get intercepted to issue commands
        /// </summary>
        public static readonly BindableProperty CommandTextProperty =
            BindableProperty.CreateAttached(
                "CommandText",
                typeof(string),
                typeof(KeyPress),
                null,
                propertyChanged: CommandTextPropertyChanged
            );

        public static string GetCommandText(BindableObject view)
        {
            return (string)view.GetValue(CommandTextProperty);
        }

        public static void SetCommandText(BindableObject view, string value)
        {
            view.SetValue(CommandTextProperty, value);
        }

        private static void CommandTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Button || bindable is ExtendedLabel)
            {
                if (KeyPress.GetCommandOnKeyPress(bindable)) throw new InvalidOperationException("Can't simultaneously set KeyPress.CommandOnKeyPress and KeyPress.CommandText attached properties");

                var text = newValue as string;

                if (!string.IsNullOrEmpty(oldValue as string) && (newValue as string == null))
                {
                    DeleteControl(bindable);
                }
                else if (!string.IsNullOrEmpty(text))
                {
                    if (bindable is Button) (bindable as Button).Text = text; else (bindable as ExtendedLabel).Text = text;
                    ReRegisterControl(bindable);
                }
            }
        }

        public static readonly BindableProperty CommandOnKeyPressProperty =
            BindableProperty.CreateAttached(
                "CommandOnKeyPress",
                typeof(bool),
                typeof(KeyPress),
                false,
                propertyChanged: CommandOnKeyPressPropertyChanged
            );

        public static bool GetCommandOnKeyPress(BindableObject view)
        {
            return (bool)view.GetValue(CommandOnKeyPressProperty);
        }

        public static void SetCommandOnKeyPress(BindableObject view, bool value)
        {
            view.SetValue(CommandOnKeyPressProperty, value);
        }

        private static void CommandOnKeyPressPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Button || bindable is ExtendedLabel)
            {
                if (!string.IsNullOrEmpty(KeyPress.GetCommandText(bindable))) throw new InvalidOperationException("Can't simultaneously set KeyPress.CommandOnKeyPress and KeyPress.CommandText attached properties");

                if (((bool)oldValue == true) && ((bool)newValue == false))
                {
                    DeleteControl(bindable);
                }
                else if ((bool)newValue)
                {
                    ReRegisterControl(bindable);

                    bindable.PropertyChanged += (s, e) =>
                    {
                        if (e.PropertyName == "Text")
                        {
                            ReRegisterControl(bindable);
                        }
                    };
                }
            }
        }

        private static void ReRegisterControl(BindableObject bindable)
        {
            CleanupControls();

            var texts = GetCommandKeysFromText(bindable);

            if (texts != null)
            {
                ReAddControl(bindable, texts);

                var label = bindable as ExtendedLabel;

                if (label != null && KeyPress.GetHighlightKeys(label) && KeyPress.HighlightStyle != null && !string.IsNullOrEmpty(KeyPress.GetCommandText(label)))
                {
                    var text = KeyPress.GetCommandText(label);
                    var t0 = text.IndexOf('[') != 0 ?
                                  text.Substring(0, text.IndexOf('[')) :
                                  string.Empty;
                    var t1 = text.Substring(text.IndexOf('['), text.IndexOf(']') - t0.Length + 1);
                    var t2 = text.IndexOf(']') < text.Length ?
                                  text.Substring(text.IndexOf(']') + 1, text.Length - t1.Length - t0.Length) :
                                  string.Empty;

                    var ft = new FormattedString();
                    if (!string.IsNullOrEmpty(t0)) ft.Spans.Add(new Span() { Text = t0 });
                    ft.Spans.Add(new Span() { Text = t1, Style = HighlightStyle });
                    if (!string.IsNullOrEmpty(t2)) ft.Spans.Add(new Span() { Text = t2 });
                    label.FormattedText = ft;
                }
            }
            else
            {
                DeleteControl(bindable);
            }
        }

        private static void CleanupControls()
        {
            foreach (var c in attachedControls.Where(ctrl => (ctrl.bindable as VisualElement).Parent == null).ToArray())
            {
                DeleteControl(c.bindable);
            }
        }

        private static void ReAddControl(BindableObject bindable, string[] texts)
        {
            DeleteControl(bindable);
            attachedControls.Add(
                new ExtendedBindable
                {
                    bindable = bindable,
                    keys = texts,
                    parents = null
                }
            );
        }

        private static void DeleteControl(BindableObject bindable)
        {
            if (attachedControls.Count == 0) return;

            int i;

            for (i = 0; i < attachedControls.Count; i++)
                if (attachedControls[i].bindable == bindable) break;

            if (i < attachedControls.Count) attachedControls.RemoveAt(i);
        }

        /// <summary>
        /// If set to true when the control becomes visible keyboard shortcuts go only to controls which are children (inlcuding indirect) of this control
        /// </summary>
        public static readonly BindableProperty ModalParentExclusiveHookProperty =
            BindableProperty.CreateAttached(
                "ModalParentExclusiveHook",
                typeof(bool),
                typeof(KeyPress),
                false,
                propertyChanged: ModalParentExclusiveHookPropertyChanged
            );

        public static bool GetModalParentExclusiveHook(BindableObject view)
        {
            return (bool)view.GetValue(ModalParentExclusiveHookProperty);
        }

        public static void SetModalParentExclusiveHook(BindableObject view, bool value)
        {
            view.SetValue(ModalParentExclusiveHookProperty, value);
        }

        private static void ModalParentExclusiveHookPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Layout)
            {
                PropertyChangedEventHandler changedHandler = (s, e) =>
                {
                    if (e.PropertyName == "IsVisible")
                    {
                        if (((Layout)bindable).IsVisible)
                        {
                            modalParents.Push((Layout)bindable);
                        }
                        else
                        {
                            var flag = false;

                            while (!flag && modalParents.Count > 0)
                            {
                                var p = modalParents.Pop();

                                flag = p == bindable;
                            }
                        }
                    }
                };

                if (((bool)oldValue == true) && ((bool)newValue == false))
                {
                    bindable.PropertyChanged -= changedHandler;
                }
                else if ((bool)newValue)
                {
                    bindable.PropertyChanged += changedHandler;
                }
            }
        }

        /// <summary>
        /// Requires x:Key="HighlightKeys" Style in App.xaml to apply different text formatting to Shortcut substring, e.g.
        ///    <Style x:Key="HighlightKeys" TargetType="Span">
        ///        <Setter Property = "TextColor" Value="White" />
        ///        <Setter Property = "Font" Value="Courier New, 20"/>
        ///    </Style>
        /// </summary>
        public static readonly BindableProperty HighlightKeysProperty =
            BindableProperty.CreateAttached(
                "HighlightKeys",
                typeof(bool),
                typeof(KeyPress),
                true
            );

        public static bool GetHighlightKeys(BindableObject view)
        {
            return (bool)view.GetValue(HighlightKeysProperty);
        }

        public static void SetHighlightKeys(BindableObject view, bool value)
        {
            view.SetValue(HighlightKeysProperty, value);
        }

        //private static Style highlightStyle;

        private static Style HighlightStyle
        {
            get
            {
                if (!Application.Current.Resources.ContainsKey("HighlightKeys")) return null;
                return Application.Current.Resources["HighlightKeys"] as Style;
            }
        }

        public static readonly BindableProperty ClickControlProperty =
            BindableProperty.CreateAttached(
                "ClickControl",
                typeof(ExtendedLabel),
                typeof(KeyPress),
                null,
                propertyChanged: ClickControlPropertyChanged
            );

        public static ExtendedLabel GetClickControl(BindableObject view)
        {
            return (ExtendedLabel)view.GetValue(ClickControlProperty);
        }

        public static void SeClickControl(BindableObject view, bool value)
        {
            view.SetValue(ClickControlProperty, value);
        }

        private static void ClickControlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(newValue is ExtendedLabel)) throw new InvalidOperationException("KeyPress.ClickControl attached property can only be ExtendedLabel instance");
        }
    }
}
