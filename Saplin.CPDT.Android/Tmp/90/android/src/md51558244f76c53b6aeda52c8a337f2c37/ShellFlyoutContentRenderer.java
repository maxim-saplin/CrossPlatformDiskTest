package md51558244f76c53b6aeda52c8a337f2c37;


public class ShellFlyoutContentRenderer
	extends android.support.design.widget.NavigationView
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.NavigationView.OnNavigationItemSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNavigationItemSelected:(Landroid/view/MenuItem;)Z:GetOnNavigationItemSelected_Landroid_view_MenuItem_Handler:Android.Support.Design.Widget.NavigationView/IOnNavigationItemSelectedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ShellFlyoutContentRenderer, Xamarin.Forms.Platform.Android", ShellFlyoutContentRenderer.class, __md_methods);
	}


	public ShellFlyoutContentRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ShellFlyoutContentRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellFlyoutContentRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ShellFlyoutContentRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ShellFlyoutContentRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellFlyoutContentRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ShellFlyoutContentRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ShellFlyoutContentRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellFlyoutContentRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean onNavigationItemSelected (android.view.MenuItem p0)
	{
		return n_onNavigationItemSelected (p0);
	}

	private native boolean n_onNavigationItemSelected (android.view.MenuItem p0);

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
