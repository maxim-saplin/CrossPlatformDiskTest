package mono.android.support.v7.app;


public class ActionBar_TabListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.app.ActionBar.TabListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTabReselected:(Landroid/support/v7/app/ActionBar$Tab;Landroid/support/v4/app/FragmentTransaction;)V:GetOnTabReselected_Landroid_support_v7_app_ActionBar_Tab_Landroid_support_v4_app_FragmentTransaction_Handler:Android.Support.V7.App.ActionBar/ITabListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"n_onTabSelected:(Landroid/support/v7/app/ActionBar$Tab;Landroid/support/v4/app/FragmentTransaction;)V:GetOnTabSelected_Landroid_support_v7_app_ActionBar_Tab_Landroid_support_v4_app_FragmentTransaction_Handler:Android.Support.V7.App.ActionBar/ITabListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"n_onTabUnselected:(Landroid/support/v7/app/ActionBar$Tab;Landroid/support/v4/app/FragmentTransaction;)V:GetOnTabUnselected_Landroid_support_v7_app_ActionBar_Tab_Landroid_support_v4_app_FragmentTransaction_Handler:Android.Support.V7.App.ActionBar/ITabListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.App.ActionBar+ITabListenerImplementor, Xamarin.Android.Support.v7.AppCompat", ActionBar_TabListenerImplementor.class, __md_methods);
	}


	public ActionBar_TabListenerImplementor ()
	{
		super ();
		if (getClass () == ActionBar_TabListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.App.ActionBar+ITabListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public void onTabReselected (android.support.v7.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1)
	{
		n_onTabReselected (p0, p1);
	}

	private native void n_onTabReselected (android.support.v7.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1);


	public void onTabSelected (android.support.v7.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1)
	{
		n_onTabSelected (p0, p1);
	}

	private native void n_onTabSelected (android.support.v7.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1);


	public void onTabUnselected (android.support.v7.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1)
	{
		n_onTabUnselected (p0, p1);
	}

	private native void n_onTabUnselected (android.support.v7.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1);

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
