using System;
using Android.Gms.Maps.Model;
using System.Collections.Generic;
using System.Linq;
namespace HotChickFinder
{
	public class SinglePlace
	{
		public int SerialNo { get; }
		public String Name { get; set; }
		public LatLng Position { get; set; }
		public String Address { get; set; }
		public String Description { get; set; }
		public float RankChcickSum { get; set; } 
		public int RankChcickCount { get; set; }
		public float RankAlcoholSum { get; set; }
		public int RankAlcoholCount { get; set; }
		public float RankMusicSum { get; set; }
		public float RankMusicCount { get; set; }



		public SinglePlace(int serial, string name, LatLng pos, string address, string descr)
		{
			SerialNo = serial; 
			Name = name;
			Position = pos;
			Address = address;
			Description = descr;

		}

		public SinglePlace() { }




		public MarkerOptions ToMarkerOptions() 
		{
			var mMarkerOptions = new MarkerOptions()
				.SetTitle(this.Name)
				.SetPosition(this.Position)
				.SetSnippet(this.Address)
				.Draggable(false);

			return mMarkerOptions; 
		}


		public float GetRankChicks()
		{
			float result = RankChcickSum / RankChcickCount;
			return result; 
		}

		public float GetRankAlcohol()
		{
			float result = RankAlcoholSum / RankAlcoholCount;
			return result; 
		}
		public float GetRankMusic()
		{
			float result = RankMusicSum / RankMusicCount;
			return result; 
		}

		public float GetOverallRank()
		{
			float rank = ((GetRankChicks() + GetRankAlcohol() + GetRankMusic()) / 3); 
			return rank;
		}


	}
}
