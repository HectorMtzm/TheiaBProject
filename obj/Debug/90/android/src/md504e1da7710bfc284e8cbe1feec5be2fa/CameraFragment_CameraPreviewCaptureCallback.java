package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_CameraPreviewCaptureCallback
	extends android.hardware.camera2.CameraCaptureSession.StateCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onConfigured:(Landroid/hardware/camera2/CameraCaptureSession;)V:GetOnConfigured_Landroid_hardware_camera2_CameraCaptureSession_Handler\n" +
			"n_onConfigureFailed:(Landroid/hardware/camera2/CameraCaptureSession;)V:GetOnConfigureFailed_Landroid_hardware_camera2_CameraCaptureSession_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+CameraPreviewCaptureCallback, TheiaBProjectv2", CameraFragment_CameraPreviewCaptureCallback.class, __md_methods);
	}


	public CameraFragment_CameraPreviewCaptureCallback ()
	{
		super ();
		if (getClass () == CameraFragment_CameraPreviewCaptureCallback.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+CameraPreviewCaptureCallback, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}


	public void onConfigured (android.hardware.camera2.CameraCaptureSession p0)
	{
		n_onConfigured (p0);
	}

	private native void n_onConfigured (android.hardware.camera2.CameraCaptureSession p0);


	public void onConfigureFailed (android.hardware.camera2.CameraCaptureSession p0)
	{
		n_onConfigureFailed (p0);
	}

	private native void n_onConfigureFailed (android.hardware.camera2.CameraCaptureSession p0);

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
