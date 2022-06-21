using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BudgetTrack
{
    public partial class income : Form
    {
        ListViewItem item3;
        string month = DateTime.Now.ToString("MM-yyyy");
        public income()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            ClsIncome addincome = new ClsIncome();
            addincome.incomeDate = Convert.ToDateTime(date);
            addincome.incomDetails = textBox1.Text;
            addincome.Totalincome = Convert.ToInt32(textBox2.Text);
            addincome.month = month;
            addincome.add();
            MessageBox.Show("آمدنی کااندراج ھو گیا ہے", "گھر کے آخراجات کا ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ViewsAddress();

        }

        private void income_Load(object sender, EventArgs e)
        {
            ViewAddress();
            ViewsAddress();
            int sum = 0;
            for (int i = 0; i < listView8.Items.Count; i++)
            {
                sum += Convert.ToInt32(listView8.Items[i].SubItems[2].Text);
            }
            label5.Text = sum.ToString();
        }
        public void ViewAddress()
        {

            ColumnHeader header0 = this.listView8.Columns.Add("SR#", 4 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            //ColumnHeader header1 = this.listView8.Columns.Add("Date", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header2 = this.listView8.Columns.Add("Details", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header3 = this.listView8.Columns.Add("Income", 8 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);
            ColumnHeader header4 = this.listView8.Columns.Add("Month", 10 * Convert.ToInt32(listView8.Font.SizeInPoints), HorizontalAlignment.Left);


        }
        private void ViewsAddress()
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
            
            listView8.Items.Clear();
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

                    listView8.Items.AddRange(new ListViewItem[] { item3 });
                    
                    ct += 1;
                    
                }
            }
            int sum = 0;
            for (int i = 0; i < listView8.Items.Count; i++)
            {
                sum += Convert.ToInt32(listView8.Items[i].SubItems[2].Text);
            }
            label5.Text = sum.ToString();
        }

        
        }
    }

