package android.support.v7.app;


public class AlertDialog_IDialogInterfaceOnClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.content.DialogInterface.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/content/DialogInterface;I)V:GetOnClick_Landroid_content_DialogInterface_IHandler:Android.Content.IDialogInterfaceOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.App.AlertDialog+IDialogInterfaceOnClickListenerImplementor, Xamarin.Android.Support.v7.AppCompat", AlertDialog_IDialogInterfaceOnClickListenerImplementor.class, __md_methods);
	}


	public AlertDialog_IDialogInterfaceOnClickListenerImplementor ()
	{
		super ();
		if (getClass () == AlertDialog_IDialogInterfaceOnClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.App.AlertDialog+IDialogInterfaceOnClickListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public void onClick (android.content.DialogInterface p0, int p1)
	{
		n_onClick (p0, p1);
	}

	private native void n_onClick (android.content.DialogInterface p0, int p1);

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
