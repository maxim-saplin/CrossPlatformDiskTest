using System;
using System.ComponentModel;
using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(Button), typeof(Saplin.CPDT.Mac.MacButtonRenderer))]


[Register("CustomButton")]
public class CustomButton : NSButton
{
    private NSTrackingArea trackingArea = null;
    private NSCursor cursor = NSCursor.ArrowCursor;

    private bool enableMouseHover = false;

    public bool EnableMouseHover
    {
        get
        {
            return enableMouseHover;
        }
        set
        {
            enableMouseHover = value;

            if (value) AddHoverCursor(); else RemoveHoverCursor();
        }
    }

    public CustomButton(bool enableMouseHover)
    {
        this.enableMouseHover = enableMouseHover;
    }

    public override void ViewDidMoveToWindow()
    {
        base.ViewDidMoveToWindow();

        if (enableMouseHover) AddHoverCursor();
    }

    public override void MouseEntered(NSEvent theEvent)
    {
        base.MouseEntered(theEvent);

        if (!enableMouseHover) return;

        var item = Window.ContentView.HitTest(theEvent.LocationInWindow);

        if (item != this) RemoveHoverCursor(); else AddHoverCursor();
    }

    private void AddHoverCursor()
    {
        if (trackingArea == null)
        {

            trackingArea = new NSTrackingArea(
                VisibleRect(),
                NSTrackingAreaOptions.ActiveWhenFirstResponder | NSTrackingAreaOptions.CursorUpdate | NSTrackingAreaOptions.MouseEnteredAndExited | NSTrackingAreaOptions.ActiveInActiveApp | NSTrackingAreaOptions.InVisibleRect,
                this,
                null
            );

            AddTrackingArea(trackingArea);
        }

        if (cursor != NSCursor.PointingHandCursor)
        {
            cursor = NSCursor.PointingHandCursor;
            AddCursorRect(VisibleRect(), cursor);
        }
    }

    private void RemoveHoverCursor()
    {
        if (cursor != NSCursor.ArrowCursor)
        {
            cursor = NSCursor.ArrowCursor;
            DiscardCursorRects();
        }
    }

    public override void ResetCursorRects()
    {
        AddCursorRect(VisibleRect(), cursor);
    }
}

namespace Saplin.CPDT.Mac
{
    public class MacButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if ((Control != null) && (e.NewElement != null))
            {
                var newControl = new CustomButton(true);

                newControl.Cell = Control.Cell;
                newControl.Bordered = e.NewElement.BorderWidth > 0.01;

                SetNativeControl(newControl);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(VisualElement.IsVisible) ||
                e.PropertyName == nameof(VisualElement.IsEnabled))
            {
                (Control as CustomButton).EnableMouseHover = IsHoverEnabled();
            }
        }

        private bool IsHoverEnabled()
        {
            return Element.IsEnabled && Element.IsVisible;
        }
    }
}
