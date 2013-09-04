using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTools
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> Grades = new List<double>();
            Grades.Add(90);
            Grades.Add(40);
            Grades.Add(85);
            Grades.Add(95);
            Grades.Add(95);
            Grades.Add(100);

            double b = Mathematics.Average(Grades);
            Console.WriteLine(Convert.ToString(b));
            Console.ReadLine();

            double aussieDayOne = .8971;
            double aussieDayTwo = .9102;

            double value = Mathematics.Rate(aussieDayTwo, aussieDayOne);
            Console.WriteLine(Convert.ToString(value));
            Console.ReadLine();
        }
    
    }

    public static class Mathematics
    {
        public static double Average(List<double> Two)
        {            
            double avg = Two.Average();
            return avg;
        }

        public static double Rate(double ne, double ol)
        {
            double r;
            r = ((ne - ol) / (ol)) * 100;
            return r;
        }
    }

}
