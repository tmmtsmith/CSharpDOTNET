using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a symbol");
                string userinput = Console.ReadLine();
                string sym = userinput.ToUpper();

                Console.WriteLine("Would you like the default historic date?");
                string answer = Console.ReadLine();
                answer = answer.ToLower();
                int pYear, pMonth, pDay;


                if (answer == "no")
                {
                    Console.WriteLine("Enter historic year");
                    string sYear = Console.ReadLine();
                    pYear = Convert.ToInt16(sYear);

                    Console.WriteLine("Enter historic month");
                    string sMonth = Console.ReadLine();
                    pMonth = Convert.ToInt16(sMonth);
                    pMonth = pMonth - 1;

                    Console.WriteLine("Enter historic day");
                    string sDay = Console.ReadLine();
                    pDay = Convert.ToInt16(sDay);
                }
                else
                {
                    pYear = 1993;
                    pMonth = 1;
                    pDay = 1;
                }

            if (sym.Length > 0)
            {
                x = 1;
            }

            if (x == 1)
            {
                    DATAPATH;
                    Console.WriteLine("Retrieving data path.");
                    string oldFile = "C:\\Location\\table.csv";
                    string newFile = "C:\\Location\\" + sym + ".csv";

                    int y = 0;
                    while (y < 1)
                    {
                        if (File.Exists(oldFile))
                        {
                            File.Move(oldFile, newFile);
                            y = 1;
                        }
                        else
                        {
                            y = 0;
                        }
                    }
                    string import = "E:\\Location\\Import\\";
                    File.Move(newFile, import + sym + ".csv");
                    Console.WriteLine("Preliminary work on file completed.");
            }
            
        }
    }
}
