package md529cb9c53b09b4410ec13055bf84596a0;


public class ChatListViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("XamarinLearningSignalR.Adapters.ChatListViewHolder, XamarinLearningSignalR", ChatListViewHolder.class, __md_methods);
	}


	public ChatListViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ChatListViewHolder.class)
			mono.android.TypeManager.Activate ("XamarinLearningSignalR.Adapters.ChatListViewHolder, XamarinLearningSignalR", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
