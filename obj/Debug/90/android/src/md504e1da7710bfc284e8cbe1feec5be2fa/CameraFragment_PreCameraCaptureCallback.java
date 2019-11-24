package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_PreCameraCaptureCallback
	extends android.hardware.camera2.CameraCaptureSession.CaptureCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCaptureProgressed:(Landroid/hardware/camera2/CameraCaptureSession;Landroid/hardware/camera2/CaptureRequest;Landroid/hardware/camera2/CaptureResult;)V:GetOnCaptureProgressed_Landroid_hardware_camera2_CameraCaptureSession_Landroid_hardware_camera2_CaptureRequest_Landroid_hardware_camera2_CaptureResult_Handler\n" +
			"n_onCaptureCompleted:(Landroid/hardware/camera2/CameraCaptureSession;Landroid/hardware/camera2/CaptureRequest;Landroid/hardware/camera2/TotalCaptureResult;)V:GetOnCaptureCompleted_Landroid_hardware_camera2_CameraCaptureSession_Landroid_hardware_camera2_CaptureRequest_Landroid_hardware_camera2_TotalCaptureResult_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+PreCameraCaptureCallback, TheiaBProjectv2", CameraFragment_PreCameraCaptureCallback.class, __md_methods);
	}


	public CameraFragment_PreCameraCaptureCallback ()
	{
		super ();
		if (getClass () == CameraFragment_PreCameraCaptureCallback.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+PreCameraCaptureCallback, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}

	public CameraFragment_PreCameraCaptureCallback (android.app.Activity p0)
	{
		super ();
		if (getClass () == CameraFragment_PreCameraCaptureCallback.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+PreCameraCaptureCallback, TheiaBProjectv2", "Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onCaptureProgressed (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.CaptureResult p2)
	{
		n_onCaptureProgressed (p0, p1, p2);
	}

	private native void n_onCaptureProgressed (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.CaptureResult p2);


	public void onCaptureCompleted (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.TotalCaptureResult p2)
	{
		n_onCaptureCompleted (p0, p1, p2);
	}

	private native void n_onCaptureCompleted (android.hardware.camera2.CameraCaptureSession p0, android.hardware.camera2.CaptureRequest p1, android.hardware.camera2.TotalCaptureResult p2);

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
