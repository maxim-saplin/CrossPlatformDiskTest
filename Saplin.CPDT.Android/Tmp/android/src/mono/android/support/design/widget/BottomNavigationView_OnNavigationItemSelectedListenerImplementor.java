package mono.android.support.design.widget;


public class BottomNavigationView_OnNavigationItemSelectedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.BottomNavigationView.OnNavigationItemSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNavigationItemSelected:(Landroid/view/MenuItem;)Z:GetOnNavigationItemSelected_Landroid_view_MenuItem_Handler:Android.Support.Design.Widget.BottomNavigationView/IOnNavigationItemSelectedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("Android.Support.Design.Widget.BottomNavigationView+IOnNavigationItemSelectedListenerImplementor, Xamarin.Android.Support.Design", BottomNavigationView_OnNavigationItemSelectedListenerImplementor.class, __md_methods);
	}


	public BottomNavigationView_OnNavigationItemSelectedListenerImplementor ()
	{
		super ();
		if (getClass () == BottomNavigationView_OnNavigationItemSelectedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.Design.Widget.BottomNavigationView+IOnNavigationItemSelectedListenerImplementor, Xamarin.Android.Support.Design", "", this, new java.lang.Object[] {  });
	}


	public boolean onNavigationItemSelected (android.view.MenuItem p0)
	{
		return n_onNavigationItemSelected (p0);
	}

	private native boolean n_onNavigationItemSelected (android.view.MenuItem p0);

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
