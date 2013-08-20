using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace FileChecker
{
    class Program
    {

        static void Main(string[] args)
        {
            int x = 0;
            while (x < 1)
            {
                string srcPath = @"E:\Check\";
                string srcFile = "test.csv";
                string srcT = srcPath + srcFile;
                string archivePath = @"E:\Check\Archive\";
                if (File.Exists(srcT))
                {
                    x = 1;
                    Console.WriteLine("File found!  Now inserting the data");
                    using (var scon = Utilities.Connect())
                    {
                        SqlCommand bi = new SqlCommand("EXECUTE stp_InsertMOData", scon);
                        bi.ExecuteNonQuery();
                        scon.Close();
                    }
                    File.Move(srcT, archivePath + srcFile);
                    Console.WriteLine("Data inserted.");
                }
                else
                {
                    x = 0;
                    Console.WriteLine("Continuing to scan ...");
                }
            }
            Console.ReadLine();
        }

        public static class Utilities
        {
            public static SqlConnection Connect()
            {
                SqlConnection scon = new SqlConnection();
                scon.ConnectionString = "integrated security=SSPI;data source=SERVER;persist security info=False;initial catalog=DATABASE";
                scon.Open();
                return scon;
            }
        }
    }
}
