package mono.android.support.v4.view;


public class ActionProvider_SubUiVisibilityListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ActionProvider.SubUiVisibilityListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSubUiVisibilityChanged:(Z)V:GetOnSubUiVisibilityChanged_ZHandler:Android.Support.V4.View.ActionProvider/ISubUiVisibilityListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.View.ActionProvider+ISubUiVisibilityListenerImplementor, Xamarin.Android.Support.Compat", ActionProvider_SubUiVisibilityListenerImplementor.class, __md_methods);
	}


	public ActionProvider_SubUiVisibilityListenerImplementor ()
	{
		super ();
		if (getClass () == ActionProvider_SubUiVisibilityListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.View.ActionProvider+ISubUiVisibilityListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public void onSubUiVisibilityChanged (boolean p0)
	{
		n_onSubUiVisibilityChanged (p0);
	}

	private native void n_onSubUiVisibilityChanged (boolean p0);

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
