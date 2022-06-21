using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetTrack
{
    public partial class budget : Form
    {
        ListViewItem item3;
        int income;
        int exp;
        int total;
        string month = DateTime.Now.ToString("MM-yyyy");
        public budget()
        {
            InitializeComponent();
        }

        private void budget_Load(object sender, EventArgs e)
        {
            expview();
            expviews();
            incomeview();
            incomeviews();
            total = income - exp;
            label7.Text = total.ToString(); 
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
            button5.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Red;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void expview()
        {
            string query = "Select * from expenses where month='" + month + "'";

            DataSet Chenabdata = null;
            MySqlDataAdapter myAdapter;
            connection c = new connection();
            if (c.OpenConnection())
            {
                myAdapter = new MySqlDataAdapter(query, c.MyConnection);
                Chenabdata = new DataSet();
                myAdapter.Fill(Chenabdata);
            }

            listView8.Items.Clear();
            // Repeat for each table in the DataSet's table collection.
            foreach (DataTable table in Chenabdata.Tables)
            {
                int ct = 1;
                // Repeat for each row in the table.
                foreach (DataRow row in table.Rows)
                {


                    item3 = new ListViewItem(row["ID"].ToString());
                    //item3.SubItems.Add(row["incomeDate"].ToString());
                    item3.SubItems.Add(row["expdetails"].ToString());
                    item3.SubItems.Add(row["expcost"].ToString());
                    item3.SubItems.Add(row["month"].ToString());
                    listView8.Items.AddRange(new ListViewItem[] { item3 });

                    ct += 1;

                }
            }
            int sum = 0;
            for (int i = 0; i < listView8.Items.Count; i++)
            {
                sum += Convert.ToInt32(listView8.Items[i].SubItems[2].Text);
            }
            label3.Text = sum.ToString();
            exp = sum;
        }
        public void expviews()
        {

            ColumnHeader header0 = this.listView8.Columns.Add("SR#", 4 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            //ColumnHeader header1 = this.listView8.Columns.Add("Date", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header2 = this.listView8.Columns.Add("Exp Details", 10 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header3 = this.listView8.Columns.Add("Expenses", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header4 = this.listView8.Columns.Add("Month", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);

        }
        public void incomeviews()
        {

            ColumnHeader header0 = this.listView1.Columns.Add("SR#", 4 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            //ColumnHeader header1 = this.listView8.Columns.Add("Date", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header2 = this.listView1.Columns.Add("Details", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header3 = this.listView1.Columns.Add("Income", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header4 = this.listView1.Columns.Add("Month", 10 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);


        }
        private void incomeview()
        {
            string query = "Select * from income where month='" + month + "' ";

            DataSet Chenabdata = null;
            MySqlDataAdapter myAdapter;
            connection c = new connection();
            if (c.OpenConnection())
            {
                myAdapter = new MySqlDataAdapter(query, c.MyConnection);
                Chenabdata = new DataSet();
                myAdapter.Fill(Chenabdata);
            }

            listView1.Items.Clear();
            // Repeat for each table in the DataSet's table collection.
            foreach (DataTable table in Chenabdata.Tables)
            {
                int ct = 1;
                // Repeat for each row in the table.
                foreach (DataRow row in table.Rows)
                {


                    item3 = new ListViewItem(row["ID"].ToString());
                    // item3.SubItems.Add(row["incomeDate"].ToString());
                    item3.SubItems.Add(row["incomDetails"].ToString());
                    item3.SubItems.Add(row["Totalincome"].ToString());
                    item3.SubItems.Add(row["month"].ToString());

                    listView1.Items.AddRange(new ListViewItem[] { item3 });

                    ct += 1;

                }
            }
            int sum = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                sum += Convert.ToInt32(listView1.Items[i].SubItems[2].Text);
            }
            label5.Text = sum.ToString();
            income = sum;
        }

    }
}
