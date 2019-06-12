package md5f24c356e1394bd37d0c871b61b28ee61;


public class SKGLSurfaceView_InternalRenderer
	extends md5f24c356e1394bd37d0c871b61b28ee61.SKGLSurfaceViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Android.SKGLSurfaceView+InternalRenderer, SkiaSharp.Views.Android", SKGLSurfaceView_InternalRenderer.class, __md_methods);
	}


	public SKGLSurfaceView_InternalRenderer ()
	{
		super ();
		if (getClass () == SKGLSurfaceView_InternalRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKGLSurfaceView+InternalRenderer, SkiaSharp.Views.Android", "", this, new java.lang.Object[] {  });
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
