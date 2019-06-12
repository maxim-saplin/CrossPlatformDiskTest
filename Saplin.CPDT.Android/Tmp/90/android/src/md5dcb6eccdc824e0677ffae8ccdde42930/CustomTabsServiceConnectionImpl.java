package md5dcb6eccdc824e0677ffae8ccdde42930;


public class CustomTabsServiceConnectionImpl
	extends android.support.customtabs.CustomTabsServiceConnection
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCustomTabsServiceConnected:(Landroid/content/ComponentName;Landroid/support/customtabs/CustomTabsClient;)V:GetOnCustomTabsServiceConnected_Landroid_content_ComponentName_Landroid_support_customtabs_CustomTabsClient_Handler\n" +
			"n_onServiceDisconnected:(Landroid/content/ComponentName;)V:GetOnServiceDisconnected_Landroid_content_ComponentName_Handler\n" +
			"";
		mono.android.Runtime.register ("Android.Support.CustomTabs.CustomTabsServiceConnectionImpl, Xamarin.Android.Support.CustomTabs", CustomTabsServiceConnectionImpl.class, __md_methods);
	}


	public CustomTabsServiceConnectionImpl ()
	{
		super ();
		if (getClass () == CustomTabsServiceConnectionImpl.class)
			mono.android.TypeManager.Activate ("Android.Support.CustomTabs.CustomTabsServiceConnectionImpl, Xamarin.Android.Support.CustomTabs", "", this, new java.lang.Object[] {  });
	}


	public void onCustomTabsServiceConnected (android.content.ComponentName p0, android.support.customtabs.CustomTabsClient p1)
	{
		n_onCustomTabsServiceConnected (p0, p1);
	}

	private native void n_onCustomTabsServiceConnected (android.content.ComponentName p0, android.support.customtabs.CustomTabsClient p1);


	public void onServiceDisconnected (android.content.ComponentName p0)
	{
		n_onServiceDisconnected (p0);
	}

	private native void n_onServiceDisconnected (android.content.ComponentName p0);

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
