package mono.android.support.v4.widget;


public class NestedScrollView_OnScrollChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.widget.NestedScrollView.OnScrollChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollChange:(Landroid/support/v4/widget/NestedScrollView;IIII)V:GetOnScrollChange_Landroid_support_v4_widget_NestedScrollView_IIIIHandler:Android.Support.V4.Widget.NestedScrollView/IOnScrollChangeListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.Widget.NestedScrollView+IOnScrollChangeListenerImplementor, Xamarin.Android.Support.Compat", NestedScrollView_OnScrollChangeListenerImplementor.class, __md_methods);
	}


	public NestedScrollView_OnScrollChangeListenerImplementor ()
	{
		super ();
		if (getClass () == NestedScrollView_OnScrollChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.Widget.NestedScrollView+IOnScrollChangeListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public void onScrollChange (android.support.v4.widget.NestedScrollView p0, int p1, int p2, int p3, int p4)
	{
		n_onScrollChange (p0, p1, p2, p3, p4);
	}

	private native void n_onScrollChange (android.support.v4.widget.NestedScrollView p0, int p1, int p2, int p3, int p4);

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
