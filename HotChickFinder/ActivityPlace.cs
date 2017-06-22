
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
			RatingBar ratingBar = FindViewById<RatingBar>(Resource.Id.ratingBar);

			nameView.Text = place.Name;
			ratingBar.Rating = place.GetOverallRank(); 

		}
	}
}
