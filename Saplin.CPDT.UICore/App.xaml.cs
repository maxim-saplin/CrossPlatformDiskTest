using System;
using System.Threading.Tasks;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Saplin.CPDT.UICore
{
	public partial class App : Application
	{
        Page page = null;

        private Task task = null;

        public App (bool sync = false)
		{

            Action init = () =>
            {
                InitializeComponent();
                ViewModelContainer.Init();
                page = new MainPage();
            };

            if (!sync) task = Task.Run(init);
            else
            {
                init();
                MainPage = page;
            }
        }

        public bool WhiteTheme
        {
            get
            {
                return ViewModelContainer.OptionsViewModel.WhiteThemeBool;
            }
        }

		protected override void OnStart ()
		{
            if (task != null)
            {
                task.Wait();
                MainPage = page;
            }
        }

		protected override void OnSleep ()
		{
            if (Device.RuntimePlatform == Device.Android)
                ViewModelContainer.DriveTestViewModel.BreakTest.Execute(null);
            if (Device.RuntimePlatform == Device.WPF) 
                (MainPage as MainPage).CloseAplication();
        }

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
