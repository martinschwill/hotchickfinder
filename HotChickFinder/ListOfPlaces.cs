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
			myPlaces.Add(new SinglePlace(1,"Galeria Bałtycka", new LatLng(54.382901, 18.600481), "Al. Grunwaldzka", "Galeria Chicko", 5.5f, 1.5f, 1.5f));   
			myPlaces.Add(new SinglePlace(2,"Żak", new LatLng(54.386994, 18.592035), "Braci Lewoniewskich 2a", "Party", 4.0f, 0.0f, 4.5f));
			myPlaces.Add(new SinglePlace(3,"Garnizon", new LatLng(54.384562, 18.590887), "Słonimskiego 3", "Party ON!", 1.0f, 0.0f, 0.0f));
		}
	}
}
