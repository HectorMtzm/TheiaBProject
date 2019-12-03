package md5ed0f903f771f33f5c56098cb27c96e38;


public class AlertFragment
	extends android.support.v4.app.DialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TheiaBProjectv2.Fragments.AlertFragment, TheiaBProjectv2", AlertFragment.class, __md_methods);
	}


	public AlertFragment ()
	{
		super ();
		if (getClass () == AlertFragment.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.Fragments.AlertFragment, TheiaBProjectv2", "", this, new java.lang.Object[] {  });
	}

	public AlertFragment (java.lang.String p0, int p1)
	{
		super ();
		if (getClass () == AlertFragment.class)
			mono.android.TypeManager.Activate ("TheiaBProjectv2.Fragments.AlertFragment, TheiaBProjectv2", "System.String, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
