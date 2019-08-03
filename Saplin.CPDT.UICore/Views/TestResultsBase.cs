using System;
using System.Collections.Generic;
using Saplin.CPDT.UICore.Controls;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace Saplin.CPDT.UICore
{
    public class TestResultsBase : GridRepeater
    {
        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent != null)
            {

                Parent.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(VisualElement.IsVisible))
                    {
                        Animate();
                    }
                };

                Device.StartTimer(TimeSpan.FromMilliseconds(500), () => { Animate(); return false; });
            }
        }

        bool assigned = false;
        bool toggle = false;

        protected internal void Animate()
        {
            var animatedGraphs = new List<SKCanvasView>();
            //var animatedLabels = new List<Label>();
            var animatedLabels = new List<StackLayout>();

            if (!assigned && IsFooterVisible == false && Rows.Count == 5) // not used in-progress
            {
                for (int i = 0; i < Rows.Count; i++)
                {
                    if (i != HeaderRow && i != FooterRow)
                    {
                        var r = Rows[i];

                        var c = r.Find(el => el is SKCanvasView && el.IsVisible);
                        if (c != null && !animatedGraphs.Contains(c as SKCanvasView)) animatedGraphs.Add(c as SKCanvasView);

                        var c2 = r.Find(el => el is StackLayout && el.IsVisible);
                        if (c2 != null && !animatedLabels.Contains(c2 as StackLayout)) animatedLabels.Add(c2 as StackLayout);

                        Device.StartTimer(
                            TimeSpan.FromMilliseconds(5500),
                                () =>
                                {
                                    if (Parent == null || !(Parent as VisualElement).IsVisible)
                                    {
                                        assigned = false;
                                        return false;
                                    }

                                    if (!toggle)
                                    {
                                        foreach (var g in animatedGraphs)
                                            g.FadeTo(0.05, 650, Easing.CubicInOut);

                                        foreach (var l in animatedLabels)
                                            l.FadeTo(1.0, 650, Easing.CubicIn);

                                        toggle = true;
                                    }
                                    else
                                    {
                                        foreach (var g in animatedGraphs)
                                            g.FadeTo(1.0, 650, Easing.CubicIn);

                                        foreach (var l in animatedLabels)
                                            l.FadeTo(0.0, 650, Easing.CubicOut);

                                        toggle = false;
                                    }

                                    return true;
                                }
                            );
                    }
                }

                assigned = true;
            }
        }
    }
}
