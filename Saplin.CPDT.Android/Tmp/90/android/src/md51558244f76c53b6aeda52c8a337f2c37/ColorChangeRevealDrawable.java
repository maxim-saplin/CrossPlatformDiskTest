package md51558244f76c53b6aeda52c8a337f2c37;


public class ColorChangeRevealDrawable
	extends android.graphics.drawable.AnimationDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.ColorChangeRevealDrawable, Xamarin.Forms.Platform.Android", ColorChangeRevealDrawable.class, __md_methods);
	}


	public ColorChangeRevealDrawable ()
	{
		super ();
		if (getClass () == ColorChangeRevealDrawable.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.ColorChangeRevealDrawable, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);

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
