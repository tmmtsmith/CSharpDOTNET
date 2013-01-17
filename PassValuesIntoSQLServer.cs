using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

// When a user clicks the button, this sends the data through a SQL Server function which provides a value, which is then inserted into a table
private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
	    // Repace SERVER with server name and DATABASE with database name
            con.ConnectionString = "integrated security=SSPI;data source=SERVER;" + "persist security info=False;initial catalog=DATABASE";
            
            con.Open();
            SqlCommand myCom = new SqlCommand("INSERT INTO TABLE SELECT dbo.FUNCTION(@1,@2,@3) AS Rating", con);
            myCom.Parameters.Add(new SqlParameter("@1", Convert.ToDecimal(txt1.Text)));
            myCom.Parameters.Add(new SqlParameter("@2", Convert.ToDecimal(txt2.Text)));
            myCom.Parameters.Add(new SqlParameter("@3", Convert.ToDecimal(txt3.Text)));
            myCom.ExecuteNonQuery();
            con.Close();
        }