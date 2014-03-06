public static class SqlInserts
{
    public static SqlConnection Connect()
    {
        SqlConnection scon = new SqlConnection(@"integrated security=SSPI;data source=SERV\INST;persist security info=False;initial catalog=Database");
        scon.Open();
        return scon;
    }

    //  Insert Methods (will call the connection method)
    public static String AddMerchants(string merch)
    {
        using (var scon = SqlInserts.Connect())
        {
            SqlCommand add = new SqlCommand("INSERT INTO MerchantTracking (MerchantName) SELECT @1", scon);
            add.Parameters.Add(new SqlParameter("@1", merch));
            
            try
            {
                add.ExecuteNonQuery();
                scon.Close();
                return "Merchant added!";
            }
            catch
            {
                scon.Close();
                return "Failed to add merchant";
            }
        }
    }
}
