package md51558244f76c53b6aeda52c8a337f2c37;


public class VisualElementTracker_AttachTracker
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnAttachStateChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onViewAttachedToWindow:(Landroid/view/View;)V:GetOnViewAttachedToWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onViewDetachedFromWindow:(Landroid/view/View;)V:GetOnViewDetachedFromWindow_Landroid_view_View_Handler:Android.Views.View/IOnAttachStateChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.VisualElementTracker+AttachTracker, Xamarin.Forms.Platform.Android", VisualElementTracker_AttachTracker.class, __md_methods);
	}


	public VisualElementTracker_AttachTracker ()
	{
		super ();
		if (getClass () == VisualElementTracker_AttachTracker.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.VisualElementTracker+AttachTracker, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public void onViewAttachedToWindow (android.view.View p0)
	{
		n_onViewAttachedToWindow (p0);
	}

	private native void n_onViewAttachedToWindow (android.view.View p0);


	public void onViewDetachedFromWindow (android.view.View p0)
	{
		n_onViewDetachedFromWindow (p0);
	}

	private native void n_onViewDetachedFromWindow (android.view.View p0);

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
