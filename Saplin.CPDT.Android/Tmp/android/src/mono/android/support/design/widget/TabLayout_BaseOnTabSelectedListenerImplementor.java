package mono.android.support.design.widget;


public class TabLayout_BaseOnTabSelectedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.TabLayout.BaseOnTabSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTabReselected:(Landroid/support/design/widget/TabLayout$Tab;)V:GetOnTabReselected_Landroid_support_design_widget_TabLayout_Tab_Handler:Android.Support.Design.Widget.TabLayout/IOnTabSelectedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"n_onTabSelected:(Landroid/support/design/widget/TabLayout$Tab;)V:GetOnTabSelected_Landroid_support_design_widget_TabLayout_Tab_Handler:Android.Support.Design.Widget.TabLayout/IOnTabSelectedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"n_onTabUnselected:(Landroid/support/design/widget/TabLayout$Tab;)V:GetOnTabUnselected_Landroid_support_design_widget_TabLayout_Tab_Handler:Android.Support.Design.Widget.TabLayout/IOnTabSelectedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("Android.Support.Design.Widget.TabLayout+IOnTabSelectedListenerImplementor, Xamarin.Android.Support.Design", TabLayout_BaseOnTabSelectedListenerImplementor.class, __md_methods);
	}


	public TabLayout_BaseOnTabSelectedListenerImplementor ()
	{
		super ();
		if (getClass () == TabLayout_BaseOnTabSelectedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.Design.Widget.TabLayout+IOnTabSelectedListenerImplementor, Xamarin.Android.Support.Design", "", this, new java.lang.Object[] {  });
	}


	public void onTabReselected (android.support.design.widget.TabLayout.Tab p0)
	{
		n_onTabReselected (p0);
	}

	private native void n_onTabReselected (android.support.design.widget.TabLayout.Tab p0);


	public void onTabSelected (android.support.design.widget.TabLayout.Tab p0)
	{
		n_onTabSelected (p0);
	}

	private native void n_onTabSelected (android.support.design.widget.TabLayout.Tab p0);


	public void onTabUnselected (android.support.design.widget.TabLayout.Tab p0)
	{
		n_onTabUnselected (p0);
	}

	private native void n_onTabUnselected (android.support.design.widget.TabLayout.Tab p0);

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
