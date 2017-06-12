package md552017f9f5cea3f0822b9ca48f4428903;


public class ActivityPlace
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
		mono.android.Runtime.register ("HotChickFinder.ActivityPlace, HotChickFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ActivityPlace.class, __md_methods);
	}


	public ActivityPlace () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivityPlace.class)
			mono.android.TypeManager.Activate ("HotChickFinder.ActivityPlace, HotChickFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
