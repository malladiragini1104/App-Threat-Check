using System;
using Android.App;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;

namespace APM
{

	public class ThirdActivityAdapter : BaseAdapter <Permission>
	{ 
		List<Permission> items;
		Activity context;
		public ThirdActivityAdapter(Activity context, List<Permission> items) : base() {
			this.context = context;
			this.items = items;
		}

		#region implemented abstract members of BaseAdapter
		public override long GetItemId (int position)
		{
			return position;
		}
		public override int Count {
			get {
				 return items.Count; 
			}
		}
		#endregion
		#region implemented abstract members of BaseAdapter
		public override Permission this [int index] {
			get {
				return items [index]; 
			}
		}
		#endregion
	


		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(APM.Resource.Layout.CustomThirdScreenView, null);

			view.FindViewById<TextView>(APM.Resource.Id.Text1).Text = items[position].PermissionName;
			//view.FindViewById<ImageView> (APM.Resource.Id.Image).SetImageDrawable (items [position].Icon);
			//view.FindViewById<ImageView> (APM.Resource.Id.PImage4).SetWillNotDraw (true);

			return view;
		}
	}
}

