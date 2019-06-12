package mono.android.support.v7.widget;


public class ContentFrameLayout_OnAttachListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.widget.ContentFrameLayout.OnAttachListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedFromWindow:()V:GetOnAttachedFromWindowHandler:Android.Support.V7.Widget.ContentFrameLayout/IOnAttachListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler:Android.Support.V7.Widget.ContentFrameLayout/IOnAttachListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Widget.ContentFrameLayout+IOnAttachListenerImplementor, Xamarin.Android.Support.v7.AppCompat", ContentFrameLayout_OnAttachListenerImplementor.class, __md_methods);
	}


	public ContentFrameLayout_OnAttachListenerImplementor ()
	{
		super ();
		if (getClass () == ContentFrameLayout_OnAttachListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Widget.ContentFrameLayout+IOnAttachListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public void onAttachedFromWindow ()
	{
		n_onAttachedFromWindow ();
	}

	private native void n_onAttachedFromWindow ();


	public void onDetachedFromWindow ()
	{
		n_onDetachedFromWindow ();
	}

	private native void n_onDetachedFromWindow ();

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
