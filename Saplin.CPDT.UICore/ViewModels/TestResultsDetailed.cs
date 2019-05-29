using Saplin.CPDT.UICore.Localization;
using Saplin.StorageSpeedMeter;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class TestResultsDetailed : BindableObject
    {
        public Saplin.StorageSpeedMeter.TestResults Result
        {
            get; private set;
        }

        public bool NotEnoughMemory { get; }

        public bool ShowAvg { get; }

        public bool ShowTimeSeries { get; }

        public bool ShowHistogram { get; }

        public bool ShowMin { get; }

        public bool ShowMax { get; }

        public bool ShowModeH { get; }

        public bool SmoothTimeSeries { get; }

        public string BulletPoint { get; set; }

        public string Time { get; }

        public static readonly BindableProperty MinAdjustedProperty = BindableProperty.Create(
            nameof(MinAdjusted),
            typeof(double),
            typeof(TestResultsDetailed),
            defaultBindingMode: BindingMode.TwoWay,
            coerceValue: MinAdjustedCoerce
        );

        private static object MinAdjustedCoerce(BindableObject bindable, object value)
        {
            var control = bindable as TestResultsDetailed;
            if ((double)value <= 0) return control.MinAdjusted;

            return value;
        }

        /// <summary>
        /// Min with tail excluded, updated by HistogramGraph control
        /// </summary>
        public double MinAdjusted
        {
            get { return (double)GetValue(MinAdjustedProperty); }
            set { SetValue(MinAdjustedProperty, value); }
        }

        public static readonly BindableProperty MaxAdjustedProperty = BindableProperty.Create(
            nameof(MaxAdjusted),
            typeof(double),
            typeof(TestResultsDetailed),
            defaultBindingMode: BindingMode.TwoWay,
            coerceValue: MaxAdjustedCoerce
        );

        private static object MaxAdjustedCoerce(BindableObject bindable, object value)
        {
            var control = bindable as TestResultsDetailed;
            if ((double)value <= 0) return control.MaxAdjusted;

            return value;
        }

        /// <summary>
        /// Max with tail excluded, updated by HistogramGraph control
        /// </summary>
        public double MaxAdjusted
        {
            get { return (double)GetValue(MaxAdjustedProperty); }
            set { SetValue(MaxAdjustedProperty, value); }
        }

        public static readonly BindableProperty ModeHProperty = BindableProperty.Create(
            nameof(ModeH),
            typeof(double),
            typeof(TestResultsDetailed),
            defaultBindingMode: BindingMode.TwoWay,
            coerceValue: ModeHCoerce
        );

        private static object ModeHCoerce(BindableObject bindable, object value)
        {
            var control = bindable as TestResultsDetailed;
            if ((double)value <= 0) return control.ModeH;

            return value;
        }

        /// <summary>
        /// Mode value (most frequent bin's middle point), updated by HistogramGraph control
        /// </summary>
        public double ModeH
        {
            get { return (double)GetValue(ModeHProperty); }
            set { SetValue(ModeHProperty, value); }
        }

        public static readonly BindableProperty ModeHPercentProperty = BindableProperty.Create(
            nameof(ModeH),
            typeof(int),
            typeof(TestResultsDetailed),
            defaultBindingMode: BindingMode.TwoWay,
            coerceValue: ModeHPercentCoerce
        );

        private static object ModeHPercentCoerce(BindableObject bindable, object value)
        {
            var control = bindable as TestResultsDetailed;
            if ((int)value <= 0) return control.ModeHPercent;

            return value;
        }

        /// <summary>
        /// Mode's percentage (most frequent bin's relative frequency), updated by HistogramGraph control
        /// </summary>
        public int ModeHPercent
        {
            get { return (int)GetValue(ModeHPercentProperty); }
            set { SetValue(ModeHPercentProperty, value); }
        }

        public TestResultsDetailed(Saplin.StorageSpeedMeter.TestResults tr,  bool notEnoughMem = false)
        {
            Result = tr;
            NotEnoughMemory = notEnoughMem;

            if (!notEnoughMem)
            {
                ShowAvg = ShowMin = ShowMax = true;

                ShowTimeSeries = tr.TestType != null
                    && (tr.TestType.IsSubclassOf(typeof(SequentialTest)) || tr.TestType == typeof(MemCopyTest));
                SmoothTimeSeries = tr.TestType != null && (tr.TestType == typeof(MemCopyTest));

                ShowHistogram = ShowModeH = !ShowTimeSeries;

                var s = tr.TotalTimeMs / 1000;
                var ss = ViewModelContainer.L11n._Locale == Locales.ru ? "с" : "s";
                var mm = ViewModelContainer.L11n._Locale == Locales.ru ? "м" : "m";

                Time = s / 60 > 0 ? s / 60 + mm : "";
                Time += s % 60 + ss;

                MinAdjusted = Result.Min;
                MaxAdjusted = Result.Max;
            }
            else
            {
                ShowAvg = ShowHistogram = ShowTimeSeries = ShowMin = ShowModeH = ShowMax = false;
            }

        }

    }
}
