package mono.android.support.v4.app;


public class FragmentManager_OnBackStackChangedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.app.FragmentManager.OnBackStackChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onBackStackChanged:()V:GetOnBackStackChangedHandler:Android.Support.V4.App.FragmentManager/IOnBackStackChangedListenerInvoker, Xamarin.Android.Support.Fragment\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.App.FragmentManager+IOnBackStackChangedListenerImplementor, Xamarin.Android.Support.Fragment", FragmentManager_OnBackStackChangedListenerImplementor.class, __md_methods);
	}


	public FragmentManager_OnBackStackChangedListenerImplementor ()
	{
		super ();
		if (getClass () == FragmentManager_OnBackStackChangedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.App.FragmentManager+IOnBackStackChangedListenerImplementor, Xamarin.Android.Support.Fragment", "", this, new java.lang.Object[] {  });
	}


	public void onBackStackChanged ()
	{
		n_onBackStackChanged ();
	}

	private native void n_onBackStackChanged ();

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
