namespace Leet_115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string s : ");string s = Console.ReadLine();
            Console.Write("Enter string t : ");string t = Console.ReadLine();
            Console.WriteLine("Output : "+NumDistinct(s,t));
        }

        public static int NumDistinct(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[m, n];
        }
    }
}
