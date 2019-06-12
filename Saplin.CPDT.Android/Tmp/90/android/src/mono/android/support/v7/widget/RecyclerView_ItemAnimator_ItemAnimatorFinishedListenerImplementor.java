package mono.android.support.v7.widget;


public class RecyclerView_ItemAnimator_ItemAnimatorFinishedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.widget.RecyclerView.ItemAnimator.ItemAnimatorFinishedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnimationsFinished:()V:GetOnAnimationsFinishedHandler:Android.Support.V7.Widget.RecyclerView/ItemAnimator/IItemAnimatorFinishedListenerInvoker, Xamarin.Android.Support.v7.RecyclerView\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Widget.RecyclerView+ItemAnimator+IItemAnimatorFinishedListenerImplementor, Xamarin.Android.Support.v7.RecyclerView", RecyclerView_ItemAnimator_ItemAnimatorFinishedListenerImplementor.class, __md_methods);
	}


	public RecyclerView_ItemAnimator_ItemAnimatorFinishedListenerImplementor ()
	{
		super ();
		if (getClass () == RecyclerView_ItemAnimator_ItemAnimatorFinishedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Widget.RecyclerView+ItemAnimator+IItemAnimatorFinishedListenerImplementor, Xamarin.Android.Support.v7.RecyclerView", "", this, new java.lang.Object[] {  });
	}


	public void onAnimationsFinished ()
	{
		n_onAnimationsFinished ();
	}

	private native void n_onAnimationsFinished ();

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
