package mono.android.support.v4.app;


public class SharedElementCallback_OnSharedElementsReadyListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.app.SharedElementCallback.OnSharedElementsReadyListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSharedElementsReady:()V:GetOnSharedElementsReadyHandler:Android.Support.V4.App.SharedElementCallback/IOnSharedElementsReadyListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.App.SharedElementCallback+IOnSharedElementsReadyListenerImplementor, Xamarin.Android.Support.Compat", SharedElementCallback_OnSharedElementsReadyListenerImplementor.class, __md_methods);
	}


	public SharedElementCallback_OnSharedElementsReadyListenerImplementor ()
	{
		super ();
		if (getClass () == SharedElementCallback_OnSharedElementsReadyListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.App.SharedElementCallback+IOnSharedElementsReadyListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public void onSharedElementsReady ()
	{
		n_onSharedElementsReady ();
	}

	private native void n_onSharedElementsReady ();

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
