namespace Leet_940
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter s : ");string s = Console.ReadLine();
            Console.WriteLine("Output : "+DistinctSubseqII(s));
        }

        public static int DistinctSubseqII(string s)
        {
            int MOD = 1_000_000_007;
            int n = s.Length;
            int[] dp = new int[n+1];
            dp[0] = 1;
            int[] last = new int[26];
            Array.Fill(last, -1);
            for(int i = 0; i < n; i++)
            {
                int x = s[i] - 'a';
                dp[i + 1] = dp[i] * 2 % MOD;
                if (last[x] >= 0)
                {
                    dp[i+1] -= dp[last[x]];
                    dp[i+1] %= MOD;
                }
                last[x] = i;
            }

            dp[n]--;
            if (dp[n] < 0) dp[n] += MOD;
            return dp[n];
        }
    }
}
