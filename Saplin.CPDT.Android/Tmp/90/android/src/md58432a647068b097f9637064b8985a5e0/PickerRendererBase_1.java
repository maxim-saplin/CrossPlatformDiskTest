package md58432a647068b097f9637064b8985a5e0;


public abstract class PickerRendererBase_1
	extends md58432a647068b097f9637064b8985a5e0.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.AppCompat.PickerRendererBase`1, Xamarin.Forms.Platform.Android", PickerRendererBase_1.class, __md_methods);
	}


	public PickerRendererBase_1 (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == PickerRendererBase_1.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AppCompat.PickerRendererBase`1, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PickerRendererBase_1 (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == PickerRendererBase_1.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AppCompat.PickerRendererBase`1, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public PickerRendererBase_1 (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PickerRendererBase_1.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AppCompat.PickerRendererBase`1, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
