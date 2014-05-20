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

namespace SqlJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            Server srv = new Server(@"SERVER");
            Database db = srv.Databases["DB"];

            Scripter stpsc = new Scripter(srv);
            // This option will script the tables with the procedures
            stpsc.Options.WithDependencies = false;

            foreach (StoredProcedure stp in db.StoredProcedures)
            {
                if (stp.IsSystemObject == false)
                {
                    Console.WriteLine("/* Create script for procedure " + stp.Name + " */");
                    System.Collections.Specialized.StringCollection sc2 = stpsc.Script(new Urn[] { stp.Urn });

                    foreach (string sp in sc2)
                    {
                        Console.WriteLine("Migrating procedure " + stp.Name + "... ");
                        using (var scon = Connections.Connect())
                        {
                            SqlCommand runit = new SqlCommand(sp, scon);
                            runit.ExecuteNonQuery();
                            runit.Dispose();
                            scon.Close();
                        }
                    }

                    Console.WriteLine("\n");

                }
            }

        }
    }
    
    public static class Connections
    {
        public static SqlConnection Connect(string server, string database)
        {
            //Manual:
            //string server = "SERVER";
            //string database = "OTHERDB";
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "integrated security=SSPI;data source=" + server + ";persist security info=False;initial catalog=" + database + "";
            scon.Open();
            return scon;
        }
    }
}
