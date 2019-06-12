package md51558244f76c53b6aeda52c8a337f2c37;


public class FormsEditTextBase
	extends android.widget.EditText
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_requestFocus:(ILandroid/graphics/Rect;)Z:GetRequestFocus_ILandroid_graphics_Rect_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.FormsEditTextBase, Xamarin.Forms.Platform.Android", FormsEditTextBase.class, __md_methods);
	}


	public FormsEditTextBase (android.content.Context p0)
	{
		super (p0);
		if (getClass () == FormsEditTextBase.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormsEditTextBase, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public FormsEditTextBase (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == FormsEditTextBase.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormsEditTextBase, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public FormsEditTextBase (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == FormsEditTextBase.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormsEditTextBase, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean requestFocus (int p0, android.graphics.Rect p1)
	{
		return n_requestFocus (p0, p1);
	}

	private native boolean n_requestFocus (int p0, android.graphics.Rect p1);

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
