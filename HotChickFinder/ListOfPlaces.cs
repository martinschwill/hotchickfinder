using System;
using System.Collections.Generic;
using Android.Gms.Maps.Model;
namespace HotChickFinder
{
	public class ListOfPlaces
	{

		public List<SinglePlace> myPlaces = new List<SinglePlace>(); 

		public ListOfPlaces()
		{
			myPlaces.Add(new SinglePlace("Galeria Bałtycka", new LatLng(54.382901, 18.600481), "Al. Grunwaldzka", "Galeria Chicko", 0.0, 0.0, 0.0));   
			myPlaces.Add(new SinglePlace("Żak", new LatLng(54.386994, 18.592035), "Braci Lewoniewskich 2a", "Party", 0.0, 0.0, 0.0));
			myPlaces.Add(new SinglePlace("Garnizon", new LatLng(54.384562, 18.590887), "Słonimskiego 3", "Party ON!", 0.0, 0.0, 0.0));
		}
	}
}
