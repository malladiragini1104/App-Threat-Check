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
		List<string> items;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			PackageManager pm = PackageManager;
			items = pm.GetInstalledApplications (PackageInfoFlags.Activities) as List<string>;
			Intent mainIntent = new Intent(Intent.Action, null);
			mainIntent.AddCategory(Intent.CategoryLauncher);
			List<PackageItemInfo> pkgAppsList = PackageManager.QueryIntentActivities(mainIntent,0) as List<PackageItemInfo>;

			if (items != null) {
				if (items.Count > 0)
					ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, items);
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


