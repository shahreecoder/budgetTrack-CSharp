using System;
using MySql.Data.MySqlClient;

namespace BudgetTrack
{

	public class connection
	{
		private MySqlConnection myConnection;

		public string a;
		public connection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public MySqlConnection MyConnection
		{
			get { return myConnection; }
			set { myConnection = value; }
		}
		public bool OpenConnection()
		{
			// string connectionString;
			bool val = false;
			try
			{
				string connectionString = "server=62.171.130.151; user=hospitalsf_home;Password=shahree4613; database=hospitalsf_home; Convert Zero Datetime=True;";
				MySqlConnection myConnection = new MySqlConnection(connectionString);
				myConnection.Open();
				MyConnection = myConnection;
				val = true;
			}
			catch
			{

				val = false;
			}
			return val;
		}


	}
}
