package mono.android.support.v7.widget;


public class PopupMenu_OnDismissListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.widget.PopupMenu.OnDismissListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDismiss:(Landroid/support/v7/widget/PopupMenu;)V:GetOnDismiss_Landroid_support_v7_widget_PopupMenu_Handler:Android.Support.V7.Widget.PopupMenu/IOnDismissListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Widget.PopupMenu+IOnDismissListenerImplementor, Xamarin.Android.Support.v7.AppCompat", PopupMenu_OnDismissListenerImplementor.class, __md_methods);
	}


	public PopupMenu_OnDismissListenerImplementor ()
	{
		super ();
		if (getClass () == PopupMenu_OnDismissListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Widget.PopupMenu+IOnDismissListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public void onDismiss (android.support.v7.widget.PopupMenu p0)
	{
		n_onDismiss (p0);
	}

	private native void n_onDismiss (android.support.v7.widget.PopupMenu p0);

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
