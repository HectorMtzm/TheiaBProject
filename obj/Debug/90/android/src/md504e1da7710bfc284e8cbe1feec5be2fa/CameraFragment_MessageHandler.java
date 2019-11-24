package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_MessageHandler
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleMessage:(Landroid/os/Message;)V:GetHandleMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+MessageHandler, TheiaBProjectv2", CameraFragment_MessageHandler.class, __md_methods);
	}


	public CameraFragment_MessageHandler ()
	{
		super ();
		if (getClass () == CameraFragment_MessageHandler.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+MessageHandler, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}


	public CameraFragment_MessageHandler (android.os.Handler.Callback p0)
	{
		super (p0);
		if (getClass () == CameraFragment_MessageHandler.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+MessageHandler, TheiaBProjectv2", "Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CameraFragment_MessageHandler (android.os.Looper p0)
	{
		super (p0);
		if (getClass () == CameraFragment_MessageHandler.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+MessageHandler, TheiaBProjectv2", "Android.OS.Looper, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CameraFragment_MessageHandler (android.os.Looper p0, android.os.Handler.Callback p1)
	{
		super (p0, p1);
		if (getClass () == CameraFragment_MessageHandler.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+MessageHandler, TheiaBProjectv2", "Android.OS.Looper, Mono.Android:Android.OS.Handler+ICallback, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

	public CameraFragment_MessageHandler (android.os.Looper p0, android.app.Activity p1)
	{
		super ();
		if (getClass () == CameraFragment_MessageHandler.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+MessageHandler, TheiaBProjectv2", "Android.OS.Looper, Mono.Android:Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void handleMessage (android.os.Message p0)
	{
		n_handleMessage (p0);
	}

	private native void n_handleMessage (android.os.Message p0);

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
