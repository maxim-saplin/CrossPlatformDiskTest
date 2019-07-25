using Saplin.CPDT.UICore.Animations;
using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Saplin.CPDT.UICore
{
    public partial class MainPage : ContentPage
    {
        private int narrowWidth = 640;
        private bool alreadyShown = false;

        Title title;
        SimpleUI simpleUI, simpleUIHeader;
        AdvancedUI advancedUI;
        TestInProgress testInProgress;
        TestCompletion testCompletion;
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

                //if (ViewModelContainer.NavigationViewModel.IsSimpleUI)
                //{
                //    simpleUI = new SimpleUI();
                //    simpleUI.AdjustToWidth(Width);
                //}
                //else
                {
                    advancedUI = new AdvancedUI();
                    status = new Status();
                }
            });

            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

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

                    //AdaptLayoytToScreenWidth();

                    stackLayout.Children.Add(title);

                    //if (ViewModelContainer.NavigationViewModel.IsSimpleUI)
                    //{
                    //    absoluteLayout.Children.Add(simpleUI);
                    //}
                    //else
                    {
                        stackLayout.Children.Add(advancedUI);
                        stackLayout.Children.Add(status);
                    }

                    //Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
                    //        {
                    //            simpleUIHeader = new SimpleUI();

                    //            simpleUIHeader.SetBinding(IsVisibleProperty, new Binding("IsSimpleUIHeaderVisible", source: ViewModelContainer.NavigationViewModel));
                    //            AbsoluteLayout.SetLayoutFlags(simpleUIHeader, AbsoluteLayoutFlags.None);
                    //            simpleUIHeader.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    //            //simpleUIHeader.Padding = new Thickness(20,16,0,16);
                                                                
                    //            testInProgress = new TestInProgress();
                    //            testCompletion = new TestCompletion();
                    //            testSessionsPlaceholder = new TestSessionsPlaceholder();
                    //            popups = new Popups();
                    //            onlineDb = new OnlineDb();

                    //            if (ViewModelContainer.NavigationViewModel.IsSimpleUI)
                    //            {
                    //                advancedUI = new AdvancedUI();
                    //                status = new Status();

                    //                AdaptLayoytToScreenWidth();

                    //                Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
                    //                {
                    //                    stackLayout.Children.Add(simpleUIHeader);
                    //                    stackLayout.Children.Add(advancedUI);
                    //                    stackLayout.Children.Add(testInProgress);
                    //                    stackLayout.Children.Add(testSessionsPlaceholder);
                    //                    stackLayout.Children.Add(status);
                    //                    absoluteLayout.Children.Add(popups);
                    //                    absoluteLayout.Children.Add(testCompletion);

                    //                    foreach (var c in onlineDb.Children.ToArray())
                    //                    {
                    //                        absoluteLayout.Children.Add(c);
                    //                    }

                    //                    AdaptLayoytToScreenWidth();
                    //                    return false;

                    //                });
                    //            }
                    //            else
                    //            {
                    //                simpleUI = new SimpleUI();

                    //                AdaptLayoytToScreenWidth();

                    //                Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
                    //                {

                    //                    stackLayout.Children.Remove(status);
                    //                    stackLayout.Children.Add(simpleUIHeader);
                    //                    stackLayout.Children.Add(testInProgress);
                    //                    stackLayout.Children.Add(testSessionsPlaceholder);
                    //                    absoluteLayout.Children.Add(simpleUI);
                    //                    stackLayout.Children.Add(status);
                    //                    absoluteLayout.Children.Add(popups);
                    //                    absoluteLayout.Children.Add(testCompletion);

                    //                    foreach (var c in onlineDb.Children.ToArray())
                    //                    {
                    //                        absoluteLayout.Children.Add(c);
                    //                    }

                    //                    AdaptLayoytToScreenWidth();
                    //                    return false;

                    //                });
                    //            }
                    //            return false;
                    //        }
                    //    );
                }
            };
        }

        private Color backgroundColor = Color.Black;

        private void ApplyTheme()
        {
            if ((Xamarin.Forms.Application.Current as App).WhiteTheme)
            {
                var whiteTheme = new WhiteTheme();

                foreach (var key in whiteTheme.Keys)
                {
                    if (Xamarin.Forms.Application.Current.Resources.ContainsKey(key))
                        Xamarin.Forms.Application.Current.Resources[key] = whiteTheme[key];
                }

                backgroundColor = Color.White;
                //backgroundColor = Color.LightPink;
            }
        }

        private bool? alreadyNarrow;

        private void AdaptLayoytToScreenWidth()
        {
            var narrow = Width < narrowWidth;

            if (alreadyNarrow.HasValue)
            {
                if (alreadyNarrow.Value && narrow) return;
                if (!alreadyNarrow.Value && !narrow) return;
            }

            alreadyNarrow = narrow;

            simpleUI?.AdjustToWidth(Width);
            simpleUIHeader?.AdjustToWidth(Width);
            advancedUI?.AdaptLayoytToScreenWidth(narrow);
            testInProgress?.AdaptLayoytToScreenWidth(narrow);

            testSessionsPlaceholder?.AdaptLayoytToScreenWidth(narrow);
            MasterDetail.AsyncPreloadDetailsForSelectionGroup("testSessions");

            ViewModelContainer.NavigationViewModel.IsNarrowView = narrow;

            AdjustPopupsToWidth(narrow);
        }

        private static void AdjustPopupsToWidth(bool narrow)
        {
            //<Style x:Key="popUpContainer" TargetType="StackLayout">
            // ..
            //< OnPlatform x: TypeArguments = "Thickness" >  
            //< On Platform = "Android" Value = "10, 10, 10, 10" />     
            //< On Platform = "macOS, WPF" Value = "60, 60, 60, 60" />
            //</ OnPlatform >
            Xamarin.Forms.Application.Current.Resources["popUpContainer"] = narrow ?
                Xamarin.Forms.Application.Current.Resources["popUpContainerNarrow"]
                : Xamarin.Forms.Application.Current.Resources["popUpContainerWide"];
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
                        Device.BeginInvokeOnMainThread(() => { Xamarin.Forms.Application.Current.Quit(); }); ;
                    }
                );
            }
            else
            {
                Xamarin.Forms.Application.Current.Quit();
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