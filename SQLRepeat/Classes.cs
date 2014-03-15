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
