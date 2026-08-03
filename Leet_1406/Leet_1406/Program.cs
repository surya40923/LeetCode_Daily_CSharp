namespace Leet_1406
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string input = Console.ReadLine();
            int[] num = input.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Output : "+StoneGameIII(num));
        }

        public static string StoneGameIII(int[] stoneValue)
        {
            int n = stoneValue.Length;
            int[] dp = new int[n+1];

            for(int i = n - 1;i >= 0;i--)
            {
                int ans = int.MinValue;
                ans = Math.Max(ans, stoneValue[i] - dp[i + 1]);
                if (i + 1 < n) ans = Math.Max(ans, stoneValue[i] + stoneValue[i + 1] - dp[i + 2]);
                if (i + 2 < n) ans = Math.Max(ans, stoneValue[i] + stoneValue[i + 1] + stoneValue[i + 2] - dp[i + 3]);
                dp[i] = ans;
            }

            if (dp[0] > 0) return "Alice";
            if (dp[0] < 0) return "Bob";
            return "Tie";
        }
    }
}
