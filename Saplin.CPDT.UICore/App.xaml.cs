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
#if DEBUG
        private Stopwatch sw= new Stopwatch();
        private StringBuilder sb = new StringBuilder();
#endif
        private Task task;

        public App ()
		{
#if DEBUG
            sw.Start();
#endif

            task = Task.Run(() =>
            {
                InitializeComponent();
#if DEBUG
                sb.AppendLine("InitializeComponent " + sw.ElapsedMilliseconds);
#endif
                page = new MainPage(); sb.AppendLine("new MainPage() " + sw.ElapsedMilliseconds);
            });
#if DEBUG
            sb.AppendLine("Task.Run " + sw.ElapsedMilliseconds);
#endif
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
#if DEBUG
            sb.AppendLine("Task.Wait " + sw.ElapsedMilliseconds);
#endif

            MainPage = page;
#if DEBUG
            sb.AppendLine("MainPage = page " + sw.ElapsedMilliseconds);
            System.Diagnostics.Debug.WriteLine(sb);
#endif
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
