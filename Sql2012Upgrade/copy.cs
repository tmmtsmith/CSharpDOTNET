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

// Added references (refer to: http://msdn.microsoft.com/en-us/library/ms162153.aspx)
// Microsoft.SqlServer.Smo.dll 
// Microsoft.SqlServer.ConnectionInfo.dll 
// Microsoft.SqlServer.Management.Sdk.Sfc.dll 


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
                        Console.WriteLine(sp);
                    }

                    Console.WriteLine("\n");

                }
            }

        }
    }
}
