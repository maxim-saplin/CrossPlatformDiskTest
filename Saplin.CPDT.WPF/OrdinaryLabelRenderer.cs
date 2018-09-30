using System;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Label), typeof(Saplin.CPDT.WPF.OrdinaryLabelRenderer))]

namespace Saplin.CPDT.WPF
{
    public class OrdinaryLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = (e.NewElement as Label);

            // TODO - check the bug with custom fonts in Spans fixed and remove
            if ((Control != null))
            {
                if (label.FormattedText != null && label.FormattedText.Spans != null && label.FormattedText.Spans.Count > 0 && Control.Inlines != null && Control.Inlines.Count == label.FormattedText.Spans.Count)
                {
                    var i = 0;
                    foreach (var inl in Control.Inlines)
                    {
                        if (!string.IsNullOrEmpty(label.FormattedText.Spans[i].FontFamily))
                        {
                            inl.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), label.FormattedText.Spans[i].FontFamily);
                        }

                        i++;
                    }
                }
            }
        }
    }
}