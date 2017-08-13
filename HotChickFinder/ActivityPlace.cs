
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HotChickFinder
{
	[Activity(Label = "ActivityPlace")]
	public class ActivityPlace : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var myList = new ListOfPlaces(); 


			SetContentView(Resource.Layout.PlaceLayout);


			//get the place from the intent
			var i = Intent.GetStringExtra("myPlace") ?? "Data not available";
			var place = myList.myPlaces.Find((SinglePlace obj) => obj.Address.Contains(i));


			//set the values of fields in view from the place 
			TextView nameView = FindViewById<TextView>(Resource.Id.nameTextView);
			RatingBar ratingBarChicks = FindViewById<RatingBar>(Resource.Id.ratingBarChicks);
			RatingBar ratingBarDrinks = FindViewById<RatingBar>(Resource.Id.ratingBarDrinks);
			RatingBar ratingBarMusic = FindViewById<RatingBar>(Resource.Id.ratingBarMusic);
			Button rateButton = FindViewById<Button>(Resource.Id.RateButton); 

			nameView.Text = place.Name;
            ratingBarChicks.Rating = place.GetRankChicks();
            ratingBarDrinks.Rating = place.GetRankAlcohol();
            ratingBarMusic.Rating = place.GetRankMusic(); 
		}
	}
}
