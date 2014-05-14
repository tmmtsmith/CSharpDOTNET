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
}