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


	[Activity]
	public class ApplicationActivity : Activity {
		List<Application> Apps = new List<Application> ();
		ListView listView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.ApplicationView); // loads the HomeScreen.axml as this activity's view
			listView = FindViewById<ListView>(Resource.Id.List); // get reference to the ListView in the layout
			// populate the listview with data

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
								Package = p,
								AppName = appName,
								Icon = appIcon
							});
						}
					}
					listView.Adapter = new HomeScreenAdapter(this,Apps);
					listView.ItemClick += OnListItemClick;
				}
				else
					NoApplicationFound ();
			} else
				NoApplicationFound ();
		}

		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{

			var listView = sender as ListView;
			var t = Apps[e.Position]; 
			Android.Widget.Toast.MakeText(this, t.AppName, Android.Widget.ToastLength.Short).Show();
			Intent intent = new Intent(this,typeof(ThirdActivity));
			intent.PutExtra("appName",t.AppName);
			StartActivity (intent);
		}

		private void NoApplicationFound(){
			List<string> items = new List<string> ();
			items.Add ("No Application Found");
			//listView.Adapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, items);
		}
	}
 }


