using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace TestTextReaders
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFieldParser csvG = new TextFieldParser(@"E:\Stocks\Archive\AAPL.csv");
            csvG.TextFieldType = FieldType.Delimited;
            // set delimiter
            csvG.SetDelimiters("/r/n");

            while (!csvG.EndOfData)
            {
                string[] fields = csvG.ReadFields();
                foreach (string field in fields)
                {
                    Console.WriteLine(field);
                }
            }
            csvG.Close();
            Console.ReadLine();
        }
    }
    
    //Other approach
    
    class Program
    {
        static void Main()
        {
            using (TextFieldParser parser = new TextFieldParser(@"E:\Stocks\Archive\AAPL.csv"))
            {
                parser.Delimiters = new string[] { "," };
                while (true)
                {
                    string[] columns = parser.ReadFields();
                    if (columns == null)
                    {
                        break;
                    }
                    //Console.WriteLine("{0} field(s)", parts.Length);
                    var date = new List<string>();;
                    Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}", columns);
                }
                Console.ReadLine();
            }
        }
    }
}
