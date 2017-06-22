using System;
using Android.Gms.Maps.Model;
namespace HotChickFinder
{
	public class SinglePlace
	{
		public int SerialNo { get; }
		public String Name { get; set; }
		public LatLng Position { get; set; }
		public String Address { get; set; }
		public String Description { get; set; }
		public float Rank1 { get; set; }
		public float Rank2 { get; set; }
		public float Rank3 { get; set; }


		public SinglePlace(int serial, string name, LatLng pos, string address, string descr, float rank1, float rank2, float rank3)
		{
			SerialNo = serial; 
			Name = name;
			Position = pos;
			Address = address;
			Description = descr;
			Rank1 = rank1;
			Rank2 = rank2;
			Rank3 = rank3; 
		}


		public float GetOverallRank()
		{
			float rank = (this.Rank1 + this.Rank2 + this.Rank3) / 3;
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





	}
}
