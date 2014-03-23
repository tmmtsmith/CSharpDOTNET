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

    public static DataGridView RefreshReturnGridView(DataGridView dgv, string query, SqlConnection scon)
    {
        SqlCommand queryGrid = new SqlCommand(query, scon);
        SqlDataAdapter sAdapt = new SqlDataAdapter(queryGrid);
        sAdapt.SelectCommand = queryGrid;
        DataTable dTab = new DataTable();
        sAdapt.Fill(dTab);
        BindingSource b = new BindingSource();
        b.DataSource = dTab;
        dgv.DataSource = b;
        sAdapt.Update(dTab);
        return dgv;
    }
}




public static class StringDate
{
    public static string GetYYYYMMDDStringDate()
    {
        DateTime now = DateTime.Now;
        string y = now.Year.ToString();
        string m = now.Month.ToString();
        string d = now.Day.ToString();

        // Month
        if (m.Length == 1)
        {
            m = "0" + m;
        }

        // Day
        if (d.Length == 1)
        {
            d = "0" + d;
        }

        return y + m + d;

    }

    public static string GetYYYYMMDDHHMMSSStringDate()
    {
        DateTime now = DateTime.Now;
        string yyyymmmdd = StringDate.GetYYYYMMDDStringDate();
        string h = now.Hour.ToString();
        string m = now.Minute.ToString();
        string s = now.Second.ToString();

        // Hour
        if (h.Length == 1)
        {
            h = "0" + h;
        }

        // Minute
        if (m.Length == 1)
        {
            m = "0" + m;
        }

        // Second
        if (s.Length == 1)
        {
            s = "0" + s;
        }

        return yyyymmmdd + h + m + s;
    }
}
