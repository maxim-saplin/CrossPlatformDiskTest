using Saplin.CPDT.UICore.Animations;
using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public partial class MainPage : ContentPage
    {
        private bool testResultsNarrow = false;
        private bool testSessionsNarrow =false;
        private int narrowWidth = 640;
        private bool alreadyShown = false;

        public MainPage()
        {
            ApplyTheme();

            InitializeComponent();

            bitSystem.Text += Environment.Is64BitProcess ? " 64bit" : " 32bit";

            SizeChanged += (s, e) =>
            {
                if (!alreadyShown)
                {
                    alreadyShown = true;
                    ViewModelContainer.ResultsDbViewModel.BindWebView(webView);
                    absoluteLayout.Children.Add(new Popups());
                }

                AdaptLayoytToScreenWidth();
            };
        }

        private void ApplyTheme()
        {
            if ((Application.Current as App).WhiteTheme)
            {
                var whiteTheme = new WhiteTheme();

                foreach (var key in whiteTheme.Keys)
                {
                    if (Application.Current.Resources.ContainsKey(key))
                        Application.Current.Resources[key] = whiteTheme[key];
                }
            }

        }

        private void AdaptLayoytToScreenWidth()
        {
            buttons.AdaptLayoytToScreenWidth(Width < narrowWidth);

            if (Width < narrowWidth)
            {
                if (!testResultsNarrow)
                {
                    testResultsNarrow = true;

                    var tr = new TestResultsNarrow()
                    {
                        BindingContext = ViewModelContainer.DriveTestViewModel,
                        IsFooterVisible = true,
                        ShowFooterIfEmptyItems = true
                    };

                    tr.SetBinding(GridRepeater.ItemsSourceProperty, nameof(ViewModelContainer.DriveTestViewModel.TestResults));

                    testResultsPlaceholder.Children.Clear();
                    testResultsPlaceholder.Children.Add(tr);
                }
                if (!testSessionsNarrow)
                {
                    testSessionsNarrow = true;

                    var ts = new TestSessionsNarrow();

                    testSessionsPlaceholder.Children.Clear();
                    testSessionsPlaceholder.Children.Add(ts);
                }
            }
            else if (Width >= narrowWidth)
            {
                if (testResultsNarrow)
                {
                    testResultsNarrow = false;

                    var tr = new TestResults()
                    {
                        BindingContext = ViewModelContainer.DriveTestViewModel,
                        IsFooterVisible = true,
                        ShowFooterIfEmptyItems = true
                    };

                    tr.SetBinding(GridRepeater.ItemsSourceProperty, nameof(ViewModelContainer.DriveTestViewModel.TestResults));

                    testResultsPlaceholder.Children.Clear();
                    testResultsPlaceholder.Children.Add(tr);
                }
                if (testSessionsNarrow)
                {
                    testSessionsNarrow = false;

                    var ts = new TestSessions();

                    testSessionsPlaceholder.Children.Clear();
                    testSessionsPlaceholder.Children.Add(ts);
                }
            }
        }

        public void OnQuit(Object sender, EventArgs e)
        {
            CloseAplication();
        }

        public void CloseAplication()
        {
            quitButton.IsVisible = false;
            quititingButton.IsVisible = true;
            ViewModelContainer.DriveTestViewModel.BreakTest.Execute(null);
            AnimationBase.DisposeAllAnimations(); // dispose off all animation controls in order to avoid unhandled exception on app close in WPF (if any animation is running on close) 
            if (ViewModelContainer.DriveTestViewModel.TestStarted)
            {

                Task.Run(() =>
                    {
                        var wait = new SpinWait();

                        while (ViewModelContainer.DriveTestViewModel.TestStarted) wait.SpinOnce();
                    }
                ).ContinueWith((t) =>
                    {
                        Thread.Sleep(1500);  // if there's any animation in-progress, give it time to complete
                        Device.BeginInvokeOnMainThread(() => { Application.Current.Quit(); }); ;
                    }
                );
            }
            else
            {
                Application.Current.Quit();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (ViewModelContainer.ResultsDbViewModel.IsVisible) ViewModelContainer.ResultsDbViewModel.IsVisible = false;
            else OnKeyPressed((char)27, SysKeys.Esc);

            return true;
        }

        // TODO - change to events
        public void OnKeyPressed(char key, SysKeys? sysKey)
        {
            if (!ViewModelContainer.ResultsDbViewModel.IsVisible)
            {
                if (key == 'q')
                {
                    CloseAplication();
                }
                else if (sysKey != null)
                {
                    KeyPress.FindAndExecuteCommand(sysKey.Value);
                }
                else
                {
                    KeyPress.FindAndExecuteCommand(key);

                }

                BlinkingCursor.AddBlinkKey(key, sysKey);
            }
        }
    }
}