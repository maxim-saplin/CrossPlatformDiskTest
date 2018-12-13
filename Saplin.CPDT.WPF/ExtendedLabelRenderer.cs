using Saplin.CPDT.UICore.Controls;
using System;
using System.Windows.Input;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

[assembly: ExportRenderer(typeof(Saplin.CPDT.UICore.Controls.ExtendedLabel), typeof(Saplin.CPDT.WPF.ExtendedLabelRenderer))]

namespace Saplin.CPDT.WPF
{
    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = (e.NewElement as ExtendedLabel);

            if ((Control != null))
            {
                if (label.ChangeCursorOnMouseHover) Control.Cursor = Cursors.Hand;

                //if (label.FormattedText != null && label.FormattedText.Spans != null && label.FormattedText.Spans.Count > 0 && Control.Inlines != null && Control.Inlines.Count == label.FormattedText.Spans.Count)
                //{
                //    var i = 0;
                //    foreach (var inl in Control.Inlines)
                //    {
                //        if (!string.IsNullOrEmpty(label.FormattedText.Spans[i].FontFamily))
                //        {
                //            inl.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), label.FormattedText.Spans[i].FontFamily);
                //        }

                //        i++;
                //    }
                //}
            }
        }
    }
}