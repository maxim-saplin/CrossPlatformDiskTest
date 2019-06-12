package md5f24c356e1394bd37d0c871b61b28ee61;


public class GLTextureView_LogWriter
	extends java.io.Writer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_close:()V:GetCloseHandler\n" +
			"n_flush:()V:GetFlushHandler\n" +
			"n_write:([CII)V:GetWrite_arrayCIIHandler\n" +
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Android.GLTextureView+LogWriter, SkiaSharp.Views.Android", GLTextureView_LogWriter.class, __md_methods);
	}


	public GLTextureView_LogWriter ()
	{
		super ();
		if (getClass () == GLTextureView_LogWriter.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.GLTextureView+LogWriter, SkiaSharp.Views.Android", "", this, new java.lang.Object[] {  });
	}


	public GLTextureView_LogWriter (java.lang.Object p0)
	{
		super (p0);
		if (getClass () == GLTextureView_LogWriter.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Android.GLTextureView+LogWriter, SkiaSharp.Views.Android", "Java.Lang.Object, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void close ()
	{
		n_close ();
	}

	private native void n_close ();


	public void flush ()
	{
		n_flush ();
	}

	private native void n_flush ();


	public void write (char[] p0, int p1, int p2)
	{
		n_write (p0, p1, p2);
	}

	private native void n_write (char[] p0, int p1, int p2);

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
