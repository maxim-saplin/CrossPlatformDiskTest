package mono.android.support.v4.os;


public class CancellationSignal_OnCancelListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.os.CancellationSignal.OnCancelListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCancel:()V:GetOnCancelHandler:Android.Support.V4.OS.CancellationSignal/IOnCancelListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.OS.CancellationSignal+IOnCancelListenerImplementor, Xamarin.Android.Support.Compat", CancellationSignal_OnCancelListenerImplementor.class, __md_methods);
	}


	public CancellationSignal_OnCancelListenerImplementor ()
	{
		super ();
		if (getClass () == CancellationSignal_OnCancelListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.OS.CancellationSignal+IOnCancelListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public void onCancel ()
	{
		n_onCancel ();
	}

	private native void n_onCancel ();

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
