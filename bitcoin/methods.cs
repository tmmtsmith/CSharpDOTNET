        public static string Clean(string x)
        {
            string y = x.Replace("last", "");
            y = y.Replace("\"", "");
            y = y.Replace(":", "");
            y = y.Replace(" ", "");
            return y;
        }
