package md5e4c2749da5edf4a9690b7fedcbdb53f0;


public class SKCanvasViewRenderer
	extends md5e4c2749da5edf4a9690b7fedcbdb53f0.SKCanvasViewRendererBase_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Forms.SKCanvasViewRenderer, SkiaSharp.Views.Forms", SKCanvasViewRenderer.class, __md_methods);
	}


	public SKCanvasViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SKCanvasViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKCanvasViewRenderer, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SKCanvasViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SKCanvasViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKCanvasViewRenderer, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SKCanvasViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SKCanvasViewRenderer.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKCanvasViewRenderer, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
