using System;
using Gtk;
using Saplin.CPDT.UICore;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace Saplin.CPDT.GTK
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Gtk.Application.Init();
            Forms.Init();

            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("CPDT");
            window.Show();

            Gtk.Application.Run();
        }
    }
}
