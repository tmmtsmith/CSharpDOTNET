using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WindowWidth = 150;
            Console.WindowHeight = 60;
            Console.Title = "Framework";
            int x = 0;
            int y = 1;

            while (x == 0)
            {
                string userinput;
                Console.WriteLine("Enter a command");
                userinput = Console.ReadLine();

                if (userinput == "new")
                {
                    Console.WriteLine("New command");
                    Console.ReadLine();
                    x = 1;
                }
                else if (userinput == "change")
                {
                    Console.WriteLine("Change command");
                    Console.ReadLine();
                    x = 2;
                }
                else if (userinput == "adminonly")
                {
                    using (var scon = Connections.Connect())
                    {
                        string xmlquery = "SELECT MessageText FROM admin.IntegrityCheck WHERE Date BETWEEN DATEADD(DD,-1,GETDATE()) AND GETDATE() AND MessageText LIKE 'CHECKDB%' OR Date BETWEEN DATEADD(DD,-1,GETDATE()) AND GETDATE() AND MessageText NOT LIKE '%sys.%'";
                        SqlCommand admin = new SqlCommand("EXECUTE admin.stp_StockAnalysis_Admin", scon);
                        admin.ExecuteNonQuery();
                        SqlDataAdapter intAd = new SqlDataAdapter(xmlquery, scon);
                        DataSet intDS = new DataSet();
                        intAd.Fill(intDS, "admin.IntegrityCheck");
                        Console.WriteLine(intDS.GetXml());
                        Console.ReadLine();
                        scon.Close();
                    }
                    x = 3;
                }
                else if (y == 3)
                {
                    x = 4;
                }
                else
                {
                    Console.WriteLine("Invalid command.  Try again.");
                    Console.ReadLine();
                    x = 0;
                    y++;
                }
            }

            if (x == 1)
            {
                Console.WriteLine("New command completed.");
                Console.ReadLine();
            }
            else if (x == 2)
            {
                Console.WriteLine("Change action completed.");
                Console.ReadLine();
            }
            else if (x == 3)
            {
                Console.WriteLine("Admin tasks completed - integrity verified and database backed up.");
            }
            else if (x == 4)
            {
                Console.WriteLine("You've committed three errors.  This program is terminating; goodbye.");
            }
            
        }

        public static class Connections
        {
            public static SqlConnection Connect()
            {
                SqlConnection scon = new SqlConnection();
                scon.ConnectionString = "integrated security=SSPI;data source=SERVER;persist security info=False;initial catalog=DATABASE;Connect Timeout=600";
                scon.Open();
                return scon;
            }
        }
    }
}
