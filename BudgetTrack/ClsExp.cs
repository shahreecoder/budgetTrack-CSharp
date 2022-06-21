using System;
using System.Data;
using System.Threading;

using MySql.Data.MySqlClient;

namespace BudgetTrack
{
    public class ClsExp
    {
        int _ID;
        DateTime _expdate;
        string _expdetails;
        int _expcost;
        string _month;

        public ClsExp()
        {

        }

        public ClsExp(int ID, DateTime expdate, string expdetails, int expcost, string month)
        {
            this._ID = ID;
            this._expdate = expdate;
            this._expdetails = expdetails;
            this._expcost = expcost;
            this._month = month;
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public DateTime expdate
        {
            get { return _expdate; }
            set { _expdate = value; }
        }
        public string expdetails
        {
            get { return _expdetails; }
            set { _expdetails = value; }
        }

        public int expcost
        {
            get { return _expcost; }
            set { _expcost = value; }
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
                mySqlCommand.CommandText = "INSERT INTO expenses (expdate, expdetails, expcost, month) VALUES ('" + expdate.ToString("yyyy-MM-dd") + "', '" + expdetails + "', '" + expcost + "','"+month+"');";
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
        public bool namesearch(string expdate)
        {
            string query = "Select  * from user where expdate='" + expdate + "'";
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

                    if (dr["expdate"] != DBNull.Value)
                        this.expdate = (DateTime)dr["expdate"];
                    if (dr["expdetails"] != DBNull.Value)
                        this.expdetails = (string)dr["expdetails"];

                    if (dr["expcost"] != DBNull.Value)
                        this.expcost = (int)dr["expcost"];


                }
            }
            return true;
        }






    }
}