package mono.android.support.v7.widget;


public class ViewStubCompat_OnInflateListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.widget.ViewStubCompat.OnInflateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInflate:(Landroid/support/v7/widget/ViewStubCompat;Landroid/view/View;)V:GetOnInflate_Landroid_support_v7_widget_ViewStubCompat_Landroid_view_View_Handler:Android.Support.V7.Widget.ViewStubCompat/IOnInflateListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Widget.ViewStubCompat+IOnInflateListenerImplementor, Xamarin.Android.Support.v7.AppCompat", ViewStubCompat_OnInflateListenerImplementor.class, __md_methods);
	}


	public ViewStubCompat_OnInflateListenerImplementor ()
	{
		super ();
		if (getClass () == ViewStubCompat_OnInflateListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Widget.ViewStubCompat+IOnInflateListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public void onInflate (android.support.v7.widget.ViewStubCompat p0, android.view.View p1)
	{
		n_onInflate (p0, p1);
	}

	private native void n_onInflate (android.support.v7.widget.ViewStubCompat p0, android.view.View p1);

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
