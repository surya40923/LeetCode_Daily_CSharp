namespace Leet_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[][] nums = arr.Trim('[',']')
                .Split("],[")
                .Select(x => x.Trim('[',']').Split(",").Select(int.Parse).ToArray())
                .ToArray();
            Console.Write("Output : "+MinCost(nums));
        }

        public static int MinCost(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[][] dp = new bool[n][];
            for (int i = 0; i < n; i++) dp[i] = new bool[1024];

            dp[0][grid[0][0]] = true;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int val = grid[i][j];
                    bool[] nextDp = new bool[1024];

                    for (int k = 0; k < 1024; k++)
                    {
                        if (dp[j][k] || (j > 0 && dp[j - 1][k]))
                        {
                            nextDp[k ^ val] = true;
                        }
                    }

                    dp[j] = nextDp;
                }
            }

            for (int k = 0; k < 1024; k++)
            {
                if (dp[n - 1][k])
                    return k;
            }

            return 0;
        }
    }
}
