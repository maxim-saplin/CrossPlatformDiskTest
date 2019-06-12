package md5f24c356e1394bd37d0c871b61b28ee61;


public class SKGLSurfaceView
	extends android.opengl.GLSurfaceView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Android.SKGLSurfaceView, SkiaSharp.Views.Android", SKGLSurfaceView.class, __md_methods);
	}


	public SKGLSurfaceView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SKGLSurfaceView.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKGLSurfaceView, SkiaSharp.Views.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SKGLSurfaceView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SKGLSurfaceView.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKGLSurfaceView, SkiaSharp.Views.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
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
