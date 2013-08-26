/* .cs file */


// namespaces
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;


// inside the application
string cS = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
            SqlConnection con = new SqlConnection(cS);
            con.Open();
            SqlCommand create = new SqlCommand("CREATE TABLE TestTable(ID INT)", con);
            create.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Test table created");
            Console.ReadLine();

/* xml file */

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="one" providerName="System.Data.SqlClient" connectionString="server=SERVER;database=DATABASE;Integrated Security=True"/>
  </connectionStrings>
</configuration>
