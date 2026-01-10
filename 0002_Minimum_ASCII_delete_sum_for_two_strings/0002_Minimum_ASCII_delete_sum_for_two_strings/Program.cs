using static System.Net.Mime.MediaTypeNames;

namespace _0002_Minimum_ASCII_delete_sum_for_two_strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String 1 : ");
            string s1 = Console.ReadLine();
            Console.Write("Enter String 2 : ");
            string s2 = Console.ReadLine();
            Console.WriteLine("Total Sum : "+MinimumDelete(s1,s2));
        }

        static int MinimumDelete(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;
            int[,] dp = new int[n + 1, m + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + (int)s1[i - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int totalSum = 0;
            foreach (char c in s1) totalSum += c;
            foreach (char c in s2) totalSum += c;

            return totalSum - 2 * dp[n, m];
        }
    }
}
