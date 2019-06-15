using System.Diagnostics;
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

        private Task task, task2;

        public App ()
		{

            task = Task.Run(() =>
            {
                InitializeComponent();
                page = new MainPage();
            });

            //task2 = Task.Run(() =>
            //{
            //page = new MainPage();
            //});

            //task.Wait();
            //task2.Wait();
            //MainPage = page;

            //var sw = new Stopwatch();
            //sw.Start();
            //task = Task.Run(() =>
            //{
            //InitializeComponent();
            //System.Diagnostics.Trace.WriteLine("TRC:Init" + sw.ElapsedMilliseconds);
            //});

            //page = new MainPage();
            //System.Diagnostics.Trace.WriteLine("TRC:NewPg" + sw.ElapsedMilliseconds);
            //MainPage = page;
            //System.Diagnostics.Trace.WriteLine("TRC:SetPg" + sw.ElapsedMilliseconds);
            //sw.Stop();
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
