package md55118afb754a471e5915ddcc7bb49e4f4;


public class GestureRecognizerView_MyScaleListener
	extends android.view.ScaleGestureDetector.SimpleOnScaleGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScale:(Landroid/view/ScaleGestureDetector;)Z:GetOnScale_Landroid_view_ScaleGestureDetector_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaB.Droid.GestureRecognizerView+MyScaleListener, TheiaB.Droid", GestureRecognizerView_MyScaleListener.class, __md_methods);
	}


	public GestureRecognizerView_MyScaleListener ()
	{
		super ();
		if (getClass () == GestureRecognizerView_MyScaleListener.class)
			mono.android.TypeManager.Activate ("TheiaB.Droid.GestureRecognizerView+MyScaleListener, TheiaB.Droid", "", this, new java.lang.Object[] {  });
	}

	public GestureRecognizerView_MyScaleListener (md55118afb754a471e5915ddcc7bb49e4f4.GestureRecognizerView p0)
	{
		super ();
		if (getClass () == GestureRecognizerView_MyScaleListener.class)
			mono.android.TypeManager.Activate ("TheiaB.Droid.GestureRecognizerView+MyScaleListener, TheiaB.Droid", "TheiaB.Droid.GestureRecognizerView, TheiaB.Droid", this, new java.lang.Object[] { p0 });
	}


	public boolean onScale (android.view.ScaleGestureDetector p0)
	{
		return n_onScale (p0);
	}

	private native boolean n_onScale (android.view.ScaleGestureDetector p0);

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
