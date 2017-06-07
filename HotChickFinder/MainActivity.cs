using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System;
using System.Resources;
using Android.Gms.Maps.Model;
using Android.Views;
using Geolocator.Plugin;

namespace HotChickFinder
{
	[Activity(Label = "HotChickFinder", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, IOnMapReadyCallback, GoogleMap.IInfoWindowAdapter
	{

		private GoogleMap mMap;



		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			SetUpMap();


		}

		private void SetUpMap()
		{
			if (mMap == null)
			{
				FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);

			}

		}
		public async void OnMapReady(GoogleMap googleMap)
		{
			mMap = googleMap;


			//getting the location of a user 
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 100;
			var position = await locator.GetPositionAsync(10000);
			//closing the camera to the current position
			if (position != null)
			{
				LatLng myPosition = new LatLng(position.Latitude, position.Longitude);
				mMap.AddMarker(new MarkerOptions()
										   .SetTitle("You")
										   .SetPosition(myPosition));
				CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(myPosition, 11);
				mMap.MoveCamera(camera);
			}
			else 
			{
				Toast nolocation = Toast.MakeText(this, "Couldn't find location", ToastLength.Short);
				nolocation.Show();
			
			}




			//setup the list of places
			ListOfPlaces mListOfPlaces = new ListOfPlaces();

			//add markers for places on map
			foreach (var place in mListOfPlaces.myPlaces)
			{
				mMap.AddMarker(place.ToMarkerOptions());
			}

			//update the camera position

			//set adapter for InfoWindow
			mMap.SetInfoWindowAdapter(this);
		}


		//InfoWindowAdapter Implementation
		public View GetInfoContents(Marker marker)
		{
			return null; 
		}


		public View GetInfoWindow(Marker marker)
		{
			View view = LayoutInflater.Inflate(Resource.Layout.infoPopup, null, false);
			view.FindViewById<TextView>(Resource.Id.txtName).Text = marker.Title;
			view.FindViewById<TextView>(Resource.Id.txtAddress).Text = marker.Snippet;

			return view; 
		}
	}


}

