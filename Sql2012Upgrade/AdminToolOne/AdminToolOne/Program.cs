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

            Server srv = new Server(@"SERVER");
            string dbName = "TestDatabase";
            string delete = "Archive";
            Database db = srv.Databases[dbName];
            Database delDB = srv.Databases[delete];

            foreach (Table dTab in delDB.Tables)
            {
                using (var scon = Connections.Connect())
                {
                    SqlCommand drop = new SqlCommand("DROP TABLE " + dTab, scon);
                    drop.ExecuteNonQuery();
                    drop.Dispose();
                    scon.Close();
                }
            }

            Scripter tabScr = new Scripter(srv);

            foreach (Table tb in db.Tables)
            {
                if (tb.IsSystemObject == false)
                {
                    System.Collections.Specialized.StringCollection sctab = tabScr.Script(new Urn[] { tb.Urn });

                    foreach (string stab in sctab)
                    {
                        using (var scon = Connections.Connect())
                        {
                            SqlCommand copyTables = new SqlCommand(stab, scon);
                            copyTables.ExecuteNonQuery();
                            copyTables.Dispose();
                            scon.Close();
                        }
                    }
                }
            }

        }
    }

    public static class Connections
    {
        public static SqlConnection Connect()
        {
            string server = "SERVER";
            string database = "Archive";
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "integrated security=SSPI;data source=" + server + ";persist security info=False;initial catalog=" + database + "";
            scon.Open();
            return scon;
        }
    }
}
