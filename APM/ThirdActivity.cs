using System;
using APM;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Content;
using Android.Content.PM;

namespace APM
{
	[Activity(Label = "Third Screen", MainLauncher = false)]
	public class ThirdActivity : ListActivity {

		//Application Apps = new Application();
		Intent intent = new Intent ();



		//sent permission obj
		protected override void OnCreate(Bundle bundle)
		{
//			var appName = this.Intent.GetStringExtra ("appName");
//			var application = GetApplication (appName);
//			var permissionList = GetPermissions (application);
//			base.OnCreate(bundle);
//			//items = pm.GetInstalledApplications (PackageInfoFlags.MetaData) as List<ApplicationInfo>;
//			//items = pm.GetInstalledApplications (PackageInfoFlags.Activities);
//			//items = PackageManager.GetInstalledPackages (1) as List<PackageInfo>;
//			SetContentView(Resource.Layout.ThirdScreen); // loads the HomeScreen.axml as this activity's view
//			//listView = FindViewById<ListView>(Resource.Id.List); // get reference to the ListView in the layout
//// populate the listview with data
//
//			//IList<PackageInfo> items = application; 
//			string name = string.Empty;
//			if (items != null) {
//				if (items.Count > 0){
//					foreach (PackageInfo p in items) {
//						ApplicationInfo a = p.ApplicationInfo;
//						if (!a.Flags.HasFlag (ApplicationInfoFlags.System)) {
//							//name = p.PackageName.Replace ("com.android.", "");
//
//							var nameOfApp = p.ApplicationInfo.LoadLabel (PackageManager).ToString();
//							var appIcon = p.ApplicationInfo.LoadIcon (PackageManager);
//							//itemsName.Add (name);
//							//Apps.Add (new Application{
//								Package = p,
//								AppName = appName,
//								Icon = appIcon
//							});
//						}
//					}
//				//listView.Adapter = new HomeScreenAdapter(this,Apps);
//				//listView.ItemClick += OnListItemClick;
//				}
//				else
//				//NoApplicationFound ();
//				//} else
//			//NoApplicationFound ();
//		}
//
//		private APM.Application GetApplication (string appName)
//		{
////			IList<PackageInfo> items = PackageManager.GetInstalledPackages (0);
////			foreach (var item in items) {
////				if(string.Equals(item.ApplicationInfo.LoadLabel,appName))
////				{
////					return new APM.Application () {
////						AppName = appName,
////						Icon = item.ApplicationInfo.LoadIcon,
////						Package = item
////					};
////				}
////			}
////			return new APM.Application();
		}

		List<Permission> GetPermissions (APM.Application application)
		{
			var permissionList = new List<Permission> ();
			var permissionItems = application.Package.Permissions;
			foreach (var permission in permissionItems) {
				permissionList.Add (new Permission () {
					PermissionName = permission.LoadLabel(PackageManager),
					Icon = permission.LoadIcon(PackageManager)
				});
			}
			SetWeightageForPermission (permissionList);
			return permissionList;
			//write gamma function to map color and weightage against name
		}

		void SetWeightageForPermission (List<Permission> permissionList)
		{

		}
	}
}

