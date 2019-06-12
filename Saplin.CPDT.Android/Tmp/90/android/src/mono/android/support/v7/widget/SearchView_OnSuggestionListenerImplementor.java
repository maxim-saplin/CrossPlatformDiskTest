package mono.android.support.v7.widget;


public class SearchView_OnSuggestionListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v7.widget.SearchView.OnSuggestionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSuggestionClick:(I)Z:GetOnSuggestionClick_IHandler:Android.Support.V7.Widget.SearchView/IOnSuggestionListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"n_onSuggestionSelect:(I)Z:GetOnSuggestionSelect_IHandler:Android.Support.V7.Widget.SearchView/IOnSuggestionListenerInvoker, Xamarin.Android.Support.v7.AppCompat\n" +
			"";
		mono.android.Runtime.register ("Android.Support.V7.Widget.SearchView+IOnSuggestionListenerImplementor, Xamarin.Android.Support.v7.AppCompat", SearchView_OnSuggestionListenerImplementor.class, __md_methods);
	}


	public SearchView_OnSuggestionListenerImplementor ()
	{
		super ();
		if (getClass () == SearchView_OnSuggestionListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.V7.Widget.SearchView+IOnSuggestionListenerImplementor, Xamarin.Android.Support.v7.AppCompat", "", this, new java.lang.Object[] {  });
	}


	public boolean onSuggestionClick (int p0)
	{
		return n_onSuggestionClick (p0);
	}

	private native boolean n_onSuggestionClick (int p0);


	public boolean onSuggestionSelect (int p0)
	{
		return n_onSuggestionSelect (p0);
	}

	private native boolean n_onSuggestionSelect (int p0);

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
