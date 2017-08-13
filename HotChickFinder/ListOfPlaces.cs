using System;
using System.Collections.Generic;
using Android.Gms.Maps.Model;
using MySql.Data.MySqlClient;
using System.Data; 
using Android.Widget;
using System.Collections;



namespace HotChickFinder
{
	public class ListOfPlaces
	{

		public List<SinglePlace> myPlaces = new List<SinglePlace>();

		private string connection = "Server=sql11.freemysqlhosting.net;Port=3306;database=sql11188998;User=sql11188998;Password=fmdAHMAgS4;charset=utf8";

		private string getDataQuery = "SELECT * FROM SinglePlace";  


		public ListOfPlaces()
		{

			MySqlConnection con = new MySqlConnection(connection);
			try
			{

				if (con.State == ConnectionState.Closed)
				{

                    MySqlDataAdapter adapter = new MySqlDataAdapter(getDataQuery, con);

                    adapter.SelectCommand.CommandType = CommandType.Text; 

                    DataTable ds = new DataTable();

                    adapter.Fill(ds);

                    foreach(DataRow row in ds.Rows){
                        myPlaces.Add(new SinglePlace((int)row["SERIAL_NO"], row["NAME"].ToString(), new LatLng((double)row["POS_LAT"], (double)row["POS_LNG"]), row["ADDRESS"].ToString(),
                                                     row["DESCR"].ToString(), (float)row["RANK_CHICK_SUM"], (float)row["RANK_ALC_SUM"],
                                                     (float)row["RANK_MUSIC_SUM"], (int)row["RANK_COUNT"])); 
                    }

				}


			}
			catch (MySqlException ex)
			{
                Console.WriteLine("{oops - {0}", ex.Message); 
			}
            finally
            {
                con.Dispose(); 
            }

		}



		
	}
}
