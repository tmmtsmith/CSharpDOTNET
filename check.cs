using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FileChecker;

namespace FileChecker
{
    class Program
    {

        static void Main(string[] args)
        {
            int x = 0;

            while (x < 1)
            {
                string fileP = @"E:\Check\*.csv";
                if (File.Exists(fileP))
                {
                    x = 1;
                    Console.WriteLine("File found!  Stopping process");
                }
                else
                {
                    x = 0;
                    Console.WriteLine("Continuing to scan ...");
                }
            }

            Console.ReadLine();
        }
    }
}
