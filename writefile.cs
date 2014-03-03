// Will need to use System.IO;

string fileString = Utilities.Array(x);
string full = fileString + "," + now.Year + "-" + now.Month + "-" + now.Day + " " + now.TimeOfDay;

using (StreamWriter f = File.AppendText(@"C:\Bitcoin\20131201.txt"))
{
  f.WriteLine(full);
}

public static string Array(string a)
{
  string r = a.Replace("'", "");
  string b = r.Replace("{", "");
  string c = b.Replace("}", "");
  string d = c.Replace(":", "");
  string e = d.Replace(" ", "");
  string f = Regex.Replace(e, "[a-z]", "");
  return f;
}


/*
// Read EX
            string ln;
            int cnt = 0;
            string[] chk = { "fear", "dogs" };
            string fle = @"C:\Files\file.txt";

            StreamReader sr = new StreamReader(fle);

            while ((ln = sr.ReadLine()) != null)
            {
                if (chk.Any(ln.Contains))
                {
                    Console.WriteLine("Containing One: " + "\t" + ln);
                }

                if (chk.All(s => ln.Contains(s)))
                {
                    Console.WriteLine("Containing Both: " + "\t" + ln);
                }

                cnt++;
            }
            Console.WriteLine("\n" + "\t" + "File read.");
            Console.ReadLine();

*/
