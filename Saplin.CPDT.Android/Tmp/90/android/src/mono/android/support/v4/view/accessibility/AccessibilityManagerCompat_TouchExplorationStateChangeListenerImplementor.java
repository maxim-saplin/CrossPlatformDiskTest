package mono.android.support.v4.view.accessibility;


public class AccessibilityManagerCompat_TouchExplorationStateChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.accessibility.AccessibilityManagerCompat.TouchExplorationStateChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchExplorationStateChanged:(Z)V:GetOnTouchExplorationStateChanged_ZHandler:Android.Support.V4.View.Accessibility.AccessibilityManagerCompat/ITouchExplorationStateChangeListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.View.Accessibility.AccessibilityManagerCompat+ITouchExplorationStateChangeListenerImplementor, Xamarin.Android.Support.Compat", AccessibilityManagerCompat_TouchExplorationStateChangeListenerImplementor.class, __md_methods);
	}


	public AccessibilityManagerCompat_TouchExplorationStateChangeListenerImplementor ()
	{
		super ();
		if (getClass () == AccessibilityManagerCompat_TouchExplorationStateChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.View.Accessibility.AccessibilityManagerCompat+ITouchExplorationStateChangeListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public void onTouchExplorationStateChanged (boolean p0)
	{
		n_onTouchExplorationStateChanged (p0);
	}

	private native void n_onTouchExplorationStateChanged (boolean p0);

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
