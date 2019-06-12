package mono.android.support.v7.media;


public class RemotePlaybackClient_OnMessageReceivedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.media.RemotePlaybackClient.OnMessageReceivedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMessageReceived:(Ljava/lang/String;Landroid/os/Bundle;)V:GetOnMessageReceived_Ljava_lang_String_Landroid_os_Bundle_Handler:Android.Support.V7.Media.RemotePlaybackClient/IOnMessageReceivedListenerInvoker, Xamarin.Android.Support.v7.MediaRouter\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Media.RemotePlaybackClient+IOnMessageReceivedListenerImplementor, Xamarin.Android.Support.v7.MediaRouter", RemotePlaybackClient_OnMessageReceivedListenerImplementor.class, __md_methods);
	}


	public RemotePlaybackClient_OnMessageReceivedListenerImplementor ()
	{
		super ();
		if (getClass () == RemotePlaybackClient_OnMessageReceivedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Media.RemotePlaybackClient+IOnMessageReceivedListenerImplementor, Xamarin.Android.Support.v7.MediaRouter", "", this, new java.lang.Object[] {  });
	}


	public void onMessageReceived (java.lang.String p0, android.os.Bundle p1)
	{
		n_onMessageReceived (p0, p1);
	}

	private native void n_onMessageReceived (java.lang.String p0, android.os.Bundle p1);

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
