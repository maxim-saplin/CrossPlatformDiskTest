package md51558244f76c53b6aeda52c8a337f2c37;


public class EndSingleSnapHelper
	extends md51558244f76c53b6aeda52c8a337f2c37.SingleSnapHelper
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_calculateDistanceToFinalSnap:(Landroid/support/v7/widget/RecyclerView$LayoutManager;Landroid/view/View;)[I:GetCalculateDistanceToFinalSnap_Landroid_support_v7_widget_RecyclerView_LayoutManager_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.EndSingleSnapHelper, Xamarin.Forms.Platform.Android", EndSingleSnapHelper.class, __md_methods);
	}


	public EndSingleSnapHelper ()
	{
		super ();
		if (getClass () == EndSingleSnapHelper.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.EndSingleSnapHelper, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public int[] calculateDistanceToFinalSnap (android.support.v7.widget.RecyclerView.LayoutManager p0, android.view.View p1)
	{
		return n_calculateDistanceToFinalSnap (p0, p1);
	}

	private native int[] n_calculateDistanceToFinalSnap (android.support.v7.widget.RecyclerView.LayoutManager p0, android.view.View p1);

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
