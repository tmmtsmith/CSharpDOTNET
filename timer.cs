using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Timer
{
    class Program
    {
        static System.Timers.Timer ti;

        static void Main(string[] args)
        {
            ti = new System.Timers.Timer();

            ti.AutoReset = false;
            ti.Elapsed += new System.Timers.ElapsedEventHandler(t_elp);
            ti.Interval = NextFiveMinutes();
            ti.Start();
            Console.ReadLine();
        }

        static double NextFiveMinutes()
        {
            DateTime now = DateTime.Now;
            return ((300 - now.Second) * 1000 - now.Millisecond);
        }

        static void t_elp(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime min = DateTime.Today;
            string s_min = Convert.ToString(min);
            Console.WriteLine(s_min);
            Console.Beep();
            ti.Interval = NextFiveMinutes();
            ti.Start();
        }
    }
}
