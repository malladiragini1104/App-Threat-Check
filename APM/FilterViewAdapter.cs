using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace APM
{
	public class FilterViewAdapter:BaseAdapter<Application>
	{
		private Activity _context;
		private List<Application> _applications;
		public FilterViewAdapter (Activity context,List<Application> applications)
		{
			this._context = context;
			this._applications = applications;
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			View view = convertView; 
			if (view == null)
				view = _context.LayoutInflater.Inflate(APM.Resource.Layout.FilterView, null);

			view.FindViewById<TextView>(APM.Resource.Id.appName).Text = _applications[position].AppName;
			view.FindViewById<ImageView> (APM.Resource.Id.appIcon).SetImageDrawable (_applications [position].Icon);
			return view;
		}

		public override int Count {
			get {
				return _applications.Count;
			}
		}

		#endregion

		#region implemented abstract members of BaseAdapter

		public override Application this [int index] {
			get {
				return _applications [index];
			}
		}

		#endregion
	}
}

