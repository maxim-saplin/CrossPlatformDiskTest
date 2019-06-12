package md51558244f76c53b6aeda52c8a337f2c37;


public class GestureManager_TapAndPanGestureDetector
	extends android.view.GestureDetector
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.GestureManager+TapAndPanGestureDetector, Xamarin.Forms.Platform.Android", GestureManager_TapAndPanGestureDetector.class, __md_methods);
	}


	public GestureManager_TapAndPanGestureDetector (android.content.Context p0, android.view.GestureDetector.OnGestureListener p1)
	{
		super (p0, p1);
		if (getClass () == GestureManager_TapAndPanGestureDetector.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.GestureManager+TapAndPanGestureDetector, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Views.GestureDetector+IOnGestureListener, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public GestureManager_TapAndPanGestureDetector (android.content.Context p0, android.view.GestureDetector.OnGestureListener p1, android.os.Handler p2)
	{
		super (p0, p1, p2);
		if (getClass () == GestureManager_TapAndPanGestureDetector.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.GestureManager+TapAndPanGestureDetector, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Views.GestureDetector+IOnGestureListener, Mono.Android:Android.OS.Handler, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public GestureManager_TapAndPanGestureDetector (android.content.Context p0, android.view.GestureDetector.OnGestureListener p1, android.os.Handler p2, boolean p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == GestureManager_TapAndPanGestureDetector.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.GestureManager+TapAndPanGestureDetector, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Views.GestureDetector+IOnGestureListener, Mono.Android:Android.OS.Handler, Mono.Android:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public GestureManager_TapAndPanGestureDetector (android.view.GestureDetector.OnGestureListener p0)
	{
		super (p0);
		if (getClass () == GestureManager_TapAndPanGestureDetector.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.GestureManager+TapAndPanGestureDetector, Xamarin.Forms.Platform.Android", "Android.Views.GestureDetector+IOnGestureListener, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public GestureManager_TapAndPanGestureDetector (android.view.GestureDetector.OnGestureListener p0, android.os.Handler p1)
	{
		super (p0, p1);
		if (getClass () == GestureManager_TapAndPanGestureDetector.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.GestureManager+TapAndPanGestureDetector, Xamarin.Forms.Platform.Android", "Android.Views.GestureDetector+IOnGestureListener, Mono.Android:Android.OS.Handler, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


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
