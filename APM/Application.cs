using System;
using Android.Graphics.Drawables;
using Android.Content.PM;
using System.Runtime.Serialization;

namespace APM
{
	[Serializable]
	public class Application :ISerializable
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

		#region ISerializable implementation

		public void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

