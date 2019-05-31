using System.Diagnostics;
using System.Text;
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
        private Stopwatch sw;
        private StringBuilder sb;
        private Task task;

        public App ()
		{
            sw = new Stopwatch();
            sb = new StringBuilder();

            sw.Start();

            task = Task.Run(() =>
            {
                InitializeComponent();
                sb.AppendLine("InitializeComponent " + sw.ElapsedMilliseconds);
                page = new MainPage(); sb.AppendLine("new MainPage() " + sw.ElapsedMilliseconds);
            });

            sb.AppendLine("Task.Run " + sw.ElapsedMilliseconds);
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
            sb.AppendLine("Task.Wait " + sw.ElapsedMilliseconds);

            MainPage = page;
            sb.AppendLine("MainPage = page " + sw.ElapsedMilliseconds);
            System.Diagnostics.Debug.WriteLine(sb);
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
