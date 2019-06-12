package mono.android.support.v7.widget;


public class RecyclerView_RecyclerListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.widget.RecyclerView.RecyclerListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onViewRecycled:(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V:GetOnViewRecycled_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler:Android.Support.V7.Widget.RecyclerView/IRecyclerListenerInvoker, Xamarin.Android.Support.v7.RecyclerView\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Widget.RecyclerView+IRecyclerListenerImplementor, Xamarin.Android.Support.v7.RecyclerView", RecyclerView_RecyclerListenerImplementor.class, __md_methods);
	}


	public RecyclerView_RecyclerListenerImplementor ()
	{
		super ();
		if (getClass () == RecyclerView_RecyclerListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Widget.RecyclerView+IRecyclerListenerImplementor, Xamarin.Android.Support.v7.RecyclerView", "", this, new java.lang.Object[] {  });
	}


	public void onViewRecycled (android.support.v7.widget.RecyclerView.ViewHolder p0)
	{
		n_onViewRecycled (p0);
	}

	private native void n_onViewRecycled (android.support.v7.widget.RecyclerView.ViewHolder p0);

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
