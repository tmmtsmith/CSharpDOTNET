public static class Mathematics
    {
        public static double Average(List<double> Two)
        {            
            double avg = Two.Average();
            return avg;
        }

        public static double Rate(double ne, double ol)
        {
            double r;
            r = ((ne - ol) / (ol)) * 100;
            return r;
        }
        public static double GetPricing(double x, double y, double z)
        {
            double a = (z / 100);
            double b = x * y;
            double c = a * b;
            return c;
        }
    }
