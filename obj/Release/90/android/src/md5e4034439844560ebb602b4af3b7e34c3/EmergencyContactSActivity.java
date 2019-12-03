package md5e4034439844560ebb602b4af3b7e34c3;


public class EmergencyContactSActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaB.Droid.EmergencyContactSActivity, TheiaBProjectv2", EmergencyContactSActivity.class, __md_methods);
	}


	public EmergencyContactSActivity ()
	{
		super ();
		if (getClass () == EmergencyContactSActivity.class)
			mono.android.TypeManager.Activate ("TheiaB.Droid.EmergencyContactSActivity, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
