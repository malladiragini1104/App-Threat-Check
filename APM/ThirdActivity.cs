using System;
using APM;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Content;

namespace APM
{
	[Activity(Label = "Third Screen", MainLauncher = false)]
	public class ThirdActivity : ListActivity {

		//Application Apps = new Application();
		Intent intent = new Intent ();



		//sent permission obj
		protected override void OnCreate(Bundle bundle)
		{
			var appName = this.Intent.GetStringExtra ("appName");
			var application = GetApplication (appName);
		}

		object GetApplication (string appName)
		{
			return new Application ();
		}
	}
}

