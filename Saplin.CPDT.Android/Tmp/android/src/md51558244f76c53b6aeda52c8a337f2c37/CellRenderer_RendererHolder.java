package md51558244f76c53b6aeda52c8a337f2c37;


public class CellRenderer_RendererHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.CellRenderer+RendererHolder, Xamarin.Forms.Platform.Android", CellRenderer_RendererHolder.class, __md_methods);
	}


	public CellRenderer_RendererHolder ()
	{
		super ();
		if (getClass () == CellRenderer_RendererHolder.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CellRenderer+RendererHolder, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
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
