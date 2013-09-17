using System;
using System.Collections.Generic;
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
            }
            
            string oldFile = "C:\\Import\\table.csv";
            string newFile = "C:\\Import\\" + sym + ".csv";
            File.Move(oldFile, newFile);
        }
    }
}
