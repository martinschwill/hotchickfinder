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
		public float RankAlcoholSum { get; set; }
		public float RankMusicSum { get; set; }
		public int RankCount { get; set; }



		public SinglePlace(int serial, string name, LatLng pos, string address, string descr, float rnChickSum, float rnAlcSum, float rnMusicSum, int rnCount)
		{
			SerialNo = serial; 
			Name = name;
			Position = pos;
			Address = address;
			Description = descr;
			RankChcickSum = rnChickSum;
			RankAlcoholSum = rnAlcSum;
			RankMusicSum = rnMusicSum;
			RankCount = rnCount; 
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
			if (RankCount > 0)
			{
				float result = RankChcickSum / RankCount;
				return result;
			}
			else return 0; 

		}

		public float GetRankAlcohol()
		{
			if (RankCount > 0)
			{
				float result = RankAlcoholSum / RankCount;
				return result;
			}
			else return 0; 
		}
		public float GetRankMusic()
		{
			if (RankCount > 0)
			{
				float result = RankMusicSum / RankCount;
				return result;
			}
			else return 0; 
		}

		public float GetOverallRank()
		{
			float rank = ((GetRankChicks() + GetRankAlcohol() + GetRankMusic()) / 3); 
			return rank;
		}


	}
}
