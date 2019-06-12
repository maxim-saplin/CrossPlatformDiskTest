package mono.android.support.v4.view;


public class ActionProvider_VisibilityListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ActionProvider.VisibilityListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onActionProviderVisibilityChanged:(Z)V:GetOnActionProviderVisibilityChanged_ZHandler:Android.Support.V4.View.ActionProvider/IVisibilityListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.View.ActionProvider+IVisibilityListenerImplementor, Xamarin.Android.Support.Compat", ActionProvider_VisibilityListenerImplementor.class, __md_methods);
	}


	public ActionProvider_VisibilityListenerImplementor ()
	{
		super ();
		if (getClass () == ActionProvider_VisibilityListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.View.ActionProvider+IVisibilityListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public void onActionProviderVisibilityChanged (boolean p0)
	{
		n_onActionProviderVisibilityChanged (p0);
	}

	private native void n_onActionProviderVisibilityChanged (boolean p0);

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
