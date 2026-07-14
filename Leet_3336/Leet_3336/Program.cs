namespace Leet_3336
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[', ']').Split(',').Select(int.Parse).ToArray();
            int output = SubsequencePairCount(nums);
            Console.Write("Output : "+output);
        }

        private const int MOD = 1000000007;

        public static int SubsequencePairCount(int[] nums)
        {
            int m = 0;
            foreach (int num in nums)
            {
                m = Math.Max(m, num);
            }

            int[][] dp = new int[m + 1][];
            for (int i = 0; i <= m; i++)
                dp[i] = new int[m + 1];

            dp[0][0] = 1;

            foreach (int num in nums)
            {
                int[][] ndp = new int[m + 1][];
                for (int i = 0; i <= m; i++)
                    ndp[i] = new int[m + 1];

                for (int j = 0; j <= m; j++)
                {
                    int div1 = (j == 0) ? num : GCD(j, num);

                    for (int k = 0; k <= m; k++)
                    {
                        if (dp[j][k] == 0)
                            continue;

                        int div2 = (k == 0) ? num : GCD(k, num);

                        // Don't take num
                        ndp[j][k] = (ndp[j][k] + dp[j][k]) % MOD;

                        // Take num in first subsequence
                        ndp[div1][k] = (ndp[div1][k] + dp[j][k]) % MOD;

                        // Take num in second subsequence
                        ndp[j][div2] = (ndp[j][div2] + dp[j][k]) % MOD;
                    }
                }

                dp = ndp;
            }

            int ans = 0;

            for (int i = 1; i <= m; i++)
            {
                ans = (ans + dp[i][i]) % MOD;
            }

            return ans;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
