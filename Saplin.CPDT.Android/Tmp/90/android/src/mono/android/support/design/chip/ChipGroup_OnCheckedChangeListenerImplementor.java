package mono.android.support.design.chip;


public class ChipGroup_OnCheckedChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.design.chip.ChipGroup.OnCheckedChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCheckedChanged:(Landroid/support/design/chip/ChipGroup;I)V:GetOnCheckedChanged_Landroid_support_design_chip_ChipGroup_IHandler:Android.Support.Design.Chip.ChipGroup/IOnCheckedChangeListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("Android.Support.Design.Chip.ChipGroup+IOnCheckedChangeListenerImplementor, Xamarin.Android.Support.Design", ChipGroup_OnCheckedChangeListenerImplementor.class, __md_methods);
	}


	public ChipGroup_OnCheckedChangeListenerImplementor ()
	{
		super ();
		if (getClass () == ChipGroup_OnCheckedChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.Design.Chip.ChipGroup+IOnCheckedChangeListenerImplementor, Xamarin.Android.Support.Design", "", this, new java.lang.Object[] {  });
	}


	public void onCheckedChanged (android.support.design.chip.ChipGroup p0, int p1)
	{
		n_onCheckedChanged (p0, p1);
	}

	private native void n_onCheckedChanged (android.support.design.chip.ChipGroup p0, int p1);

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
