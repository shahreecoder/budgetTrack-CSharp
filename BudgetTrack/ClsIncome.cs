using System;
using System.Data;
using System.Threading;

using MySql.Data.MySqlClient;

namespace BudgetTrack
{
    public class ClsIncome
    {
        int _ID;
        DateTime _incomeDate;
        string _incomDetails;
        int _Totalincome;
        string _month;
        public ClsIncome()
        {

        }

        public ClsIncome(int ID, DateTime incomeDate, string incomDetails, int Totalincome, string month)
        {
            this._ID = ID;
            this._incomeDate = incomeDate;
            this._incomDetails = incomDetails;
            this._Totalincome = Totalincome;
            this._month = month;
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public DateTime incomeDate
        {
            get { return _incomeDate; }
            set { _incomeDate = value; }
        }
        public string incomDetails
        {
            get { return _incomDetails; }
            set { _incomDetails = value; }
        }

        public int Totalincome
        {
            get { return _Totalincome; }
            set { _Totalincome = value; }
        }
        public string month
        {
            get { return _month; }
            set { _month = value; }
        }

        //Add User
        public void add()
        {
            connection con = new connection();
            if (con.OpenConnection())
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.CommandText = "INSERT INTO income (incomeDate, incomDetails, Totalincome, month) VALUES ('"+incomeDate.ToString("yyyy-MM-dd") +"', '"+incomDetails+"', '"+Totalincome+"', '"+month+"');";
                try
                {
                    mySqlCommand.Connection = con.MyConnection;
                    mySqlCommand.ExecuteNonQuery();
                    con.MyConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }














        //Search User 
        public bool namesearch(string incomeDate)
        {
            string query = "Select  * from user where incomeDate='" + incomeDate + "'";
            DataSet accountsData = null;
            MySqlDataAdapter myAdapter;
            connection conn = new connection();
            if (conn.OpenConnection())
            {
                myAdapter = new MySqlDataAdapter(query, conn.MyConnection);
                accountsData = new DataSet();
                myAdapter.Fill(accountsData);
                if (accountsData.Tables[0].Rows.Count == 0)
                    return false;
                else
                {
                    DataRow dr = accountsData.Tables[0].Rows[0];

                    if (dr["incomeDate"] != DBNull.Value)
                        this.incomeDate = (DateTime)dr["incomeDate"];
                    if (dr["incomDetails"] != DBNull.Value)
                        this.incomDetails = (string)dr["incomDetails"];

                    if (dr["Totalincome"] != DBNull.Value)
                        this.Totalincome = (int)dr["Totalincome"];


                }
            }
            return true;
        }






    }
}