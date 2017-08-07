
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySql.Data.MySqlClient;

namespace HotChickFinder
{
	[Activity(Label = "ActivityPlace")]
	public class ActivityPlace : Activity
	{
		private string connection = "Server=sql11.freemysqlhosting.net;Port=3306;database=sql11188998;User=sql11188998;Password=fmdAHMAgS4;charset=utf8";

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




			rateButton.Click += delegate
			{
				string setDataQuery = string.Format("UPDATE SinglePlace SET RANK_CHICK_SUM = {0}, " +
													"RANK_ALC_SUM = {1}, RANK_MUSIC_SUM = {2}, RANK_COUNT = {3} " +
				                                    "WHERE SERIAL_NO = {4}", place.RankChcickSum + ratingBarChicks.Rating, 
				                                    ratingBarDrinks.Rating + place.RankAlcoholSum,
				                                    ratingBarMusic.Rating + place.RankMusicSum, place.RankCount + 1, 
				                                    place.SerialNo.ToString());


				Console.WriteLine(setDataQuery); 

				MySqlConnection con = new MySqlConnection(connection);
				MySqlDataAdapter adptr = new MySqlDataAdapter(); 
				try
				{

					con.Open();
					MySqlCommand cmd = new MySqlCommand(setDataQuery, con);
					adptr.UpdateCommand = cmd;
					Toast.MakeText(this, "Rated!", ToastLength.Short).Show(); 

				}
				catch (Exception ex)
				{
					Console.WriteLine("{oops - {0}", ex.Message);
				}

				finally
				{
					con.Dispose();
				}

			};







		}



	}
}
