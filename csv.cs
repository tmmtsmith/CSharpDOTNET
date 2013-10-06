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
                string row = csvG.ReadLine();
                foreach (string field in fields)
                {
                    Console.WriteLine(field);
                }
            }
            csvG.Close();
            Console.ReadLine();
        }
    }
}
