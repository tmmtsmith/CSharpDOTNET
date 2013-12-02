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
