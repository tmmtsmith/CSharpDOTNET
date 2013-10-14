using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Microsoft.VisualBasic.FileIO;

namespace TestTextReaders
{
    class Program
    {
        static void Main()
        {
            System.Net.WebClient web = new System.Net.WebClient();
            Console.WriteLine("Enter the site");
            string site = Console.ReadLine();
            byte[] wdt = web.DownloadData("http://www." + site + "");

            string data = System.Text.Encoding.UTF8.GetString(wdt);
            Console.WriteLine(data);
            Console.ReadLine();
        }
    }
}
