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
            int x = 0;
            DateTime tod = DateTime.Now;
            int tDay = tod.Day;
            int tMonth = tod.Month;
            tMonth = tMonth - 1;

            Console.WriteLine("Enter a symbol");
            string userinput = Console.ReadLine();
            string sym = userinput.ToUpper();

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
