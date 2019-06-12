package md51558244f76c53b6aeda52c8a337f2c37;


public class ShellPageContainer
	extends md51558244f76c53b6aeda52c8a337f2c37.PageContainer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ShellPageContainer, Xamarin.Forms.Platform.Android", ShellPageContainer.class, __md_methods);
	}


	public ShellPageContainer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ShellPageContainer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellPageContainer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ShellPageContainer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ShellPageContainer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellPageContainer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ShellPageContainer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ShellPageContainer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellPageContainer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ShellPageContainer (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ShellPageContainer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ShellPageContainer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

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
