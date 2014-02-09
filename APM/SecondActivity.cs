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
	[Activity(Label = "Application", MainLauncher = true)]
	public class SecondActivity : TabActivity {

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.HomeScreen);

			CreateTab(typeof(ApplicationActivity), "Application", "Application",0);
			CreateTab(typeof(FilterActivity), "Filter", "Filter",0);
		}
		private void CreateTab(Type activityType, string tag, string label, int drawableId )
		{
			var intent = new Intent(this, activityType);
			intent.AddFlags(ActivityFlags.NewTask);

			var spec = TabHost.NewTabSpec(tag);
			//var drawableIcon = Resources.GetDrawable(drawableId);
			spec.SetIndicator(label);
			spec.SetContent(intent);

			TabHost.AddTab(spec);
		}
	}
}

