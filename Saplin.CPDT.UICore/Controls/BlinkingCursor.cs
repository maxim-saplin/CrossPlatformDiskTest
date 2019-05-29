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
        private const string empty = "";
        private const int refreshPeriodMs = 100;
        private const int blinkPeriod = 3;
        private const int keyPeriod = 9;
        private const int keyShortPeriod = 1;

        private static volatile int blinkCounter = 0;
        private static volatile int keyBlinkCounter = -1;

        private static bool timerStarted = false;
        private static string setText = "";
        private static string setTextWithCursor = cursor;

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

        public BlinkingCursor()
        {
            Text = "           "; // workaround for not growing label
        }

        private static void SetText(string text)
        {
            setText = prefix + text;
            setTextWithCursor = prefix + text + cursor;

            foreach(var c in controls)
            {
                c.Text = setText;
            }
        }

        private static void ShowTextWithCursor()
        {
            foreach (var c in controls)
            {
                c.Text = setTextWithCursor;
            }
        }

        private static void ShowTextWithoutCursor()
        {
            foreach (var c in controls)
            {
                c.Text = setText;
            }
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
                    Device.StartTimer(
                        new TimeSpan(0, 0, 0, 0, refreshPeriodMs),
                        () =>
                        {

                            if (controls.Count > 0)
                            {
                                if (queueSize == 0 && keyBlinkCounter == -1)
                                {
                                    if (blinkCounter % blinkPeriod == 0)
                                    {
                                        if (control.Text == setTextWithCursor) ShowTextWithoutCursor(); else ShowTextWithCursor();
//#if DEBUG
//                                        System.Diagnostics.Debug.WriteLine("BLINK control.Text: " + control.Text);
//#endif
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
//#if DEBUG                             
//                                        System.Diagnostics.Debug.WriteLine("SETKEY control.Text: " + control.Text);
//#endif
                                    }

                                    if (blinkCounter % 3 == 0)
                                    {
                                        if (control.Text == setTextWithCursor) ShowTextWithoutCursor(); else ShowTextWithCursor();
//#if DEBUG
//                                        System.Diagnostics.Debug.WriteLine("SETKEY BLINK control.Text: " + control.Text);
//#endif
                                    }
                                }

                                blinkCounter++;
                            }

                            return true;
                        }
                    );
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
    }
}
