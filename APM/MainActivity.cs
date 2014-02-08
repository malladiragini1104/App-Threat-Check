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
	[Activity (Label = "APM", MainLauncher = true)]
	public class MainActivity : Activity {

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;

			var aButton = new Button (this);
			aButton.Text = "App List";
			aButton.Click += (sender, e) => {
				StartActivity (typeof(SecondActivity));
			};
			layout.AddView (aButton);
			SetContentView (layout);
		}
	}

	[Activity(Label = "Second Screen", MainLauncher = false)]
	public class SecondActivity : ListActivity {
		List<String> itemsName = new List<string> ();
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			//items = pm.GetInstalledApplications (PackageInfoFlags.MetaData) as List<ApplicationInfo>;
			//items = pm.GetInstalledApplications (PackageInfoFlags.Activities);
			//items = PackageManager.GetInstalledPackages (1) as List<PackageInfo>;
			IList<PackageInfo> items = PackageManager.GetInstalledPackages (0); 

			if (items != null) {
				if (items.Count > 0){
					foreach (PackageInfo p in items) {
						ApplicationInfo a = p.ApplicationInfo;
						var name = p.PackageName.Replace ("com.android.", "");
						itemsName.Add (name);


					}
					ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1,itemsName);
			}
				else
					NoApplicationFound ();
			} else
				NoApplicationFound ();
		}

		private void NoApplicationFound(){
			List<string> items = new List<string> ();
			items.Add ("No Application Found");
			ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, items);
		}
	}
		
}


