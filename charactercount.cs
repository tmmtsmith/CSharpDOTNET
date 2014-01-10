using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CountLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\Public\FileInfo\file.txt";

            int cnt = 0;
            string line;
            int count;

            StreamReader readFile = new StreamReader(file);
            Console.WriteLine("Reviewing the file ...");
            while ((line = readFile.ReadLine()) != null)
            {
                count = line.Split('|').Length - 1;
                string data = "Line: " + cnt.ToString() + "; | number: " + count.ToString();
                // Change column number here
                if (count != 37)
                {
                    using (StreamWriter write = File.AppendText(@"C:\Users\Public\FileInfo\Failures.txt"))
                    {
                        write.WriteLine(data);
                    }
                }
                else
                {
                    using (StreamWriter write = File.AppendText(@"C:\Users\Public\FileInfo\Correct.txt"))
                    {
                        write.WriteLine(data);
                    }
                }
                count = 0;
                cnt++;
            }
            Console.WriteLine("File reviewed.");
            Console.ReadLine();            
        }
    }
}
