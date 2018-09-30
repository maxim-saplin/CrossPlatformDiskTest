using Saplin.CPDT.UICore.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.Animations
{
    public abstract class AnimationBase : View, IDisposable
    {
        private static Collection<WeakReference> allAnimations = new Collection<WeakReference>();
        private static int counter = 0;

        private static void AddAnimation(AnimationBase animation)
        {
            if (counter % 50 == 0)
            {
                var toBeDeleted = new Collection<WeakReference>();
                foreach (var i in allAnimations)
                {
                    if (!i.IsAlive) toBeDeleted.Add(i);
                }
                foreach (var i in toBeDeleted)
                {
                    allAnimations.Remove(i);
                }    
            }

            counter++;
            allAnimations.Add(new WeakReference(animation));
        }

        public static void DisposeAllAnimations()
        {
            foreach (var i in allAnimations)
                (i.Target as IDisposable)?.Dispose();
        }

        protected AnimationBase()
        {
            AnimationBase.AddAnimation(this);
        }

        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(AnimationBase),
            null,
            BindingMode.OneWay,
            propertyChanged: TargetChanged);

        protected VisualElement target; // shortcut to avoid overhead of calling Target bindable property

        public VisualElement Target
        {
            get { return (VisualElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value);}
        }

        protected abstract Task Animate();

        private CancellationTokenSource cancellationTokenSource;

        private async void StartInfiniteAnimation()
        {
            CancelAnimation();

            cancellationTokenSource = new CancellationTokenSource();
            var ct = cancellationTokenSource.Token;

            while (!ct.IsCancellationRequested)
                try
                {
                    await Animate();
                }
                catch { }; // null, animation canceled midway
        }

        private bool CheckAnimAlowed()
        {
            return !(cancellationTokenSource != null && cancellationTokenSource.Token.IsCancellationRequested);
        }

        protected Task FadeTo(double opacity, uint lenght = 250, Easing easing = null)
        {
            if (CheckAnimAlowed())
                return target.FadeTo(opacity, lenght, easing);
            return null;
        }

        protected Task ScaleTo(double scale, uint lenght = 250, Easing easing = null)
        {
            if (CheckAnimAlowed())
                return target.ScaleTo(scale, lenght, easing);
            return null;
        }

        protected Task RelScaleTo(double scale, uint lenght = 250, Easing easing = null)
        {
            if (CheckAnimAlowed())
                return target.RelScaleTo(scale, lenght, easing);
            return null;
        }

        protected Task TranslateTo(double x, double y, uint lenght = 250, Easing easing = null)
        {
            if (CheckAnimAlowed())
                return target.TranslateTo(x, y, lenght, easing);
            return null;
        }

        const int fps = 32;

        protected Task HeightRequestTo(double height, bool maxOut, uint lenght = 250)
        {
            if (CheckAnimAlowed())
            {
                var tcs = new TaskCompletionSource<bool>();

                var counter = 0;
                var increments = (int)((double)lenght / 1000 * fps);
                var heightIncr = (height - target.Height) / increments;

                if (target.HeightRequest == -1) target.HeightRequest = target.Height;

                Device.StartTimer(
                    TimeSpan.FromMilliseconds(lenght/increments),
                    () =>
                    {
                        while (counter < increments)
                        {
                            counter++;
                            target.HeightRequest = Math.Max(target.HeightRequest + heightIncr,0);
                            return true;
                        }

                        if (maxOut) target.HeightRequest = -1;
                        tcs.TrySetResult(true);
                        return false;
                    }
                );

                return tcs.Task;
            }
            return null;
        }

        private void CancelAnimation()
        {
            cancellationTokenSource?.Cancel();
            ViewExtensions.CancelAnimations(target);
        }

        private static async void TargetChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AnimationBase;
            control.target = newValue as VisualElement;

            if (newValue != null)
            {
                control.target.PropertyChanged += async (s, e) =>
                {
                    if (e.PropertyName == "IsEnabled" || e.PropertyName == "IsVisible")
                    {
                        if (control.target.IsEnabled && control.target.IsVisible && control.Infinite)
                            control.StartInfiniteAnimation();

                        else control.CancelAnimation();
                    }
                };

                if ((control.target).IsEnabled && (control.target).IsVisible && control.Infinite)
                    control.StartInfiniteAnimation();
            }
            else control.CancelAnimation();
        }

        public static readonly BindableProperty InfiniteProperty = BindableProperty.Create(
            nameof(Infinite),
            typeof(bool),
            typeof(AnimationBase),
            false,
            BindingMode.OneWay);

        public bool Infinite
        {
            get { return (bool)GetValue(InfiniteProperty); }
            set { SetValue(InfiniteProperty, value); }
        }

        public static readonly BindableProperty TriggerProperty = BindableProperty.Create(
            nameof(Trigger),
            typeof(bool),
            typeof(AnimationBase),
            false,
            BindingMode.OneWay,
            propertyChanged: TriggerChanged
        );

        protected bool? previousTrigger = null;

        private static async void TriggerChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AnimationBase;
            var value = (bool)newValue;

             if (value != control.previousTrigger)
              {
                    control.previousTrigger = value;
                    await control.Animate();
             }
        }

        public bool Trigger
        {
            get { return (bool)GetValue(TriggerProperty); }
            set { SetValue(TriggerProperty, value); }
        }

        public static readonly BindableProperty OnClickOfProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(AnimationBase),
            null,
            BindingMode.OneWay,
            propertyChanged: OnClickOfChanged);

        public VisualElement OnClickOf
        {
            get { return (VisualElement)GetValue(OnClickOfProperty); }
            set { SetValue(OnClickOfProperty, value); }
        }

        private void OnClick(object sender, EventArgs e)
        {
            Animate();
        }

        private static void OnClickOfChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AnimationBase;
            var clickControl = newValue as VisualElement;
            var clickControlOld = oldValue as VisualElement;

            if (clickControl != null)
            {
                if (!( (clickControl is ExtendedLabel) || (clickControl is Button) )) throw new InvalidOperationException("AnimationBase.OnClickOf binding property can only be ExtendedLabel or Button instance");

                if (clickControl is ExtendedLabel) (clickControl as ExtendedLabel).Clicked += control.OnClick;
                else (clickControl as Button).Clicked += control.OnClick;
            }

            if (clickControlOld != null)
            {
                if (clickControlOld is ExtendedLabel) (clickControlOld as ExtendedLabel).Clicked -= control.OnClick;
                else (clickControlOld as Button).Clicked -= control.OnClick;
            }
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                CancelAnimation();
            }

            disposed = true;
        }
    }
}
