﻿using System;
using System.Reflection;
using System.Windows.Input;
using Saplin.CPDT.UICore.Localization;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore.ViewModels
{
    public class AboutViewModel : PopupViewModel
    {
        public AboutViewModel()
        {
            ViewModelContainer.L11n.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ViewModelContainer.L11n._Locale))
                {
                    RaisePropertyChanged(nameof(AboutImage));
                }
            };
        }

        public ImageSource AboutImage
        {
            get
            {
                var locale = ViewModelContainer.L11n._Locale;
                // There're only En and Ru versions of the diagram in About
                if (locale == Locales.fr || locale == Locales.pl) locale = Locales.en;
                var resourceId = string.Format("Saplin.CPDT.UICore.Img.{0}About{1}.png", locale, ViewModelContainer.OptionsViewModel.WhiteThemeBool ? "WhiteTheme" : "BlackTheme");
                ImageSource imageSource = null;

                if (Device.RuntimePlatform == Device.WPF)
                {
                    var assembly = GetType().GetTypeInfo().Assembly;


                    var resourceStream = assembly.GetManifestResourceStream(resourceId);

                    if (resourceStream == null)
                        return null;
                    imageSource = ImageSource.FromStream(() => resourceStream);
                }
                else imageSource = ImageSource.FromResource(resourceId, GetType().GetTypeInfo().Assembly);

                return imageSource;
            }
        }

        private ICommand navigateToProjectSite = new Command(() => { Device.OpenUri(new Uri(ViewModelContainer.L11n.ProjectLink)); });

        public ICommand NavigateToProjectSite
        {
            get
            {
                return navigateToProjectSite;
            }
        }

        private ICommand navigateToDownloadSite = new Command(() => { Device.OpenUri(new Uri(ViewModelContainer.L11n.DownloadLink)); });

        public ICommand NavigateToDownloadSite
        {
            get
            {
                return navigateToDownloadSite;
            }
        }

        
    }
}

