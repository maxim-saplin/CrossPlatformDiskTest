package md51558244f76c53b6aeda52c8a337f2c37;


public class GroupedListViewAdapter
	extends md51558244f76c53b6aeda52c8a337f2c37.ListViewAdapter
	implements
		mono.android.IGCUserPeer,
		android.widget.SectionIndexer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getPositionForSection:(I)I:GetGetPositionForSection_IHandler:Android.Widget.ISectionIndexerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_getSectionForPosition:(I)I:GetGetSectionForPosition_IHandler:Android.Widget.ISectionIndexerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_getSections:()[Ljava/lang/Object;:GetGetSectionsHandler:Android.Widget.ISectionIndexerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.GroupedListViewAdapter, Xamarin.Forms.Platform.Android", GroupedListViewAdapter.class, __md_methods);
	}


	public GroupedListViewAdapter ()
	{
		super ();
		if (getClass () == GroupedListViewAdapter.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.GroupedListViewAdapter, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}

	public GroupedListViewAdapter (android.content.Context p0)
	{
		super ();
		if (getClass () == GroupedListViewAdapter.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.GroupedListViewAdapter, Xamarin.Forms.Platform.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public int getPositionForSection (int p0)
	{
		return n_getPositionForSection (p0);
	}

	private native int n_getPositionForSection (int p0);


	public int getSectionForPosition (int p0)
	{
		return n_getSectionForPosition (p0);
	}

	private native int n_getSectionForPosition (int p0);


	public java.lang.Object[] getSections ()
	{
		return n_getSections ();
	}

	private native java.lang.Object[] n_getSections ();

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
