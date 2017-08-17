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

        public DataTable mDataTable = new DataTable(); 

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



                    adapter.Fill(mDataTable);

                    foreach(DataRow row in mDataTable.Rows){
                        myPlaces.Add(new SinglePlace((int)row["SERIAL_NO"], row["NAME"].ToString(), new LatLng((double)row["POS_LAT"], (double)row["POS_LNG"]), row["ADDRESS"].ToString(),
                                                     row["DESCR"].ToString(), (float)row["RANK_CHICK_SUM"], (float)row["RANK_ALC_SUM"],
                                                     (float)row["RANK_MUSIC_SUM"], (int)row["RANK_COUNT"], row["IMAGE"].ToString())); 
                    }

				}


			}
			catch (MySqlException ex)
			{
                Console.WriteLine("oops - {0}", ex.Message); 
			}
            finally
            {
                con.Dispose(); 
            }

		}

        public void UpdateMDataTable(int serialNo, float chickRank, float alcRank, float musicRank)
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand mySqlCmd = new MySqlCommand(getDataQuery);
            mySqlCmd.Connection = con; 
            MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCmd);
            MySqlCommandBuilder myCB = new MySqlCommandBuilder(adapter);
            adapter.UpdateCommand = myCB.GetUpdateCommand();

            this.myPlaces[serialNo - 1].RankChcickSum += chickRank;
            this.myPlaces[serialNo - 1].RankAlcoholSum += alcRank;
            this.myPlaces[serialNo - 1].RankMusicSum += musicRank;
            this.myPlaces[serialNo - 1].RankCount++;


            this.mDataTable.Rows[serialNo - 1]["RANK_CHICK_SUM"] = this.myPlaces[serialNo - 1].RankChcickSum.ToString();
            this.mDataTable.Rows[serialNo - 1]["RANK_ALC_SUM"] = this.myPlaces[serialNo - 1].RankAlcoholSum.ToString(); 
            this.mDataTable.Rows[serialNo - 1]["RANK_MUSIC_SUM"] = this.myPlaces[serialNo - 1].RankMusicSum.ToString();
            this.mDataTable.Rows[serialNo - 1]["RANK_COUNT"] = this.myPlaces[serialNo - 1].RankCount; 

            adapter.Update(mDataTable); 


            myPlaces.Clear();

            foreach (DataRow row in mDataTable.Rows)
            {
				myPlaces.Add(new SinglePlace((int)row["SERIAL_NO"], row["NAME"].ToString(), new LatLng((double)row["POS_LAT"], (double)row["POS_LNG"]), row["ADDRESS"].ToString(),
													 row["DESCR"].ToString(), (float)row["RANK_CHICK_SUM"], (float)row["RANK_ALC_SUM"],
													 (float)row["RANK_MUSIC_SUM"], (int)row["RANK_COUNT"], row["IMAGE"].ToString()));
			}

				con.Dispose(); 
		}

		
	}
}
