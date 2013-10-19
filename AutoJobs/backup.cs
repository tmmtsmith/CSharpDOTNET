using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Sdk.Sfc;

namespace AdminToolOne
{
    class Program
    {
        static void Main(string[] args)
        {

            Server srv = new Server(@"SERVER\INSTANCE");
            string dbName = "DATABASE";
            Database db = srv.Databases[dbName];

            DateTime now = DateTime.Now;
            DateTime dt = now.AddDays(-3);
            string ndt;
            ndt = Convert.ToString(now.Year) + "" + Convert.ToString(now.Month) + "" + Convert.ToString(now.Day);
            DateTime dbDate = db.LastBackupDate;
            string name = db.Name;

            if (dt > dbDate)
            {
                using (var scon = Connections.Connect())
                {
                    SqlCommand back = new SqlCommand("BACKUP DATABASE " + name + " TO DISK = 'C:\\Backups\\" + name + "_" + ndt + ".BAK'", scon);
                    back.ExecuteNonQuery();
                    scon.Close();
                }
            }
            Console.WriteLine("Database backed up");
            Console.ReadLine();
            }
    }

    public static class Connections
    {
        public static SqlConnection Connect()
        {
            string server = "SERVER\\INSTANCE";
            string database = "DATABASE";
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "integrated security=SSPI;data source=" + server + ";persist security info=False;initial catalog=" + database + "";
            scon.Open();
            return scon;
        }
    }
}

