using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Saplin.CPDT.UICore
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
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
