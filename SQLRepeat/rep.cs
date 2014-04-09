public static bool ExecuteProcedure(string cmdText, SqlParameter[] procParams)
{
    bool isYes = true;

    using (var scon = Connections.Connect())
    {
        SqlCommand cmd = new SqlCommand(cmdText, scon);
        cmd.CommandType = CommandType.StoredProcedure;

        if (procParams != null)
        {
            foreach (SqlParameter p in procParams)
            {
                cmd.Parameters.Add(p);
            }
        }

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch
        {
            isYes = false;
        }
        finally
        {
            scon.Close();
            cmd.Dispose();
        }

    }

    return isYes;
}

/*
// Null unchanged

SqlParameter[] procParams = 
{
    new SqlParameter("@1", one),
    new SqlParameter("@2", two),
    new SqlParameter("@3", three),
};

ExecuteProcedure("EXEC stp_ProcedureName", procParams);


*/
