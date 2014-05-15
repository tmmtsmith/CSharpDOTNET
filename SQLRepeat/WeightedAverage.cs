public static class Mathematics
{
	public static double WeightedAverage(double[] arr)
	{
		double avg;
		double a = 0, b = 0;
		List<double> x = new List<double>();
		List<double> y = new List<double>();
		int cnt = 1;

		foreach (double n in arr)
		{
			if (cnt % 2 == 1)
			{
				x.Add(n);
				a = n;
			}
			else
			{
				b = n;
				y.Add((a * b));
			}
			cnt++;
		}
		double xsum = x.Sum();
		double ysum = y.Sum();
		avg = (ysum / xsum);
		return avg;
	}
	
	public static double Average(double[] arr)
	{
		// Note that C# includes average already
		double tot = arr.Sum();
		int num = arr.Count();
		return (tot / num);
	}
	
	//  Correct later; VS down
	public static double Median(double[] arr)
        {
        	public static double Median(double[] arr)
	        {
	            Array.Sort(arr);
	            int arrcnt = arr.Count();
	            double rep = arrcnt / 2.0;
	            if (arrcnt % 2 == 1)
	            {
	                int mpo = Convert.ToInt16(Math.Floor(rep));
	                return arr[mpo];
	            }
	            else
	            {
	                int r = Convert.ToInt16(rep);
	                int rr = r - 1;
	                double o = arr[(r)];
	                double e = arr[arrcnt / rr];
	                double[] a = { o, e };
	                double med = a.Average();
	                return med;
	            }
	        }
        }

}
