using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Saplin.CPDT.UICore
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            ImageSource imageSource = Source == null ? null : ImageSource.FromResource(Source, GetType().GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}