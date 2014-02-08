using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using System.Collections.Generic;
using Android.Content.PM;

namespace APM
{
	[Activity(Label = "Second Screen", MainLauncher = false)]
	public class SecondActivity : ListActivity {
		List<Application> Apps = new List<Application> ();
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			//items = pm.GetInstalledApplications (PackageInfoFlags.MetaData) as List<ApplicationInfo>;
			//items = pm.GetInstalledApplications (PackageInfoFlags.Activities);
			//items = PackageManager.GetInstalledPackages (1) as List<PackageInfo>;
			IList<PackageInfo> items = PackageManager.GetInstalledPackages (0); 
			string name = string.Empty;
			if (items != null) {
				if (items.Count > 0){
					foreach (PackageInfo p in items) {
						ApplicationInfo a = p.ApplicationInfo;
						if (!a.Flags.HasFlag (ApplicationInfoFlags.System)) {
							//name = p.PackageName.Replace ("com.android.", "");
							var appName = p.ApplicationInfo.LoadLabel (PackageManager).ToString();
							var appIcon = p.ApplicationInfo.LoadIcon (PackageManager);
							//itemsName.Add (name);
							Apps.Add (new Application{
								AppName = appName,
								Icon = appIcon
							});
						}
					}
					ListAdapter = new HomeScreenAdapter (this, Apps);
				}
				else
					NoApplicationFound ();
			} else
				NoApplicationFound ();
		}
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			var t = Apps[position];
			Android.Widget.Toast.MakeText(this, t.AppName, Android.Widget.ToastLength.Short).Show();
		}

		private void NoApplicationFound(){
			List<string> items = new List<string> ();
			items.Add ("No Application Found");
			ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, items);
		}

	}
}

