using System;
using Android.Gms.Maps.Model;
using Android.Content;
namespace HotChickFinder
{
	public class SinglePlace
	{
		public String Name { get; set; }
		public LatLng Position { get; set; }
		public String Address { get; set; }
		public String Description { get; set; }
		public double Rank1 { get; set; }
		public double Rank2 { get; set; }
		public double Rank3 { get; set; } 


		public SinglePlace(string name, LatLng pos, string address, string descr, double rank1, double rank2, double rank3)
		{
			Name = name;
			Position = pos;
			Address = address;
			Description = descr;
			Rank1 = rank1;
			Rank2 = rank2;
			Rank3 = rank3; 
		}


		public double GetOverallRank()
		{
			double rank = (this.Rank1 + this.Rank2 + this.Rank3) / 3;
			return rank; 	
		}

		public MarkerOptions ToMarkerOptions() 
		{
			var mMarkerOptions = new MarkerOptions()
				.SetTitle(this.Name)
				.SetPosition(this.Position)
				.SetSnippet(this.Address)
				.Draggable(false);

			return mMarkerOptions; 
		}




		public void ToEntity()
		{
			
		
		
		}
	}
}
