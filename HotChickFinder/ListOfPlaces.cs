using System;
using System.Collections.Generic;
using Android.Gms.Maps.Model;
using MySql.Data.MySqlClient;
using System.Data; 
using Android.Widget;
using System.Collections;
using System.ComponentModel;



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
					//setting up the connection with the DATABASE and retreiving information
					MySqlDataAdapter adptr = new MySqlDataAdapter(getDataQuery, con);
					adptr.SelectCommand.CommandType = CommandType.Text;
					DataTable myTable = new DataTable();
					adptr.Fill(myTable);


					//Filling the local List<SinglePlace> with places
					foreach (DataRow dr in myTable.Rows) 
					{
						myPlaces.Add(new SinglePlace(Convert.ToInt32(dr["SERIAL_NO"]), dr["NAME"].ToString(),
													 new LatLng(Convert.ToDouble(dr["POS_LAT"]), Convert.ToDouble(dr["POS_LNG"])),
													 dr["ADDRESS"].ToString(), dr["DESCR"].ToString(),
						             Convert.ToSingle(dr["RANK_CHICK_SUM"]), 
						                 Convert.ToSingle(dr["RANK_ALC_SUM"]), 
						                             Convert.ToSingle(dr["RANK_MUSIC_SUM"]), Convert.ToInt32(dr["RANK_COUNT"]) ));
						                                                              
						                                                                                                 
					
					}



				}


			}
			catch (Exception ex)
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
