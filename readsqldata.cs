// C# Read

// EXAMPLE:

          else if (value == "get the tables")
                {
                    Console.WriteLine("Enter server");
                    string serve = Console.ReadLine();
                    Console.WriteLine("Enter database");
                    string db = Console.ReadLine();
                    SqlConnection sc = new SqlConnection("integrated security=SSPI;data source=" + serve + ";persist security info=False;initial catalog=" + db + "");
                    sc.Open();
                    SqlCommand ch = new SqlCommand("SELECT name FROM sys.tables", sc);
                    SqlDataReader dr = ch.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(String.Format("{0}", dr[0]));
                    }
                    sc.Close();
                }
