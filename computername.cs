using System;
using System.Collections.Generic;
using System.Linq;

namespace Functinos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Comp());
            Console.ReadLine();
        }

        static public string Comp()
        {
            string CompName = System.Environment.MachineName;
            return CompName;
        }
    }
}
