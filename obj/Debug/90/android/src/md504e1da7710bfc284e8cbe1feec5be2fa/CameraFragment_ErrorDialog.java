package md504e1da7710bfc284e8cbe1feec5be2fa;


public class CameraFragment_ErrorDialog
	extends android.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateDialog:(Landroid/os/Bundle;)Landroid/app/Dialog;:GetOnCreateDialog_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.CameraFragment+ErrorDialog, TheiaBProjectv2", CameraFragment_ErrorDialog.class, __md_methods);
	}


	public CameraFragment_ErrorDialog ()
	{
		super ();
		if (getClass () == CameraFragment_ErrorDialog.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.CameraFragment+ErrorDialog, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}


	public android.app.Dialog onCreateDialog (android.os.Bundle p0)
	{
		return n_onCreateDialog (p0);
	}

	private native android.app.Dialog n_onCreateDialog (android.os.Bundle p0);

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
