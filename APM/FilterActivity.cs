using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace APM
{
	[Activity (Label = "APM", MainLauncher = false)]			
	public class FilterActivity : Activity
	{
		private List<Application> _applications = new List<Application> ();
		private ListView _listView;  
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.FilterBaseView); 
			_listView = FindViewById<ListView>(APM.Resource.Id.filterListView);

			IList<PackageInfo> items = PackageManager.GetInstalledPackages (0); 
			string name = string.Empty;
			if (items != null) {
				if (items.Count > 0){
					foreach (PackageInfo pkg in items) {
						ApplicationInfo applicationInfo = pkg.ApplicationInfo;
						if (applicationInfo.Flags.HasFlag(ApplicationInfoFlags.System)) {
							var appName = pkg.ApplicationInfo.LoadLabelFormatted (PackageManager).ToString();
							var appIcon = pkg.ApplicationInfo.LoadIcon (PackageManager);
							_applications.Add (new Application{
								Package = pkg,
								AppName = appName,
								Icon = appIcon
							});
						}
					}
					_listView.Adapter = new FilterViewAdapter(this,_applications);
					_listView.ItemClick += OnListItemClick;
				}
				else
					NoApplicationFound ();
			} else
				NoApplicationFound ();

		}

		protected void OnListItemClick(object sender,Android.Widget.AdapterView.ItemClickEventArgs e)
		{

		}
		protected void NoApplicationFound()
		{
		}
	}
}

