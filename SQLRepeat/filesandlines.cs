/*

  Repeat classes for files

*/

// Each method is written indepedently of other methods so that developers can use a portion of them without
// needing to use the others.

public static class ReadFiles
{
    public static string SelectFirstLine(string file)
    {
        System.IO.StreamReader readfile = new System.IO.StreamReader(file);
        string line = "";
        for (int i = 1; i < 2; i++)
        {
            line = readfile.ReadLine();
        }
        return line;
    }


    public static string GetLineByNumber(string file, int lineNo)
    {
        System.IO.StreamReader readfile = new System.IO.StreamReader(file);
        string line = "";
        for (int i = 1; i < (lineNo + 1); i++)
        {
            line = readfile.ReadLine();
        }
        return line;
    }


    public static string GetFileName(string file)
    {
        string f = file.Substring(file.LastIndexOf("\\") + 1);
        f = f.Substring(0, f.IndexOf("."));
        return f;
    }


    public static string GetFileNameWithExtension(string file)
    {
        string f = file.Substring(file.LastIndexOf("\\") + 1);
        return f;
    }

    public static int CountInvalidLines(string file, int validcount, char ch)
    {
        System.IO.StreamReader readfile = new System.IO.StreamReader(file);
        int cnt = 0, total;
        string line;

        while ((line = readfile.ReadLine()) != null)
        {
            total = line.Split(ch).Length - 1;
            if (total != validcount)
            {
                cnt++;
            }
        }
        readfile.Close();
        readfile.Dispose();
        return cnt;
    }

    public static int CountValidLines(string file, int validcount, char ch)
    {
        System.IO.StreamReader readfile = new System.IO.StreamReader(file);
        int cnt = 0, total;
        string line;

        while ((line = readfile.ReadLine()) != null)
        {
            total = line.Split(ch).Length - 1;
            if (total == validcount)
            {
                cnt++;
            }
        }
        readfile.Close();
        readfile.Dispose();
        return cnt;
    }

    public static double InvalidToValid(string file, int validcount, char ch)
    {
        double x = Convert.ToDouble((CountInvalidLines(file, validcount, ch))) / Convert.ToDouble((CountValidLines(file, validcount, ch)));
        return x;
    }

    public static int SaveGoodBadLines(string file, int validcount, char ch)
    {
        string loc = file.Substring(0, file.LastIndexOf("\\") + 1);
        string f = file.Substring(file.LastIndexOf("\\") + 1);
        f = f.Substring(0, f.IndexOf("."));

        string validfile = loc + f + "_valid.txt";
        string invalidfile = loc + f + "_invalid.txt";

        if (System.IO.File.Exists(validfile) == true)
        {
            System.IO.File.Delete(validfile);
            System.IO.File.Create(validfile);
        }

        if (System.IO.File.Exists(invalidfile) == true)
        {
            System.IO.File.Delete(invalidfile);
            System.IO.File.Create(invalidfile);
        }

        System.IO.StreamReader readfile = new System.IO.StreamReader(file);
        System.IO.StreamWriter writevalid = new System.IO.StreamWriter(validfile);
        System.IO.StreamWriter writeinvalid = new System.IO.StreamWriter(invalidfile);
        int cnt = 0, total;
        string line;

        while ((line = readfile.ReadLine()) != null)
        {
            total = line.Split(ch).Length - 1;
            if (total == validcount)
            {
                writevalid.WriteLine(line);
            }
            else
            {
                writeinvalid.WriteLine(line);
            }
        }
        readfile.Close();
        readfile.Dispose();
        writevalid.Close();
        writevalid.Dispose();
        writeinvalid.Close();
        writeinvalid.Dispose();
        return cnt;
    }
    
    // Email bad file?
}
