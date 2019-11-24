package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_OnJpegImageAvailableListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.media.ImageReader.OnImageAvailableListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onImageAvailable:(Landroid/media/ImageReader;)V:GetOnImageAvailable_Landroid_media_ImageReader_Handler:Android.Media.ImageReader/IOnImageAvailableListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+OnJpegImageAvailableListener, TheiaBProjectv2", CameraFragment_OnJpegImageAvailableListener.class, __md_methods);
	}


	public CameraFragment_OnJpegImageAvailableListener ()
	{
		super ();
		if (getClass () == CameraFragment_OnJpegImageAvailableListener.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+OnJpegImageAvailableListener, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}


	public void onImageAvailable (android.media.ImageReader p0)
	{
		n_onImageAvailable (p0);
	}

	private native void n_onImageAvailable (android.media.ImageReader p0);

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
