/*

  Repeat classes for files

*/


public static class ReadFiles
{
    public static string SelectFirstLine(string file)
    {
        System.IO.StreamReader readfile = new System.IO.StreamReader(file);
        int cnt = 1;
        string line = "";
        for (int i = 1; i < (cnt + 1); i++ )
        {
            line = readfile.ReadLine();
            
        }
        return line;
    }

    public static string GetLineByNumber(string file, int lineNo)
    {
        System.IO.StreamReader readfile = new System.IO.StreamReader(file);
        int cnt = lineNo;
        string line = "";
        for (int i = 1; i < (cnt + 1); i++ )
        {
            line = readfile.ReadLine();
            
        }
        return line;
    }
}
