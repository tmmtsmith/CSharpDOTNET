public static class Connections
{
    public static SqlConnection Connect()
    {
        SqlConnection scon = new SqlConnection(@"integrated security=SSPI;data source=SERVER\INSTANCE;persist security info=False;initial catalog=DATABASE");
        scon.Open();
        return scon;
    }

    public static string GetFiles(string src, string dest)
    {
        try
        {
            WebClient getFile = new WebClient();
            getFile.DownloadFile(src, dest);
            return "Success";
        }
        catch
        {
            return "Failure";
        }
    }
}




public static class SQLTools
{
    public static AddData(string query)
    {
        using (var scon = Connections.Connect())
        {
            SqlCommand add = new SqlCommand(query, scon);
            add.ExecuteNonQuery();
            scon.Close();
        }
        
        return 1;
    }

    public static DataGridView ReturnGridView(DataGridView dG, string query)
    {
        using (var scon = Connections.Connect())
        {
            SqlCommand queryGrid = new SqlCommand(query, scon);
            SqlDataAdapter sAdapt = new SqlDataAdapter(queryGrid);
            sAdapt.SelectCommand = queryGrid;
            DataTable dTab = new DataTable();
            sAdapt.Fill(dTab);
            BindingSource b = new BindingSource();
            b.DataSource = dTab;
            dG.DataSource = b;
            sAdapt.Update(dTab);
            scon.Close();
            return dG;
        }
    }
}




public static class StringDate
{
    public static string GetYYYYMMDDStringDate()
    {
        DateTime now = DateTime.Now;

        string y, m, d;
        y = now.Year.ToString();

        // Month
        if (now.Month.ToString().Length == 1)
        {
            m = "0" + now.Month.ToString();
        }
        else
        {
            m = now.Month.ToString();
        }

        // Day
        if (now.Day.ToString().Length == 1)
        {
            d = "0" + now.Day.ToString();
        }
        else
        {
            d = now.Day.ToString();
        }

        return y + m + d;

    }

    public static string GetYYYYMMDDHHMMSSStringDate()
    {
        DateTime now = DateTime.Now;
        string yyyymmmdd = StringDate.GetYYYYMMDDStringDate();
        string h, m, s;

        // Hour
        if (now.Hour.ToString().Length == 1)
        {
            h = "0" + now.Hour.ToString();
        }
        else
        {
            h = now.Hour.ToString();
        }

        // Minute
        if (now.Minute.ToString().Length == 1)
        {
            m = "0" + now.Minute.ToString();
        }
        else
        {
            m = now.Minute.ToString();
        }

        // Second
        if (now.Second.ToString().Length == 1)
        {
            s = "0" + now.Second.ToString();
        }
        else
        {
            s = now.Second.ToString();
        }

        return yyyymmmdd + h + m + s;
    }
}
