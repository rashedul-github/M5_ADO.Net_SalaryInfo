using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["slr"].ConnectionString);

        private void button1_Click(object sender, EventArgs e)
        {
            new ViewForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO salarySheet ([Date],[Name],[Basic],[Overtime]) VALUES (@d,@n,@b,@o)",con);
            cmd.Parameters.AddWithValue("@d", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@n", textBox1.Text);
            cmd.Parameters.AddWithValue("@b", textBox2.Text);
            cmd.Parameters.AddWithValue("@o", textBox3.Text);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Save Data Successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.ResetText();
            }
            con.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE salarySheet SET [Date]='"+dateTimePicker1.Text+"'," +
                "[Basic]='"+textBox2.Text+ "',[Overtime]='"+textBox3.Text+"' WHERE [Name]='"+textBox1.Text+"'",con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Update Data Successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.ResetText();
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM salarySheet WHERE [Name]='"+textBox1.Text+"'",con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Delete Data Successfully");
                textBox1.Clear();
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new SalaryReport { Date = dateTimePicker2.Text }.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
