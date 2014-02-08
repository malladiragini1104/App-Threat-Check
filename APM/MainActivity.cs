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
 }


