package mono.android.support.transition;


public class Transition_TransitionListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.transition.Transition.TransitionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTransitionCancel:(Landroid/support/transition/Transition;)V:GetOnTransitionCancel_Landroid_support_transition_Transition_Handler:Android.Support.Transitions.Transition/ITransitionListenerInvoker, Xamarin.Android.Support.Transition\n" +
			"n_onTransitionEnd:(Landroid/support/transition/Transition;)V:GetOnTransitionEnd_Landroid_support_transition_Transition_Handler:Android.Support.Transitions.Transition/ITransitionListenerInvoker, Xamarin.Android.Support.Transition\n" +
			"n_onTransitionPause:(Landroid/support/transition/Transition;)V:GetOnTransitionPause_Landroid_support_transition_Transition_Handler:Android.Support.Transitions.Transition/ITransitionListenerInvoker, Xamarin.Android.Support.Transition\n" +
			"n_onTransitionResume:(Landroid/support/transition/Transition;)V:GetOnTransitionResume_Landroid_support_transition_Transition_Handler:Android.Support.Transitions.Transition/ITransitionListenerInvoker, Xamarin.Android.Support.Transition\n" +
			"n_onTransitionStart:(Landroid/support/transition/Transition;)V:GetOnTransitionStart_Landroid_support_transition_Transition_Handler:Android.Support.Transitions.Transition/ITransitionListenerInvoker, Xamarin.Android.Support.Transition\n" +
			"";
		mono.android.Runtime.register ("Android.Support.Transitions.Transition+ITransitionListenerImplementor, Xamarin.Android.Support.Transition", Transition_TransitionListenerImplementor.class, __md_methods);
	}


	public Transition_TransitionListenerImplementor ()
	{
		super ();
		if (getClass () == Transition_TransitionListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Support.Transitions.Transition+ITransitionListenerImplementor, Xamarin.Android.Support.Transition", "", this, new java.lang.Object[] {  });
	}


	public void onTransitionCancel (android.support.transition.Transition p0)
	{
		n_onTransitionCancel (p0);
	}

	private native void n_onTransitionCancel (android.support.transition.Transition p0);


	public void onTransitionEnd (android.support.transition.Transition p0)
	{
		n_onTransitionEnd (p0);
	}

	private native void n_onTransitionEnd (android.support.transition.Transition p0);


	public void onTransitionPause (android.support.transition.Transition p0)
	{
		n_onTransitionPause (p0);
	}

	private native void n_onTransitionPause (android.support.transition.Transition p0);


	public void onTransitionResume (android.support.transition.Transition p0)
	{
		n_onTransitionResume (p0);
	}

	private native void n_onTransitionResume (android.support.transition.Transition p0);


	public void onTransitionStart (android.support.transition.Transition p0)
	{
		n_onTransitionStart (p0);
	}

	private native void n_onTransitionStart (android.support.transition.Transition p0);

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
