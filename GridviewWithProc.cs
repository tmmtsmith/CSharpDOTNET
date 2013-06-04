/* 

Gridview form calling a stored procedure to return data to the grid. 

*/

-- C# Form

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Connect
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
            con.ConnectionString = "integrated security=SSPI;data source=SERVER;" + "persist security info=False;initial catalog=DB";

            con.Open();

            string table = Convert.ToString(txt1.Text);
            SqlCommand select = new SqlCommand("EXECUTE stp_ReturnTable @p", con);
            select.Parameters.Add(new SqlParameter("@p", table));
            SqlDataAdapter sadapt = new SqlDataAdapter(select);
            sadapt.SelectCommand = select;
            DataTable dtab = new DataTable();
            sadapt.Fill(dtab);
            BindingSource b = new BindingSource();
            b.DataSource = dtab;
            dGrid.DataSource = b;
            sadapt.Update(dtab);

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "integrated security=SSPI;data source=SERVER;" + "persist security info=False;initial catalog=DB";
            con.Open();
            MessageBox.Show("Connection to SQL Server established.");
            con.Close();
        }
    }
}


-- SQL Stored Procedure

CREATE PROCEDURE stp_ReturnTable
  @TableName VARCHAR(250)
AS
BEGIN

	DECLARE @sql NVARCHAR(MAX)
	SET @sql = N'SELECT TOP 100 *
		FROM ' + @TableName

	EXECUTE(@sql)

END
