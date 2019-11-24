package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_OrientationListener
	extends android.view.OrientationEventListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOrientationChanged:(I)V:GetOnOrientationChanged_IHandler\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+OrientationListener, TheiaBProjectv2", CameraFragment_OrientationListener.class, __md_methods);
	}


	public CameraFragment_OrientationListener (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CameraFragment_OrientationListener.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+OrientationListener, TheiaBProjectv2", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CameraFragment_OrientationListener (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == CameraFragment_OrientationListener.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+OrientationListener, TheiaBProjectv2", "Android.Content.Context, Mono.Android:Android.Hardware.SensorDelay, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void onOrientationChanged (int p0)
	{
		n_onOrientationChanged (p0);
	}

	private native void n_onOrientationChanged (int p0);

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
