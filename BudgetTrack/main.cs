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
   
    public partial class main : Form
    {
        
        public main()
        {
            InitializeComponent();
            
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            income add = new income();
            add.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Enter(object sender, EventArgs e)
        {
           
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
            button5.ForeColor = Color.White;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            //button5.BackColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Red;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("hh: mm:ss");
        }

        private void main_Load(object sender, EventArgs e)
        {
            connection con = new connection();
            con.OpenConnection();
            if (con.OpenConnection())
            {
                label3.ForeColor = Color.Green;
                label3.Text = "خوش آمدید"; 
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "انٹرنیٹ کنیکٹ کریں";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            exp add = new exp();
            add.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            budget budget = new budget();
            budget.ShowDialog();
        }
    }
}
