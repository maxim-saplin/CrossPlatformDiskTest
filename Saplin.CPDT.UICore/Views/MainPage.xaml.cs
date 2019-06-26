using Saplin.CPDT.UICore.Animations;
using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public partial class MainPage : ContentPage
    {
        private int narrowWidth = 640;
        private bool alreadyShown = false;

        Title title;
        SimpleUI simpaleUIStartPage, simpleUIHeader;
        AdvancedUI advancedUI;
        TestInProgress testInProgress;
        TestSessionsPlaceholder testSessionsPlaceholder;
        Status status;
        Popups popups;
        OnlineDb onlineDb;

        private Task task;

        public MainPage()
        {
            //ASYNC AND DEFFERED creation of controls for better start-up time

            task = Task.Run(() =>
            {
                ApplyTheme();

                title = new Title();
                title.QuitClicked += OnQuit;

                if (ViewModelContainer.NavigationViewModel.IsSimpleUI)
                {
                    simpaleUIStartPage = new SimpleUI();
                    simpaleUIStartPage.AdjustToWidth(Width);
                }
                else
                {
                    advancedUI = new AdvancedUI();
                    status = new Status();
                }
            });

            InitializeComponent();

            // DISPLAYING CONTROLS HERE
            SizeChanged += (s, e) =>
            {
                if (alreadyShown)
                    AdaptLayoytToScreenWidth();
                else
                {
                    this.BackgroundColor = backgroundColor;

                    alreadyShown = true;

                    task.Wait();

                    AdaptLayoytToScreenWidth();

                    stackLayout.Children.Add(title);

                    if (ViewModelContainer.NavigationViewModel.IsSimpleUI)
                    {
                        absoluteLayout.Children.Add(simpaleUIStartPage);
                    }
                    else
                    {
                        stackLayout.Children.Add(advancedUI);
                        stackLayout.Children.Add(status);
                    }

                    Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
                            {
                                simpleUIHeader = new SimpleUI();

                                simpleUIHeader.SetBinding(IsVisibleProperty, new Binding("IsSimpleUIHeaderVisible", source: ViewModelContainer.NavigationViewModel));
                                AbsoluteLayout.SetLayoutFlags(simpleUIHeader, AbsoluteLayoutFlags.None);
                                //simpleUIHeader.IsVisible = true;
                                simpleUIHeader.HorizontalOptions = LayoutOptions.CenterAndExpand;
                                simpleUIHeader.Padding = new Thickness(20,16,0,16);
                                                                
                                testInProgress = new TestInProgress();
                                testSessionsPlaceholder = new TestSessionsPlaceholder();
                                popups = new Popups();
                                onlineDb = new OnlineDb();

                                if (ViewModelContainer.NavigationViewModel.IsSimpleUI)
                                {
                                    advancedUI = new AdvancedUI();
                                    status = new Status();

                                    AdaptLayoytToScreenWidth();

                                    Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
                                    {
                                        stackLayout.Children.Add(simpleUIHeader);
                                        stackLayout.Children.Add(advancedUI);
                                        stackLayout.Children.Add(testInProgress);
                                        stackLayout.Children.Add(testSessionsPlaceholder);
                                        stackLayout.Children.Add(status);
                                        absoluteLayout.Children.Add(popups);

                                        foreach (var c in onlineDb.Children.ToArray())
                                        {
                                            absoluteLayout.Children.Add(c);
                                        }

                                        return false;

                                    });
                                }
                                else
                                {
                                    simpaleUIStartPage = new SimpleUI();

                                    AdaptLayoytToScreenWidth();

                                    Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
                                    {

                                        stackLayout.Children.Remove(status);
                                        stackLayout.Children.Add(simpleUIHeader);
                                        stackLayout.Children.Add(testInProgress);
                                        stackLayout.Children.Add(testSessionsPlaceholder);
                                        absoluteLayout.Children.Add(simpaleUIStartPage);
                                        stackLayout.Children.Add(status);
                                        absoluteLayout.Children.Add(popups);

                                        foreach (var c in onlineDb.Children.ToArray())
                                        {
                                            absoluteLayout.Children.Add(c);
                                        }
                                        return false;

                                    });
                                }
                                return false;
                            }
                        );

                }
            };
        }

        private Color backgroundColor = Color.Black;

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

                backgroundColor = Color.White;
            }
        }

        private void AdaptLayoytToScreenWidth()
        {
            var narrow = Width < narrowWidth;

            simpaleUIStartPage?.AdjustToWidth(Width);
            simpleUIHeader?.AdjustToWidth(Width);
            advancedUI?.AdaptLayoytToScreenWidth(narrow);
            testInProgress?.AdaptLayoytToScreenWidth(narrow);
            testSessionsPlaceholder?.AdaptLayoytToScreenWidth(narrow);

            ViewModelContainer.NavigationViewModel.IsNarrowView = narrow;
        }

        public void OnQuit(Object sender, EventArgs e)
        {
            CloseAplication();
        }

        public void CloseAplication()
        {
            title.QuitButton.IsVisible = false;
            title.QuitingButton.IsVisible = true;
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
                if (key == 'q' || key == 'в')
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