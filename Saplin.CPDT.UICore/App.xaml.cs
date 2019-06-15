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

        private Task task;

        public App ()
		{

            task = Task.Run(() =>
            {
                InitializeComponent();
                ViewModelContainer.Init();
                page = new MainPage();
            });
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
            task.Wait();

            MainPage = page;
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
