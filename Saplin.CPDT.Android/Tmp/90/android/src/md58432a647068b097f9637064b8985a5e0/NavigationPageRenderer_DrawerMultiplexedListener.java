package md58432a647068b097f9637064b8985a5e0;


public class NavigationPageRenderer_DrawerMultiplexedListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.widget.DrawerLayout.DrawerListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDrawerClosed:(Landroid/view/View;)V:GetOnDrawerClosed_Landroid_view_View_Handler:Android.Support.V4.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.Android.Support.DrawerLayout\n" +
			"n_onDrawerOpened:(Landroid/view/View;)V:GetOnDrawerOpened_Landroid_view_View_Handler:Android.Support.V4.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.Android.Support.DrawerLayout\n" +
			"n_onDrawerSlide:(Landroid/view/View;F)V:GetOnDrawerSlide_Landroid_view_View_FHandler:Android.Support.V4.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.Android.Support.DrawerLayout\n" +
			"n_onDrawerStateChanged:(I)V:GetOnDrawerStateChanged_IHandler:Android.Support.V4.Widget.DrawerLayout/IDrawerListenerInvoker, Xamarin.Android.Support.DrawerLayout\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer+DrawerMultiplexedListener, Xamarin.Forms.Platform.Android", NavigationPageRenderer_DrawerMultiplexedListener.class, __md_methods);
	}


	public NavigationPageRenderer_DrawerMultiplexedListener ()
	{
		super ();
		if (getClass () == NavigationPageRenderer_DrawerMultiplexedListener.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer+DrawerMultiplexedListener, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public void onDrawerClosed (android.view.View p0)
	{
		n_onDrawerClosed (p0);
	}

	private native void n_onDrawerClosed (android.view.View p0);


	public void onDrawerOpened (android.view.View p0)
	{
		n_onDrawerOpened (p0);
	}

	private native void n_onDrawerOpened (android.view.View p0);


	public void onDrawerSlide (android.view.View p0, float p1)
	{
		n_onDrawerSlide (p0, p1);
	}

	private native void n_onDrawerSlide (android.view.View p0, float p1);


	public void onDrawerStateChanged (int p0)
	{
		n_onDrawerStateChanged (p0);
	}

	private native void n_onDrawerStateChanged (int p0);

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
