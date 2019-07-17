using System;
using Saplin.CPDT.UICore.Controls;
using Saplin.CPDT.UICore.Misc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Title : StackLayout
    {
        public Title()
        {
            InitializeComponent();

            bitSystem.Text += Environment.Is64BitProcess ? " 64bit" : " 32bit";

            var di = DependencyService.Get<IDeviceInfo>();

            if (di != null) bitSystem.Text += di.IsChromeOs ? " ChromeOS" : "";
        }

        public ExtendedLabel QuitButton { get { return quitButton; } }
        public ExtendedLabel QuitingButton { get { return quitingButton; } }

        public event EventHandler QuitClicked;

        public void OnQuit(Object sender, EventArgs e)
        {
            QuitClicked?.Invoke(sender, e);
        }
    }
}
