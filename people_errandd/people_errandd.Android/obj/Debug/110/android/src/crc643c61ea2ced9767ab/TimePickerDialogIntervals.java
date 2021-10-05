package crc643c61ea2ced9767ab;


public class TimePickerDialogIntervals
	extends android.app.TimePickerDialog
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setView:(Landroid/view/View;)V:GetSetView_Landroid_view_View_Handler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("people_errandd.Droid.TimePickerDialogIntervals, people_errandd.Android", TimePickerDialogIntervals.class, __md_methods);
	}


	public TimePickerDialogIntervals (android.content.Context p0, android.app.TimePickerDialog.OnTimeSetListener p1, int p2, int p3, boolean p4)
	{
		super (p0, p1, p2, p3, p4);
		if (getClass () == TimePickerDialogIntervals.class)
			mono.android.TypeManager.Activate ("people_errandd.Droid.TimePickerDialogIntervals, people_errandd.Android", "Android.Content.Context, Mono.Android:Android.App.TimePickerDialog+IOnTimeSetListener, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public TimePickerDialogIntervals (android.content.Context p0, int p1, android.app.TimePickerDialog.OnTimeSetListener p2, int p3, int p4, boolean p5)
	{
		super (p0, p1, p2, p3, p4, p5);
		if (getClass () == TimePickerDialogIntervals.class)
			mono.android.TypeManager.Activate ("people_errandd.Droid.TimePickerDialogIntervals, people_errandd.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:Android.App.TimePickerDialog+IOnTimeSetListener, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5 });
	}


	public void setView (android.view.View p0)
	{
		n_setView (p0);
	}

	private native void n_setView (android.view.View p0);


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
