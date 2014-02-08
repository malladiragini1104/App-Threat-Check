using System;
using Android.Graphics.Drawables;

namespace APM
{
	public class Permission
	{
		public Permission ()
		{
		}
		public string PermissionName {
			get;
			set;
		}
		public string PermissionColor {
			get;
			set;
		}
		public int PermissionWeightage {
			get;
			set;
		}

		public Drawable Icon {
			get;
			set;
		}

	}
}

