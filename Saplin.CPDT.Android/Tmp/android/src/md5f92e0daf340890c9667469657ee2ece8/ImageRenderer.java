package md5f92e0daf340890c9667469657ee2ece8;


public class ImageRenderer
	extends android.widget.ImageView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_invalidate:()V:GetInvalidateHandler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer, Xamarin.Forms.Platform.Android", ImageRenderer.class, __md_methods);
	}


	public ImageRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ImageRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ImageRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ImageRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ImageRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ImageRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void invalidate ()
	{
		n_invalidate ();
	}

	private native void n_invalidate ();


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

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
