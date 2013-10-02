// After connecting:

SqlCommand year = new SqlCommand("SELECT YEAR(MAX(Date)) FROM stock.HistoricalData", conn);
SqlCommand month = new SqlCommand("SELECT MONTH(MAX(Date)) FROM stock.HistoricalData", conn);
SqlCommand day = new SqlCommand("SELECT DAY(MAX(Date)) FROM stock.HistoricalData", conn);
string y = Convert.ToString(year.ExecuteScalar());
string m = Convert.ToString(month.ExecuteScalar());
string d = Convert.ToString(day.ExecuteScalar());
Console.WriteLine("Latest year is " + y + " latest month is " + m + " latest day is " + d);
