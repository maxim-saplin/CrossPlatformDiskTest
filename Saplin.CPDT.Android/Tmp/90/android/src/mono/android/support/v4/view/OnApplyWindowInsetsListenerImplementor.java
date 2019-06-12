package mono.android.support.v4.view;


public class OnApplyWindowInsetsListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.OnApplyWindowInsetsListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onApplyWindowInsets:(Landroid/view/View;Landroid/support/v4/view/WindowInsetsCompat;)Landroid/support/v4/view/WindowInsetsCompat;:GetOnApplyWindowInsets_Landroid_view_View_Landroid_support_v4_view_WindowInsetsCompat_Handler:Android.Support.V4.View.IOnApplyWindowInsetsListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.View.IOnApplyWindowInsetsListenerImplementor, Xamarin.Android.Support.Compat", OnApplyWindowInsetsListenerImplementor.class, __md_methods);
	}


	public OnApplyWindowInsetsListenerImplementor ()
	{
		super ();
		if (getClass () == OnApplyWindowInsetsListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.View.IOnApplyWindowInsetsListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public android.support.v4.view.WindowInsetsCompat onApplyWindowInsets (android.view.View p0, android.support.v4.view.WindowInsetsCompat p1)
	{
		return n_onApplyWindowInsets (p0, p1);
	}

	private native android.support.v4.view.WindowInsetsCompat n_onApplyWindowInsets (android.view.View p0, android.support.v4.view.WindowInsetsCompat p1);

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
