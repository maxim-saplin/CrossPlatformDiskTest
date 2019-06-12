package md51558244f76c53b6aeda52c8a337f2c37;


public class ShellFlyoutTemplatedContentRenderer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.AppBarLayout.OnOffsetChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOffsetChanged:(Landroid/support/design/widget/AppBarLayout;I)V:GetOnOffsetChanged_Landroid_support_design_widget_AppBarLayout_IHandler:Android.Support.Design.Widget.AppBarLayout/IOnOffsetChangedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ShellFlyoutTemplatedContentRenderer, Xamarin.Forms.Platform.Android", ShellFlyoutTemplatedContentRenderer.class, __md_methods);
	}


	public ShellFlyoutTemplatedContentRenderer ()
	{
		super ();
		if (getClass () == ShellFlyoutTemplatedContentRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellFlyoutTemplatedContentRenderer, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public void onOffsetChanged (android.support.design.widget.AppBarLayout p0, int p1)
	{
		n_onOffsetChanged (p0, p1);
	}

	private native void n_onOffsetChanged (android.support.design.widget.AppBarLayout p0, int p1);

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
