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
								Package = p,
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
			var app = Apps[position];
			Android.Widget.Toast.MakeText(this, app.AppName, Android.Widget.ToastLength.Short).Show();
			//send app details to third screen
			Bundle bun = new Bundle();
			bun.PutSerializable("Apps",app);  
			Intent intent = new Intent(this,typeof(ThirdActivity));
		
			intent.PutExtras(bun);
			StartActivity (intent);
			/*
                       var intent = new Intent(this.BaseContext, new HelloTabWidget().Class); 
                       intent.AddFlags(ActivityFlags.NewTask); 

                       Bundle bun = new Bundle(); 
                       *bun.PutSerializable("test", (BaseData)dat);  * 

                       intent.PutExtras(bun); 
                      StartActivity(intent);
			*/



		}

		private void NoApplicationFound(){
			List<string> items = new List<string> ();
			items.Add ("No Application Found");
			ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, items);
		}

	}
}

