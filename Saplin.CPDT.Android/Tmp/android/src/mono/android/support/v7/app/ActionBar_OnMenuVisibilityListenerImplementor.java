package mono.android.support.v7.app;


public class ActionBar_OnMenuVisibilityListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.app.ActionBar.OnMenuVisibilityListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMenuVisibilityChanged:(Z)V:GetOnMenuVisibilityChanged_ZHandler:Android.Support.V7.App.ActionBar/IOnMenuVisibilityListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.App.ActionBar+IOnMenuVisibilityListenerImplementor, Xamarin.Android.Support.v7.AppCompat", ActionBar_OnMenuVisibilityListenerImplementor.class, __md_methods);
	}


	public ActionBar_OnMenuVisibilityListenerImplementor ()
	{
		super ();
		if (getClass () == ActionBar_OnMenuVisibilityListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.App.ActionBar+IOnMenuVisibilityListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public void onMenuVisibilityChanged (boolean p0)
	{
		n_onMenuVisibilityChanged (p0);
	}

	private native void n_onMenuVisibilityChanged (boolean p0);

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
