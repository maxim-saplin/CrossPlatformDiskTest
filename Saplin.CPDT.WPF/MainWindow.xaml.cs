using System.Windows.Input;
using System.Windows;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Saplin.CPDT.WPF
{
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            instance = this;

            InitializeComponent();
            Forms.Init();

            // TODO - check for fix in Xamarin WPF and remove the workaround
            SawapDeserializer();

            LoadApplication(new Saplin.CPDT.UICore.App());

            MouseMove += OnMouseMove;

           var f = Fonts.GetTypefaces(new Uri("pack://application:,,,/"), "./Fonts/");
           var ff = new FontFamily(new Uri("pack://application:,,,/"),"./#Fira Mono");
        }

        private static void SawapDeserializer()
        {
            //var des = Xamarin.Forms.DependencyService.Get<IDeserializer>();

            var type = typeof(Xamarin.Forms.DependencyService);
            var field = type.GetField("DependencyTypes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var list = field.GetValue(null) as List<Type>;

            Type td = null;

            foreach (var t in list)
                if (t.FullName == "Xamarin.Forms.Platform.WPF.Deserializer")
                {
                    td = t;
                    break;
                }

            list.Remove(td);

            field = type.GetField("DependencyImplementations", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var obj = field.GetValue(null);
            type = obj.GetType();
            var method = type.GetMethod("Clear");
            method.Invoke(obj, null);

            //des = Xamarin.Forms.DependencyService.Get<IDeserializer>();
        }

        static MainWindow instance;

        public static MainWindow Instance
        {
            get
            {
                return instance;
            }
        }

        private bool topBarsRemoved = false;

        private void RemoveTopBars()
        {
            System.Windows.Controls.Grid commandBar = this.Template.FindName("PART_CommandsBar", this) as System.Windows.Controls.Grid;

            if (commandBar != null)
                (commandBar.Parent as System.Windows.Controls.Grid)?.Children.Remove(commandBar);

            var topAppBar = this.Template.FindName("PART_TopAppBar", this) as WpfLightToolkit.Controls.LightAppBar;

            if (topAppBar != null)
                (topAppBar.Parent as System.Windows.Controls.Grid)?.Children.Remove(topAppBar);

            topBarsRemoved = true;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    System.Windows.Application.Current.MainWindow.Top = 3;
                }
                DragMove();
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (!topBarsRemoved) RemoveTopBars();
        }

    }
}
