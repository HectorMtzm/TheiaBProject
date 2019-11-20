package md504e1da7710bfc284e8cbe1feec5be2fa;


public class SettMenuActivity
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
		mono.android.Runtime.register ("TheiaBProjectv2.SettMenuActivity, TheiaBProjectv2", SettMenuActivity.class, __md_methods);
	}


	public SettMenuActivity ()
	{
		super ();
		if (getClass () == SettMenuActivity.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.SettMenuActivity, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
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
