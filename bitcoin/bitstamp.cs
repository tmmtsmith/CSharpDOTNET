using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;

namespace BitCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            int y = 1;
            while (y = 1)
            {
                Console.WriteLine("Waiting ... " + "\n");

                Thread.Sleep(180000); // Should be three minutes
                
                using (var webC = new System.Net.WebClient())
                {
                    var json = webC.DownloadString("https://www.bitstamp.net/api/ticker/");
                    string x = json.ToString();

                    using (var scon = Utilities.Connect())
                    {
                        SqlCommand bitIn = new SqlCommand("INSERT INTO BitstampJSONData (JSONData) SELECT @p", scon);
                        bitIn.Parameters.Add(new SqlParameter("@p", x));
                        bitIn.ExecuteNonQuery();
                        scon.Close();
                    }

                    Console.WriteLine("\t Bitcoin data imported.");
                    //y++;
                }
            }
        }
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
