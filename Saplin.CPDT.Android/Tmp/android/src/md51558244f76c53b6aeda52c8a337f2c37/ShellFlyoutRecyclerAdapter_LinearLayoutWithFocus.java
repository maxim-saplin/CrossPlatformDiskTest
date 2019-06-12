package md51558244f76c53b6aeda52c8a337f2c37;


public class ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus
	extends android.widget.LinearLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_focusSearch:(I)Landroid/view/View;:GetFocusSearch_IHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ShellFlyoutRecyclerAdapter+LinearLayoutWithFocus, Xamarin.Forms.Platform.Android", ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus.class, __md_methods);
	}


	public ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellFlyoutRecyclerAdapter+LinearLayoutWithFocus, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellFlyoutRecyclerAdapter+LinearLayoutWithFocus, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ShellFlyoutRecyclerAdapter_LinearLayoutWithFocus.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellFlyoutRecyclerAdapter+LinearLayoutWithFocus, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public android.view.View focusSearch (int p0)
	{
		return n_focusSearch (p0);
	}

	private native android.view.View n_focusSearch (int p0);

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
