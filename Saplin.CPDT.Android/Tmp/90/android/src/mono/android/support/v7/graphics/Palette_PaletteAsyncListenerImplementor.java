package mono.android.support.v7.graphics;


public class Palette_PaletteAsyncListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.graphics.Palette.PaletteAsyncListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGenerated:(Landroid/support/v7/graphics/Palette;)V:GetOnGenerated_Landroid_support_v7_graphics_Palette_Handler:Android.Support.V7.Graphics.Palette/IPaletteAsyncListenerInvoker, Xamarin.Android.Support.v7.Palette\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Graphics.Palette+IPaletteAsyncListenerImplementor, Xamarin.Android.Support.v7.Palette", Palette_PaletteAsyncListenerImplementor.class, __md_methods);
	}


	public Palette_PaletteAsyncListenerImplementor ()
	{
		super ();
		if (getClass () == Palette_PaletteAsyncListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Graphics.Palette+IPaletteAsyncListenerImplementor, Xamarin.Android.Support.v7.Palette", "", this, new java.lang.Object[] {  });
	}


	public void onGenerated (android.support.v7.graphics.Palette p0)
	{
		n_onGenerated (p0);
	}

	private native void n_onGenerated (android.support.v7.graphics.Palette p0);

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
