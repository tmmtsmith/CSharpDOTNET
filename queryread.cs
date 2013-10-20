            DataTable datab = new DataTable();
            using (var scon = Connections.Connect())
            {
                SqlCommand returndata = new SqlCommand("SELECT * FROM Table", scon);
                SqlDataReader dataread = returndata.ExecuteReader();

                while (dataread.Read())
                {
                    for (int i = 0; i < dataread.FieldCount; i++)
                    {
                        Console.WriteLine(dataread[i] + " ");
                    }
                }

                dataread.Close();
                scon.Close();
            }

            Console.ReadLine();
