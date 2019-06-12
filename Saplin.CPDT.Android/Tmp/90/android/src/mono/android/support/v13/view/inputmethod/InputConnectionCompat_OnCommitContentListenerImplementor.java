package mono.android.support.v13.view.inputmethod;


public class InputConnectionCompat_OnCommitContentListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v13.view.inputmethod.InputConnectionCompat.OnCommitContentListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCommitContent:(Landroid/support/v13/view/inputmethod/InputContentInfoCompat;ILandroid/os/Bundle;)Z:GetOnCommitContent_Landroid_support_v13_view_inputmethod_InputContentInfoCompat_ILandroid_os_Bundle_Handler:Android.Support.V13.View.Inputmethod.InputConnectionCompat/IOnCommitContentListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V13.View.Inputmethod.InputConnectionCompat+IOnCommitContentListenerImplementor, Xamarin.Android.Support.Compat", InputConnectionCompat_OnCommitContentListenerImplementor.class, __md_methods);
	}


	public InputConnectionCompat_OnCommitContentListenerImplementor ()
	{
		super ();
		if (getClass () == InputConnectionCompat_OnCommitContentListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V13.View.Inputmethod.InputConnectionCompat+IOnCommitContentListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public boolean onCommitContent (android.support.v13.view.inputmethod.InputContentInfoCompat p0, int p1, android.os.Bundle p2)
	{
		return n_onCommitContent (p0, p1, p2);
	}

	private native boolean n_onCommitContent (android.support.v13.view.inputmethod.InputContentInfoCompat p0, int p1, android.os.Bundle p2);

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
