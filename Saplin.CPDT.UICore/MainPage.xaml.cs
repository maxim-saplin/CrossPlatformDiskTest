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
        public MainPage()
        {
            InitializeComponent();

            AdaptLayoytToScreenWidth();

            bitSystem.Text += Environment.Is64BitProcess ? " 64bit" : " 32bit";
        }

        private void AdaptLayoytToScreenWidth()
        {


            var testResultsNarrow = false;
            var testSessionsNarrow = false;
            var narrowWidth = 640;

            SizeChanged += (s, e) =>
            {
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
            };

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

        // TODO - change to events
        public void OnKeyPressed(char key, SysKeys? sysKey)
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