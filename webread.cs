using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace TestTextReaders
{
    class Program
    {
        static void Main()
        {

            WebClient c = new WebClient();
            string dAll = c.DownloadString("https://news.google.com/");
            // HTML
            dAll = Regex.Replace(dAll, "<.*?>", string.Empty);
            // JAVASCRIPT
            dAll = Regex.Replace(dAll, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            // DECODE POSSIBLE TSQL ISSUES:
            dAll = dAll.Replace("'", "");


            using (var scon = Connections.Connect())
            {
                SqlCommand web = new SqlCommand("INSERT INTO WebPageReader (WebData) VALUES ('" + dAll + "')", scon);
                web.ExecuteNonQuery();
                scon.Close();
            }

            Console.WriteLine("Data inputted");
            Console.ReadLine();
        }
    }

    public static class Connections
    {
        public static SqlConnection Connect()
        {
            string server = "OURSERVER";
            string database = "OURDATABASE";
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "integrated security=SSPI;data source=" + server + ";persist security info=False;initial catalog=" + database + "";
            scon.Open();
            return scon;
        }
    }
}
