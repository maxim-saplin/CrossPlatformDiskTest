package mono.android.support.design.widget;


public class BottomNavigationView_OnNavigationItemReselectedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.BottomNavigationView.OnNavigationItemReselectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNavigationItemReselected:(Landroid/view/MenuItem;)V:GetOnNavigationItemReselected_Landroid_view_MenuItem_Handler:Android.Support.Design.Widget.BottomNavigationView/IOnNavigationItemReselectedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("Android.Support.Design.Widget.BottomNavigationView+IOnNavigationItemReselectedListenerImplementor, Xamarin.Android.Support.Design", BottomNavigationView_OnNavigationItemReselectedListenerImplementor.class, __md_methods);
	}


	public BottomNavigationView_OnNavigationItemReselectedListenerImplementor ()
	{
		super ();
		if (getClass () == BottomNavigationView_OnNavigationItemReselectedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.Design.Widget.BottomNavigationView+IOnNavigationItemReselectedListenerImplementor, Xamarin.Android.Support.Design", "", this, new java.lang.Object[] {  });
	}


	public void onNavigationItemReselected (android.view.MenuItem p0)
	{
		n_onNavigationItemReselected (p0);
	}

	private native void n_onNavigationItemReselected (android.view.MenuItem p0);

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
