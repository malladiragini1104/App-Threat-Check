using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;

namespace APM
{
	[Activity(Label = "Third Screen", MainLauncher = false)]
	public class ThirdActivity : ListActivity {

		Application Apps = new Application();

		//sent permission obj
		protected override void OnCreate(Bundle bundle)
		{
		}
	}
}

