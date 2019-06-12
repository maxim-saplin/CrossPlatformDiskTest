package md51558244f76c53b6aeda52c8a337f2c37;


public class CustomFrameLayout
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onApplyWindowInsets:(Landroid/view/WindowInsets;)Landroid/view/WindowInsets;:GetOnApplyWindowInsets_Landroid_view_WindowInsets_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.CustomFrameLayout, Xamarin.Forms.Platform.Android", CustomFrameLayout.class, __md_methods);
	}


	public CustomFrameLayout (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomFrameLayout.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CustomFrameLayout, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CustomFrameLayout (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomFrameLayout.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CustomFrameLayout, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomFrameLayout (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomFrameLayout.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CustomFrameLayout, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomFrameLayout (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == CustomFrameLayout.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CustomFrameLayout, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public android.view.WindowInsets onApplyWindowInsets (android.view.WindowInsets p0)
	{
		return n_onApplyWindowInsets (p0);
	}

	private native android.view.WindowInsets n_onApplyWindowInsets (android.view.WindowInsets p0);

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
