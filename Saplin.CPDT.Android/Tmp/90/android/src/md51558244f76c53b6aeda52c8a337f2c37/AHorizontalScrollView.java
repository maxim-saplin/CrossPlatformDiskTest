package md51558244f76c53b6aeda52c8a337f2c37;


public class AHorizontalScrollView
	extends android.widget.HorizontalScrollView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInterceptTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnInterceptTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_onScrollChanged:(IIII)V:GetOnScrollChanged_IIIIHandler\n" +
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_isHorizontalScrollBarEnabled:()Z:GetIsHorizontalScrollBarEnabledHandler\n" +
			"n_setHorizontalScrollBarEnabled:(Z)V:GetSetHorizontalScrollBarEnabled_ZHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.AHorizontalScrollView, Xamarin.Forms.Platform.Android", AHorizontalScrollView.class, __md_methods);
	}


	public AHorizontalScrollView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AHorizontalScrollView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AHorizontalScrollView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public AHorizontalScrollView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == AHorizontalScrollView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AHorizontalScrollView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public AHorizontalScrollView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == AHorizontalScrollView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AHorizontalScrollView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public AHorizontalScrollView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == AHorizontalScrollView.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.AHorizontalScrollView, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public boolean onInterceptTouchEvent (android.view.MotionEvent p0)
	{
		return n_onInterceptTouchEvent (p0);
	}

	private native boolean n_onInterceptTouchEvent (android.view.MotionEvent p0);


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public void onScrollChanged (int p0, int p1, int p2, int p3)
	{
		n_onScrollChanged (p0, p1, p2, p3);
	}

	private native void n_onScrollChanged (int p0, int p1, int p2, int p3);


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);


	public boolean isHorizontalScrollBarEnabled ()
	{
		return n_isHorizontalScrollBarEnabled ();
	}

	private native boolean n_isHorizontalScrollBarEnabled ();


	public void setHorizontalScrollBarEnabled (boolean p0)
	{
		n_setHorizontalScrollBarEnabled (p0);
	}

	private native void n_setHorizontalScrollBarEnabled (boolean p0);

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
