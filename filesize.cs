using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileCrazy
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dInf = new DirectoryInfo(@"F:\Archive");
            FileInfo[] fArray = dInf.GetFiles();
            Console.WriteLine("Directory, {0}, contains the files: ", dInf.Name);

            Console.WriteLine("\n" + "File Name: File Size");
            foreach (FileInfo fi in fArray)
            {
                long mb = (fi.Length / 1048576);
                Console.WriteLine("{0}: {1} MB", fi.Name, mb);
            }
            Console.ReadLine();

        }
    }
}
