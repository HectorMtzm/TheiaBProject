package md5fda3400dcda2600b053c799fd8f68796;


public class AccelerometerTest
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.Activities.AccelerometerTest, TheiaBProjectv2", AccelerometerTest.class, __md_methods);
	}


	public AccelerometerTest ()
	{
		super ();
		if (getClass () == AccelerometerTest.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.Activities.AccelerometerTest, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
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
