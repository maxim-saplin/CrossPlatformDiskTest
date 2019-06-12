package md51558244f76c53b6aeda52c8a337f2c37;


public class Platform_DefaultRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_dispatchTouchEvent:(Landroid/view/MotionEvent;)Z:GetDispatchTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_setOnTouchListener:(Landroid/view/View$OnTouchListener;)V:GetSetOnTouchListener_Landroid_view_View_OnTouchListener_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.Platform+DefaultRenderer, Xamarin.Forms.Platform.Android", Platform_DefaultRenderer.class, __md_methods);
	}


	public Platform_DefaultRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == Platform_DefaultRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.Platform+DefaultRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public Platform_DefaultRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == Platform_DefaultRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.Platform+DefaultRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public Platform_DefaultRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == Platform_DefaultRenderer.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.Platform+DefaultRenderer, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public boolean dispatchTouchEvent (android.view.MotionEvent p0)
	{
		return n_dispatchTouchEvent (p0);
	}

	private native boolean n_dispatchTouchEvent (android.view.MotionEvent p0);


	public void setOnTouchListener (android.view.View.OnTouchListener p0)
	{
		n_setOnTouchListener (p0);
	}

	private native void n_setOnTouchListener (android.view.View.OnTouchListener p0);

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
