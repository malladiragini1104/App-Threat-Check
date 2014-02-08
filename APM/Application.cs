using System;
using Android.Graphics.Drawables;
using Android.Content.PM;
using System.Runtime.Serialization;

namespace APM
{
	[Serializable]
	public class Application 
	{
		public Application ()
		{
		}
		public PackageInfo Package{ get; set;}

		public string AppName {get;set;}

		public Drawable Icon {
			get;
			set;
		}
	}
}

