package md51558244f76c53b6aeda52c8a337f2c37;


public class FormsTextView
	extends android.widget.TextView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_invalidate:()V:GetInvalidateHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.FormsTextView, Xamarin.Forms.Platform.Android", FormsTextView.class, __md_methods);
	}


	public FormsTextView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == FormsTextView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormsTextView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public FormsTextView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == FormsTextView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormsTextView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public FormsTextView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == FormsTextView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormsTextView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void invalidate ()
	{
		n_invalidate ();
	}

	private native void n_invalidate ();

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
