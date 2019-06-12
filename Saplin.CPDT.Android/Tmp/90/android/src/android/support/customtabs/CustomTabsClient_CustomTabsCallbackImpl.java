package android.support.customtabs;


public class CustomTabsClient_CustomTabsCallbackImpl
	extends android.support.customtabs.CustomTabsCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNavigationEvent:(ILandroid/os/Bundle;)V:GetOnNavigationEvent_ILandroid_os_Bundle_Handler\n" +
			"n_extraCallback:(Ljava/lang/String;Landroid/os/Bundle;)V:GetExtraCallback_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Android.Support.CustomTabs.CustomTabsClient+CustomTabsCallbackImpl, Xamarin.Android.Support.CustomTabs", CustomTabsClient_CustomTabsCallbackImpl.class, __md_methods);
	}


	public CustomTabsClient_CustomTabsCallbackImpl ()
	{
		super ();
		if (getClass () == CustomTabsClient_CustomTabsCallbackImpl.class)
			mono.android.TypeManager.Activate ("Android.Support.CustomTabs.CustomTabsClient+CustomTabsCallbackImpl, Xamarin.Android.Support.CustomTabs", "", this, new java.lang.Object[] {  });
	}


	public void onNavigationEvent (int p0, android.os.Bundle p1)
	{
		n_onNavigationEvent (p0, p1);
	}

	private native void n_onNavigationEvent (int p0, android.os.Bundle p1);


	public void extraCallback (java.lang.String p0, android.os.Bundle p1)
	{
		n_extraCallback (p0, p1);
	}

	private native void n_extraCallback (java.lang.String p0, android.os.Bundle p1);

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
