package mono.android.support.v7.widget;


public class ActionMenuView_OnMenuItemClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.widget.ActionMenuView.OnMenuItemClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMenuItemClick:(Landroid/view/MenuItem;)Z:GetOnMenuItemClick_Landroid_view_MenuItem_Handler:Android.Support.V7.Widget.ActionMenuView/IOnMenuItemClickListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Widget.ActionMenuView+IOnMenuItemClickListenerImplementor, Xamarin.Android.Support.v7.AppCompat", ActionMenuView_OnMenuItemClickListenerImplementor.class, __md_methods);
	}


	public ActionMenuView_OnMenuItemClickListenerImplementor ()
	{
		super ();
		if (getClass () == ActionMenuView_OnMenuItemClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Widget.ActionMenuView+IOnMenuItemClickListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public boolean onMenuItemClick (android.view.MenuItem p0)
	{
		return n_onMenuItemClick (p0);
	}

	private native boolean n_onMenuItemClick (android.view.MenuItem p0);

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
