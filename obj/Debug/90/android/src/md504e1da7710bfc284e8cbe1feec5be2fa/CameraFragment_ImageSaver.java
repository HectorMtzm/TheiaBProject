package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_ImageSaver
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Runnable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+ImageSaver, TheiaBProjectv2", CameraFragment_ImageSaver.class, __md_methods);
	}


	public CameraFragment_ImageSaver ()
	{
		super ();
		if (getClass () == CameraFragment_ImageSaver.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+ImageSaver, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
