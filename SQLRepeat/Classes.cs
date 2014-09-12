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
    
    public static DataTable exportToDataTable(string srv, string db, string query)
    {
        DataTable qdt = new DataTable();
        using (var scon = Connections.Connect(srv, db))
        {
            SqlCommand qcmd = new SqlCommand(query, scon);
            SqlDataAdapter qda = new SqlDataAdapter(qcmd);
            qda.Fill(qdt);
            return qdt;
        }
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
    
    public static DataTable DataTableFromQuery(string q, SqlConnection scon)
    {
    	SqlCommand cmd = new SqlCommand(q, scon);
    	SqlDataReader dataread;
    	DataTable dt = new DataTable();
    
    	try
    	{
    		scon.Open()
    		dataread = cmd.ExecuteReader();
    
    		foreach (DataRow row in dataread.GetSchemaTable().Rows)
    		{
    			dt.Columns.Add(row["ColumnName"].ToString(), System.Type.GetType(row["DataType"].ToString()));
    		}
    
    		while (dataread.Read())
    		{
    			DataRow row = dt.NewRow();
    
    			for (int i = 0; i < dataread.FieldCount; i++)
    			{
    				row[i] = dataread.GetValue(i);
    			}
    
    			dt.Rows.Add(row);
    		}
    
    		dataread.Close();
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}
    	finally
    	{
    		cmd.Dispose();
    		scon.Close()
    		scon.Dispose()
    	}
    
    	return dt;
    }
    
    public static bool BulkCopy(DataTable sourceTable, string sDestTable)
    {
        // mpp mat.
        using (var scon = Connections.Connect())
        {
            SqlBulkCopy bc = new SqlBulkCopy(scon);
            bc.DestinationTableName = sDestTable;
            bc.WriteToServer(sourceTable);
            return true;
        }
    }
    
    public static MultipleCommands(string[] cmds, SqlConnection scon)
    {
    	SqlCommand cmd = new SqlCommand();
    	SqlCommand.Connection = scon;
    	
    	try
    	{
    		foreach (string c in cmds)
    		{
    			try
    			{
    				scon.Open()
    				cmd.CommandText = c;
    				cmd.ExecuteNonQuery();
    				cmd.CommandText = "";
    			}
    			catch (Exception ex)
    			{
    				throw ex;
    			}
    			finally
    			{
    				scon.Close();
    				scon.Dispose();
    			}
    		}
    		return 1;
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    		return 0;
    	}
    	finally
    	{
    		cmd.Dispose()
    	}
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
