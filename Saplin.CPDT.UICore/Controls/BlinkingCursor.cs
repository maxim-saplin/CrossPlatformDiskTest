using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Controls
{
    public class BlinkingCursor : Label
    {
        private const int queueMaxSize = 3;
        private static int queuePointer = -1;
        private static int queueSize = 0;

        private static string[] keys = new string[queueMaxSize];

        public BlinkingCursor()
        {
            WidthRequest = 40;
            MinimumWidthRequest = 40;
            Text = "     "; // workaround for not growing label
            ShowPrefix = true;
        }

        private static string GetKey()
        {
            if (queueSize == 0) return null;


            var pointer = queuePointer - queueSize + 1;
            if (pointer < 0) pointer += queueMaxSize;

            queueSize--;

            if (queuePointer < 0) queuePointer = queueMaxSize - 1;

//#if DEBUG
//            System.Diagnostics.Debug.WriteLine("GetKey: " + keys[pointer]);
//#endif

            return keys[pointer];
        }

        public static void AddBlinkKey(char key, SysKeys? sysKey)
        {
//#if DEBUG
//            System.Diagnostics.Debug.WriteLine("AddBlinkKey: " + key);
//#endif
            queueSize++;
            queuePointer++;

            if (queueSize > queueMaxSize) queueSize = queueMaxSize;
            if (queuePointer >= queueMaxSize) queuePointer = 0;

            keys[queuePointer] = sysKey == null ? key.ToString() : sysKey.ToString();
        }

        private bool blinkCursor;

        private const string cursor = "_";
        private const string prefix = "\\> ";
        private const int refreshPeriodMs = 100;
        private const int blinkPeriod = 3;
        private const int keyPeriod = 9;
        private const int keyShortPeriod = 1;

        private static volatile int blinkCounter = 0;
        private static volatile int keyBlinkCounter = -1;

        private static bool timerStarted = false;
        private static string textWithPrefixWithoutCursor = "";
        private static string textWithPrefixWithCursor = "";
        private static string textWithoutPrefixWithoutCursor = "";
        private static string textWithoutPrefixWithCursor = "";

        private static List<BlinkingCursor> controls = new List<BlinkingCursor>();

        public static readonly BindableProperty BlinkCursorProperty =
            BindableProperty.Create(
                propertyName: nameof(BlinkCursor),
                returnType: typeof(bool),
                declaringType: typeof(ExtendedLabel),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: BlinkCursorChanged
             );

        private static void SetText(string text)
        {
            textWithPrefixWithoutCursor = prefix + text;
            textWithPrefixWithCursor = prefix + text + cursor;
            textWithoutPrefixWithoutCursor = text;
            textWithoutPrefixWithCursor = text + cursor;

            foreach (var c in controls)
            {
                c.Text = c.ShowPrefix ? textWithPrefixWithoutCursor : textWithoutPrefixWithoutCursor;
            }
        }

        private static void ShowTextWithCursor()
        {
            foreach (var c in controls)
            {
                c.Text = c.ShowPrefix ? textWithPrefixWithCursor : textWithoutPrefixWithCursor;
            }
        }

        private static void ShowTextWithoutCursor()
        {
            foreach (var c in controls)
            {
                c.Text = c.ShowPrefix ? textWithPrefixWithoutCursor : textWithoutPrefixWithoutCursor;
            }
        }

        protected override void InvalidateMeasure()
        {
            if (!timerStarted) base.InvalidateMeasure();
        }

        private static void BlinkCursorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as BlinkingCursor;

            control.blinkCursor = (bool)newValue;

            if (control.blinkCursor)
            {
                controls.Add(control);
                if (!timerStarted)
                {
                    var period = keyPeriod;
                    SetText("");

                    timerStarted = true;
                    Func<bool> callback = () =>
                    {

                        if (controls.Count > 0)
                        {
                            if (queueSize == 0 && keyBlinkCounter == -1)
                            {
                                if (blinkCounter % blinkPeriod == 0)
                                {
                                    if (control.Text == textWithPrefixWithCursor || control.Text == textWithoutPrefixWithCursor) ShowTextWithoutCursor(); else ShowTextWithCursor();
                                }
                            }
                            else
                            {
                                if (queueSize > 0) period = keyShortPeriod; else period = keyPeriod;

                                if (queueSize == 0 && keyBlinkCounter != -1 && (blinkCounter - keyBlinkCounter) % keyPeriod == 0)
                                {
                                    keyBlinkCounter = -1;
                                    SetText("");
                                }

                                if (keyBlinkCounter == -1 && queueSize > 0)
                                {
                                    keyBlinkCounter = blinkCounter;
                                }

                                if (queueSize != 0 && (blinkCounter - keyBlinkCounter) % period == 0)
                                {
                                    SetText(GetKey());
                                }

                                if (blinkCounter % 3 == 0)
                                {
                                    if (control.Text == textWithPrefixWithCursor || control.Text == textWithoutPrefixWithCursor) ShowTextWithoutCursor(); else ShowTextWithCursor();
                                }
                            }

                            blinkCounter++;
                        }

                        return true;
                    };

                    if (Device.RuntimePlatform == Device.WPF) // WPF requires invoking timers on main thread
                        Device.BeginInvokeOnMainThread( () => Device.StartTimer(new TimeSpan(0, 0, 0, 0, refreshPeriodMs), callback));
                    else Device.StartTimer(new TimeSpan(0, 0, 0, 0, refreshPeriodMs), callback);
                }
            }
            else
            {
                controls.Remove(control);
                control.Text = "";
            }
        }

        public bool BlinkCursor //◴◵◶◷🔥
        {
            get
            {
                return (bool)GetValue(BlinkCursorProperty);
            }
            set
            {
                SetValue(BlinkCursorProperty, value);
                blinkCursor = value;
            }
        }

        public bool ShowPrefix { get; set; }
    }
}
