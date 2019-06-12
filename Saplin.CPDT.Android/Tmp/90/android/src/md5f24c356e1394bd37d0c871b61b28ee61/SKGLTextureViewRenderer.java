package md5f24c356e1394bd37d0c871b61b28ee61;


public abstract class SKGLTextureViewRenderer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Android.SKGLTextureViewRenderer, SkiaSharp.Views.Android", SKGLTextureViewRenderer.class, __md_methods);
	}


	public SKGLTextureViewRenderer ()
	{
		super ();
		if (getClass () == SKGLTextureViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.SKGLTextureViewRenderer, SkiaSharp.Views.Android", "", this, new java.lang.Object[] {  });
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
