using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;

namespace TestMethods
{
    //  Index note: adjclose may not reflect actual adjustments
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirI = new DirectoryInfo(@"C:\Files\");
            int b = dirI.GetFiles().Length;
            string[] filePs = Directory.GetFiles(@"C:\Files\");

            int a = 0;
            b = b - 1;

            while (a <= b)
            {
                string m = GetFile(filePs[a]);
                using (var scon = Connections.Connect())
                {
                    SqlCommand addStock = new SqlCommand("INSERT INTO Table (Value) SELECT UPPER(@p1)", scon);
                    addStock.Parameters.Add(new SqlParameter("@p1", m));
                    addStock.ExecuteNonQuery();
                    scon.Close();
                }
                a++;
            }
            

            Console.WriteLine("Values inserted.");
            Console.ReadLine();


        }
        public static string GetFile(string file)
        {
            string parsedName = file.Replace(".txt", "");
            parsedName = parsedName.Replace("C:\\Files\\", "");
            return parsedName;
        }

        public static class Connections
        {
            public static SqlConnection Connect()
            {
                SqlConnection scon = new SqlConnection();
                scon.ConnectionString = "integrated security=SSPI;data source=DATABASE;persist security info=False;initial catalog=StockAnalysis;Connect Timeout=600";
                scon.Open();
                return scon;
            }
        }
    }
}
