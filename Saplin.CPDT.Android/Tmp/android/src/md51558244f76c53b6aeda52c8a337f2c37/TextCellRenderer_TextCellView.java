package md51558244f76c53b6aeda52c8a337f2c37;


public class TextCellRenderer_TextCellView
	extends md51558244f76c53b6aeda52c8a337f2c37.BaseCellView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.TextCellRenderer+TextCellView, Xamarin.Forms.Platform.Android", TextCellRenderer_TextCellView.class, __md_methods);
	}


	public TextCellRenderer_TextCellView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == TextCellRenderer_TextCellView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.TextCellRenderer+TextCellView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public TextCellRenderer_TextCellView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == TextCellRenderer_TextCellView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.TextCellRenderer+TextCellView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public TextCellRenderer_TextCellView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == TextCellRenderer_TextCellView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.TextCellRenderer+TextCellView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

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
