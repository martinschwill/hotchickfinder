
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HotChickFinder
{
	[Activity(Label = "ActivityPlace")]
	public class ActivityPlace : Activity
	{

        WebClient webClient;
        ImageView image; 
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var myList = new ListOfPlaces(); 


			SetContentView(Resource.Layout.PlaceLayout);


			//get the place from the intent
			var i = Intent.GetStringExtra("myPlace") ?? "Data not available";
			var place = myList.myPlaces.Find((SinglePlace obj) => obj.Address.Contains(i));


            //set the values of fields in view from the place 
            image = FindViewById<ImageView>(Resource.Id.placeImageView); 
            TextView nameView = FindViewById<TextView>(Resource.Id.nameTextView);
            TextView descrView = FindViewById<TextView>(Resource.Id.descrTextView); 
			RatingBar ratingBarChicks = FindViewById<RatingBar>(Resource.Id.ratingBarChicks);
			RatingBar ratingBarDrinks = FindViewById<RatingBar>(Resource.Id.ratingBarDrinks);
			RatingBar ratingBarMusic = FindViewById<RatingBar>(Resource.Id.ratingBarMusic);
			Button rateButton = FindViewById<Button>(Resource.Id.RateButton);
           

            DownloadImageAsync(place.imageUrl);

            nameView.Text = place.Name;
            descrView.Text = place.Description; 
            ratingBarChicks.Rating = place.GetRankChicks();
            ratingBarDrinks.Rating = place.GetRankAlcohol();
            ratingBarMusic.Rating = place.GetRankMusic(); 

            rateButton.Click += delegate {

                myList.UpdateMDataTable(place.SerialNo, ratingBarChicks.Rating, ratingBarDrinks.Rating, ratingBarMusic.Rating); 

                Toast.MakeText(this, "Your rating has been added!", ToastLength.Short).Show();

            };

		}


        private async void DownloadImageAsync(string imageURL) 
        {
            webClient = new WebClient();
            var url = new Uri(imageURL);
            byte[] imageBytes = null; 


            try{
                imageBytes = await webClient.DownloadDataTaskAsync(url); 
            } catch(TaskCanceledException){}

			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			string localFilename = "image.png";
			string localPath = System.IO.Path.Combine(documentsPath, localFilename);


			FileStream fs = new FileStream(localPath, FileMode.OpenOrCreate);
			await fs.WriteAsync(imageBytes, 0, imageBytes.Length);
			Console.WriteLine("Saving image in local path: " + localPath);

            fs.Close();

			BitmapFactory.Options options = new BitmapFactory.Options();
			options.InJustDecodeBounds = true;
			await BitmapFactory.DecodeFileAsync(localPath, options);

            options.InSampleSize = options.OutWidth > options.OutHeight ? options.OutHeight / image.Height : options.OutWidth / image.Width;
			options.InJustDecodeBounds = false;

			Bitmap bitmap = await BitmapFactory.DecodeFileAsync(localPath, options);
			image.SetImageBitmap(bitmap);
        }
	}
}
