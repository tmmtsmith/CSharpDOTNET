// C# Console Application
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace TraceImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Destination Folder:
            string folderOne = @"C:\Destination\";
            System.IO.DirectoryInfo diOne = new System.IO.DirectoryInfo(folderOne);

            //  Source Folder:
            string folderTwo = @"C:\Source\";
            System.IO.DirectoryInfo diTwo = new System.IO.DirectoryInfo(folderTwo);


            string[] ZipFiles = System.IO.Directory.GetFiles(folderTwo, "*.zip");

            foreach (string fi in ZipFiles.Where(item => item.EndsWith(".zip")))
            {
                File.Delete(fi);
            }

            string[] TraceFiles = System.IO.Directory.GetFiles(folderTwo, "*.trc");

            foreach (string Tr in TraceFiles.Where(item => item.EndsWith(".trc")))
            {
                string newLoc = Tr.Replace(folderTwo, "");
                Console.WriteLine("Moving file " + newLoc + " ... ");
                File.Move(Tr, folderOne + newLoc);

                Console.WriteLine("Inserting trace data into the temp table ...");

                // Temp Table (edit):
                string temp = "TEMPTABLE";
                //  Saved Data Table (edit):
                string main = "MAINTABLE";

                using (var scon = Connections.Connect())
                {
                    scon.Open();
                    SqlCommand traceInsert = new SqlCommand("INSERT INTO " + temp + " SELECT * FROM ::fn_trace_gettable('" + folderOne + newLoc + "', default)", scon);
                    traceInsert.ExecuteNonQuery();
                    scon.Close();
                    //scon.Dispose();
                }

                Console.WriteLine("Deleting file ... ");

                File.Delete(folderOne + newLoc);

                Console.WriteLine("Inserting trace data into main table ... ");

                using (var scon = Connections.Connect())
                {
                    scon.Open();
                    SqlCommand moveData = new SqlCommand("stp_InsertTraceData @t,@m", scon);
                    moveData.Parameters.AddWithValue("@t", temp);
                    moveData.Parameters.AddWithValue("@m", main);
                    moveData.ExecuteNonQuery();
                    scon.Close();
                    //scon.Dispose();
                }

                Console.WriteLine("Cleaning temp table for next file ... ");

                using (var scon = Connections.Connect())
                {
                    scon.Open();
                    SqlCommand clean = new SqlCommand("TRUNCATE TABLE " + temp, scon);
                    clean.ExecuteNonQuery();
                    scon.Close();
                    //scon.Dispose();
                }

                Console.WriteLine("Data from trace file added and trace file deleted.");
            }

            Console.ReadLine();

        }
    }

    public static class Connections
    {
        public static SqlConnection Connect()
        {
            string server = "SERVER";
            string database = "DATABASE";
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "integrated security=SSPI;data source=" + server + ";persist security info=False;initial catalog=" + database + ";Connection Timeout=90";
            return scon;
        }
    }
}
