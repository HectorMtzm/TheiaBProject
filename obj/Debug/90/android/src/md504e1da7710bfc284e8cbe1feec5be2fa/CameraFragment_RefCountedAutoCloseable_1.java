package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_RefCountedAutoCloseable_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.AutoCloseable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_close:()V:GetCloseHandler:Java.Lang.IAutoCloseableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+RefCountedAutoCloseable`1, TheiaBProjectv2", CameraFragment_RefCountedAutoCloseable_1.class, __md_methods);
	}


	public CameraFragment_RefCountedAutoCloseable_1 ()
	{
		super ();
		if (getClass () == CameraFragment_RefCountedAutoCloseable_1.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+RefCountedAutoCloseable`1, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}


	public void close ()
	{
		n_close ();
	}

	private native void n_close ();

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
