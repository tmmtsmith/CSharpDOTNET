using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ExportProcs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var scon = Connections.Connect())
            {
                // SQL Stuff
            }

        }


    }

    public static class Connections
    {
        public static SqlConnection Connect()
        {
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "integrated security=SSPI;data source=SERVER\\INSTANCE;persist security info=False;initial catalog=AdminExamples";
            scon.Open();
            return scon;
        }
    }
}
