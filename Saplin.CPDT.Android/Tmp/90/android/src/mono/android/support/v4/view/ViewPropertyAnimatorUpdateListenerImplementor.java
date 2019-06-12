package mono.android.support.v4.view;


public class ViewPropertyAnimatorUpdateListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPropertyAnimatorUpdateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationUpdate:(Landroid/view/View;)V:GetOnAnimationUpdate_Landroid_view_View_Handler:Android.Support.V4.View.IViewPropertyAnimatorUpdateListenerInvoker, Xamarin.Android.Support.Compat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V4.View.IViewPropertyAnimatorUpdateListenerImplementor, Xamarin.Android.Support.Compat", ViewPropertyAnimatorUpdateListenerImplementor.class, __md_methods);
	}


	public ViewPropertyAnimatorUpdateListenerImplementor ()
	{
		super ();
		if (getClass () == ViewPropertyAnimatorUpdateListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V4.View.IViewPropertyAnimatorUpdateListenerImplementor, Xamarin.Android.Support.Compat", "", this, new java.lang.Object[] {  });
	}


	public void onAnimationUpdate (android.view.View p0)
	{
		n_onAnimationUpdate (p0);
	}

	private native void n_onAnimationUpdate (android.view.View p0);

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
