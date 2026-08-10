namespace Leet_1510
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");int n = int.Parse(Console.ReadLine());
            Console.Write("Output : "+WinnerSquareGame(n));
        }

        public static bool WinnerSquareGame(int n)
        {
            bool[] dp = new bool[n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int k = 1; k * k <= i; k++)
                {
                    if (!dp[i - k * k])
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[n];
        }
    }
}
