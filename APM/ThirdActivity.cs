using System;
using APM;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Content;
using Android.Content.PM;
using Android.Widget;

namespace APM
{
	[Activity(Label = "Third Screen", MainLauncher = false)]
	public class ThirdActivity : Activity {

		List<Permission> Perms = new List<Permission>();
		Intent intent = new Intent ();
		ListView listView;

		public static Dictionary<string,int> PermissionDictionary = new Dictionary<string,int>() {
			{"READ_SMS",5 },
			{"SEND_SMS",4 },
			{"READ_CONTACTS",5 },
			{"REBOOT",4 },
			{"INTERNET",5 },
			{"ACCESS_COARSE_LOCATION",3 },
			{"ACCESS_FINE_LOCATION",4 },
			{"WRITE_EXTERNAL_STORAGE",3 },
			{"READ_HISTORY_BOOKMARKS",3 }
		};

		protected override void OnCreate(Bundle bundle)
		{
			var appName = this.Intent.GetStringExtra ("appName");
			var application = GetApplication (appName);
			var permissionList = GetPermissions (application);
			base.OnCreate (bundle);
			SetContentView (APM.Resource.Layout.ThirdScreen); // loads the HomeScreen.axml as this activity's view
			listView = FindViewById<ListView> (APM.Resource.Id.List1); // get reference to the ListView in the layout
//// populate the listview with data
//
			IList<Permission> items = permissionList; 
			string name = string.Empty;
			if (items != null) {
				if (items.Count > 0) {
					foreach (Permission p in items) {
					



						var nameOfPerm = p.PermissionName;
						var permIcon = p.Icon;

						Perms.Add (new Permission {

							PermissionName = nameOfPerm,
							Icon = permIcon
						});
						
					}
					listView.Adapter = new ThirdActivityAdapter (this, Perms);
					//listView.ItemClick += OnListItemClick;
				}

			}
		}	

		private Application GetApplication (string appName)
		{
			IList<PackageInfo> items = PackageManager.GetInstalledPackages (PackageInfoFlags.Permissions);
			foreach (var item in items) {
				if(string.Equals(item.ApplicationInfo.LoadLabel(PackageManager),appName))
				{
					return new APM.Application () {
						AppName = appName,
						Icon = item.ApplicationInfo.LoadIcon(PackageManager),
						Package = item
					};
			}
			}
			return new APM.Application();
		}

		List<Permission> GetPermissions (APM.Application application)
		{
			var permissionList = new List<Permission> ();
			var permissionItems = application.Package.RequestedPermissions;
			try{
			foreach (var permission in permissionItems) {

				permissionList.Add (new Permission () {
						PermissionName = permission.Replace ("android.permission.", "").Replace("_"," "),
					
					                 
					//Icon = permission.LoadIcon(PackageManager)
				});
				}}
			catch(Exception e){
				NullReferenceException nre;}
			//SetWeightageForPermission (permissionList);
			return permissionList;
			//write gamma function to map color and weightage against name
		}

		void SetWeightageForPermission (List<Permission> permissionList)
		{

		}
	}
}

