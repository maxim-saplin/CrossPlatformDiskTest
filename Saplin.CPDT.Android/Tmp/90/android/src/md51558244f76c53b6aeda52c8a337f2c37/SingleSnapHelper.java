package md51558244f76c53b6aeda52c8a337f2c37;


public class SingleSnapHelper
	extends android.support.v7.widget.PagerSnapHelper
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_findSnapView:(Landroid/support/v7/widget/RecyclerView$LayoutManager;)Landroid/view/View;:GetFindSnapView_Landroid_support_v7_widget_RecyclerView_LayoutManager_Handler\n" +
			"n_findTargetSnapPosition:(Landroid/support/v7/widget/RecyclerView$LayoutManager;II)I:GetFindTargetSnapPosition_Landroid_support_v7_widget_RecyclerView_LayoutManager_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.SingleSnapHelper, Xamarin.Forms.Platform.Android", SingleSnapHelper.class, __md_methods);
	}


	public SingleSnapHelper ()
	{
		super ();
		if (getClass () == SingleSnapHelper.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.SingleSnapHelper, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public android.view.View findSnapView (android.support.v7.widget.RecyclerView.LayoutManager p0)
	{
		return n_findSnapView (p0);
	}

	private native android.view.View n_findSnapView (android.support.v7.widget.RecyclerView.LayoutManager p0);


	public int findTargetSnapPosition (android.support.v7.widget.RecyclerView.LayoutManager p0, int p1, int p2)
	{
		return n_findTargetSnapPosition (p0, p1, p2);
	}

	private native int n_findTargetSnapPosition (android.support.v7.widget.RecyclerView.LayoutManager p0, int p1, int p2);

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
