using System;
using System.Collections.Generic;
using Saplin.CPDT.UICore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageButtons : StackLayout
    {
        public MainPageButtons()
        {
            InitializeComponent();
            Application.Current.Resources["refreshButton"] = refreshButton;
        }

        public void AdaptLayoytToScreenWidth(bool narrow)
        {
            foreach(var c in Children)
            {
                if (c is Button)
                {
                    if (narrow)
                    {
                        (c as Button).Style = Application.Current.Resources["NarrowButtonStyle"] as Style;
                    }
                    else
                    {
                        (c as Button).Style = Application.Current.Resources["ButtonStyle"] as Style;
                    }
                }
            }
        }

        public void MakeDbButtonRedirecting()//Used when there're WebView issues
        {
            dbButton.RemoveBinding(Button.CommandProperty);
            dbButton.IsEnabled = true;
            dbButton.Clicked += (s, e) => Device.OpenUri(new System.Uri(ResultsDbViewModel.cpdt_web_url));
        }

        //public void OnTest(Object sender, EventArgs e)
        //{
        //    var ph = DependencyService.Get<IPlatformHooks>();
        //    ph?.TestClick();
        //}
    }

}
