package md5e4c2749da5edf4a9690b7fedcbdb53f0;


public class SKGLViewRenderer
	extends md5e4c2749da5edf4a9690b7fedcbdb53f0.SKGLViewRendererBase_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms", SKGLViewRenderer.class, __md_methods);
	}


	public SKGLViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SKGLViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SKGLViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SKGLViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SKGLViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SKGLViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKGLViewRenderer, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
