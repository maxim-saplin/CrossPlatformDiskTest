package md51558244f76c53b6aeda52c8a337f2c37;


public class CenterSnapHelper
	extends md51558244f76c53b6aeda52c8a337f2c37.NongreedySnapHelper
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_findSnapView:(Landroid/support/v7/widget/RecyclerView$LayoutManager;)Landroid/view/View;:GetFindSnapView_Landroid_support_v7_widget_RecyclerView_LayoutManager_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.CenterSnapHelper, Xamarin.Forms.Platform.Android", CenterSnapHelper.class, __md_methods);
	}


	public CenterSnapHelper ()
	{
		super ();
		if (getClass () == CenterSnapHelper.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CenterSnapHelper, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}


	public android.view.View findSnapView (android.support.v7.widget.RecyclerView.LayoutManager p0)
	{
		return n_findSnapView (p0);
	}

	private native android.view.View n_findSnapView (android.support.v7.widget.RecyclerView.LayoutManager p0);

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
