using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Runtime;
using Android.Views;

namespace HotChickFinder
{
	public class MyPopUpAdapter : Android.Gms.Maps.GoogleMap.IInfoWindowAdapter
	{




		public MyPopUpAdapter()
		{
			
		}

		IntPtr IJavaObject.Handle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		void IDisposable.Dispose()
		{
			throw new NotImplementedException();
		}

		View GoogleMap.IInfoWindowAdapter.GetInfoContents(Marker marker)
		{
			throw new NotImplementedException();
		}

		View GoogleMap.IInfoWindowAdapter.GetInfoWindow(Marker marker)
		{
			throw new NotImplementedException();
		}
	}
}
