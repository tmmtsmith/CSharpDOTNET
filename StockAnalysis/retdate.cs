// After connecting:

SqlCommand year = new SqlCommand("SELECT YEAR(MAX(Date)) FROM stock.HistoricalData", conn);
SqlCommand month = new SqlCommand("SELECT MONTH(MAX(Date)) FROM stock.HistoricalData", conn);
SqlCommand day = new SqlCommand("SELECT DAY(MAX(Date)) FROM stock.HistoricalData", conn);

string y = Convert.ToString(year.ExecuteScalar());
string m = Convert.ToString(month.ExecuteScalar());
string d = Convert.ToString(day.ExecuteScalar());

upyear = Convert.ToInt16(y);
upmonth = Convert.ToInt16(m);
upmonth = upmonth - 1;
upday = Convert.ToInt16(d);

// IMP

conn.Close()
