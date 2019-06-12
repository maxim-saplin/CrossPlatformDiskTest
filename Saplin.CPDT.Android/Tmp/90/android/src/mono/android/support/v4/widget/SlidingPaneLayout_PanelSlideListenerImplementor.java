package mono.android.support.v4.widget;


public class SlidingPaneLayout_PanelSlideListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.widget.SlidingPaneLayout.PanelSlideListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPanelClosed:(Landroid/view/View;)V:GetOnPanelClosed_Landroid_view_View_Handler:Android.Support.V4.Widget.SlidingPaneLayout/IPanelSlideListenerInvoker, Xamarin.Android.Support.SlidingPaneLayout\n" +
			"n_onPanelOpened:(Landroid/view/View;)V:GetOnPanelOpened_Landroid_view_View_Handler:Android.Support.V4.Widget.SlidingPaneLayout/IPanelSlideListenerInvoker, Xamarin.Android.Support.SlidingPaneLayout\n" +
			"n_onPanelSlide:(Landroid/view/View;F)V:GetOnPanelSlide_Landroid_view_View_FHandler:Android.Support.V4.Widget.SlidingPaneLayout/IPanelSlideListenerInvoker, Xamarin.Android.Support.SlidingPaneLayout\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.Widget.SlidingPaneLayout+IPanelSlideListenerImplementor, Xamarin.Android.Support.SlidingPaneLayout", SlidingPaneLayout_PanelSlideListenerImplementor.class, __md_methods);
	}


	public SlidingPaneLayout_PanelSlideListenerImplementor ()
	{
		super ();
		if (getClass () == SlidingPaneLayout_PanelSlideListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.Widget.SlidingPaneLayout+IPanelSlideListenerImplementor, Xamarin.Android.Support.SlidingPaneLayout", "", this, new java.lang.Object[] {  });
	}


	public void onPanelClosed (android.view.View p0)
	{
		n_onPanelClosed (p0);
	}

	private native void n_onPanelClosed (android.view.View p0);


	public void onPanelOpened (android.view.View p0)
	{
		n_onPanelOpened (p0);
	}

	private native void n_onPanelOpened (android.view.View p0);


	public void onPanelSlide (android.view.View p0, float p1)
	{
		n_onPanelSlide (p0, p1);
	}

	private native void n_onPanelSlide (android.view.View p0, float p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
