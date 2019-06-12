package md51558244f76c53b6aeda52c8a337f2c37;


public class EmptyViewAdapter_EmptyViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.EmptyViewAdapter+EmptyViewHolder, Xamarin.Forms.Platform.Android", EmptyViewAdapter_EmptyViewHolder.class, __md_methods);
	}


	public EmptyViewAdapter_EmptyViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == EmptyViewAdapter_EmptyViewHolder.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.EmptyViewAdapter+EmptyViewHolder, Xamarin.Forms.Platform.Android", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
