using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TicketSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "integrated security=true;data source=LocalHost\\InstanceName;" + "persist security info=False;initial catalog=DatabaseName";
            //con.ConnectionString = "Data Source=LocalHost\\InstanceName;Initial Catalog=DatabaseName;Integrated Security=SSPI;";
            
            // For Data Source usually the format is LocalHostName\\SQLInstanceName - note that a double dash is necessary as a single dash throws an error

            con.Open();
            SqlCommand myCom = new SqlCommand("INSERT INTO Tickets (Name,Department,Request) SELECT @1, @2, @3", con);
            myCom.Parameters.Add(new SqlParameter("@1", Convert.ToString(txt1.Text)));
            myCom.Parameters.Add(new SqlParameter("@2", Convert.ToString(txt2.Text)));
            myCom.Parameters.Add(new SqlParameter("@3", Convert.ToString(txt3.Text)));
            myCom.ExecuteNonQuery();
            con.Close();

            foreach (var co in Controls)
            {
                if (co is TextBox)
                {
                    ((TextBox)co).Text = String.Empty;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}