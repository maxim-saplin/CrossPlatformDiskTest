package md51558244f76c53b6aeda52c8a337f2c37;


public class FormattedStringExtensions_LineHeightSpan
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.text.style.LineHeightSpan,
		android.text.style.ParagraphStyle,
		android.text.style.WrapTogetherSpan
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_chooseHeight:(Ljava/lang/CharSequence;IIIILandroid/graphics/Paint$FontMetricsInt;)V:GetChooseHeight_Ljava_lang_CharSequence_IIIILandroid_graphics_Paint_FontMetricsInt_Handler:Android.Text.Style.ILineHeightSpanInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.Platform.Android.FormattedStringExtensions+LineHeightSpan, Xamarin.Forms.Platform.Android", FormattedStringExtensions_LineHeightSpan.class, __md_methods);
	}


	public FormattedStringExtensions_LineHeightSpan ()
	{
		super ();
		if (getClass () == FormattedStringExtensions_LineHeightSpan.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormattedStringExtensions+LineHeightSpan, Xamarin.Forms.Platform.Android", "", this, new java.lang.Object[] {  });
	}

	public FormattedStringExtensions_LineHeightSpan (android.widget.TextView p0, double p1)
	{
		super ();
		if (getClass () == FormattedStringExtensions_LineHeightSpan.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.Platform.Android.FormattedStringExtensions+LineHeightSpan, Xamarin.Forms.Platform.Android", "Android.Widget.TextView, Mono.Android:System.Double, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public void chooseHeight (java.lang.CharSequence p0, int p1, int p2, int p3, int p4, android.graphics.Paint.FontMetricsInt p5)
	{
		n_chooseHeight (p0, p1, p2, p3, p4, p5);
	}

	private native void n_chooseHeight (java.lang.CharSequence p0, int p1, int p2, int p3, int p4, android.graphics.Paint.FontMetricsInt p5);

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
