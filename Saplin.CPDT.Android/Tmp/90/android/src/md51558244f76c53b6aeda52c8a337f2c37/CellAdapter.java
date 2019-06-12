package md51558244f76c53b6aeda52c8a337f2c37;


public abstract class CellAdapter
	extends android.widget.BaseAdapter
	implements
		mono.android.IGCUserPeer,
		android.widget.AdapterView.OnItemLongClickListener,
		android.view.ActionMode.Callback,
		android.widget.AdapterView.OnItemClickListener,
		android.support.v7.view.ActionMode.Callback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onItemLongClick:(Landroid/widget/AdapterView;Landroid/view/View;IJ)Z:GetOnItemLongClick_Landroid_widget_AdapterView_Landroid_view_View_IJHandler:Android.Widget.AdapterView/IOnItemLongClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onActionItemClicked:(Landroid/view/ActionMode;Landroid/view/MenuItem;)Z:GetOnActionItemClicked_Landroid_view_ActionMode_Landroid_view_MenuItem_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onCreateActionMode:(Landroid/view/ActionMode;Landroid/view/Menu;)Z:GetOnCreateActionMode_Landroid_view_ActionMode_Landroid_view_Menu_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onDestroyActionMode:(Landroid/view/ActionMode;)V:GetOnDestroyActionMode_Landroid_view_ActionMode_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onPrepareActionMode:(Landroid/view/ActionMode;Landroid/view/Menu;)Z:GetOnPrepareActionMode_Landroid_view_ActionMode_Landroid_view_Menu_Handler:Android.Views.ActionMode/ICallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onItemClick:(Landroid/widget/AdapterView;Landroid/view/View;IJ)V:GetOnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJHandler:Android.Widget.AdapterView/IOnItemClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onActionItemClicked:(Landroid/support/v7/view/ActionMode;Landroid/view/MenuItem;)Z:GetOnActionItemClicked_Landroid_support_v7_view_ActionMode_Landroid_view_MenuItem_Handler:Android.Support.V7.View.ActionMode/ICallbackInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"n_onCreateActionMode:(Landroid/support/v7/view/ActionMode;Landroid/view/Menu;)Z:GetOnCreateActionMode_Landroid_support_v7_view_ActionMode_Landroid_view_Menu_Handler:Android.Support.V7.View.ActionMode/ICallbackInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"n_onDestroyActionMode:(Landroid/support/v7/view/ActionMode;)V:GetOnDestroyActionMode_Landroid_support_v7_view_ActionMode_Handler:Android.Support.V7.View.ActionMode/ICallbackInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"n_onPrepareActionMode:(Landroid/support/v7/view/ActionMode;Landroid/view/Menu;)Z:GetOnPrepareActionMode_Landroid_support_v7_view_ActionMode_Landroid_view_Menu_Handler:Android.Support.V7.View.ActionMode/ICallbackInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.CellAdapter, Xamarin.Forms.Platform.Android", CellAdapter.class, __md_methods);
	}


	public CellAdapter ()
	{
		super ();
		if (getClass () == CellAdapter.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CellAdapter, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}

	public CellAdapter (android.content.Context p0)
	{
		super ();
		if (getClass () == CellAdapter.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.CellAdapter, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public boolean onItemLongClick (android.widget.AdapterView p0, android.view.View p1, int p2, long p3)
	{
		return n_onItemLongClick (p0, p1, p2, p3);
	}

	private native boolean n_onItemLongClick (android.widget.AdapterView p0, android.view.View p1, int p2, long p3);


	public boolean onActionItemClicked (android.view.ActionMode p0, android.view.MenuItem p1)
	{
		return n_onActionItemClicked (p0, p1);
	}

	private native boolean n_onActionItemClicked (android.view.ActionMode p0, android.view.MenuItem p1);


	public boolean onCreateActionMode (android.view.ActionMode p0, android.view.Menu p1)
	{
		return n_onCreateActionMode (p0, p1);
	}

	private native boolean n_onCreateActionMode (android.view.ActionMode p0, android.view.Menu p1);


	public void onDestroyActionMode (android.view.ActionMode p0)
	{
		n_onDestroyActionMode (p0);
	}

	private native void n_onDestroyActionMode (android.view.ActionMode p0);


	public boolean onPrepareActionMode (android.view.ActionMode p0, android.view.Menu p1)
	{
		return n_onPrepareActionMode (p0, p1);
	}

	private native boolean n_onPrepareActionMode (android.view.ActionMode p0, android.view.Menu p1);


	public void onItemClick (android.widget.AdapterView p0, android.view.View p1, int p2, long p3)
	{
		n_onItemClick (p0, p1, p2, p3);
	}

	private native void n_onItemClick (android.widget.AdapterView p0, android.view.View p1, int p2, long p3);


	public boolean onActionItemClicked (android.support.v7.view.ActionMode p0, android.view.MenuItem p1)
	{
		return n_onActionItemClicked (p0, p1);
	}

	private native boolean n_onActionItemClicked (android.support.v7.view.ActionMode p0, android.view.MenuItem p1);


	public boolean onCreateActionMode (android.support.v7.view.ActionMode p0, android.view.Menu p1)
	{
		return n_onCreateActionMode (p0, p1);
	}

	private native boolean n_onCreateActionMode (android.support.v7.view.ActionMode p0, android.view.Menu p1);


	public void onDestroyActionMode (android.support.v7.view.ActionMode p0)
	{
		n_onDestroyActionMode (p0);
	}

	private native void n_onDestroyActionMode (android.support.v7.view.ActionMode p0);


	public boolean onPrepareActionMode (android.support.v7.view.ActionMode p0, android.view.Menu p1)
	{
		return n_onPrepareActionMode (p0, p1);
	}

	private native boolean n_onPrepareActionMode (android.support.v7.view.ActionMode p0, android.view.Menu p1);

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
