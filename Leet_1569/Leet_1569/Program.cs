using System.ComponentModel.Design;

namespace Leet_1569
{
    internal class Program
    {
        public static long[][] comb;
        public static long Mod = 1000000007;
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+NumOfWays(nums));
        }

        public static int NumOfWays(int[] nums)
        {
            int n = nums.Length;
            comb = new long[n][];

            for (int i = 0; i < n; i++)
            {
                comb[i] = new long[n];
                comb[i][0] = comb[i][i] = 1;

                for (int j = 1; j < i; j++)
                {
                    comb[i][j] =
                        (comb[i - 1][j - 1] + comb[i - 1][j]) % Mod;
                }
            }

            List<int> list = new List<int>();

            foreach (int num in nums)
                list.Add(num);

            return (int)((dfs(list) - 1 + Mod) % Mod);

        }

        public static long dfs(List<int> list)
        {
            if (list.Count < 3)
                return 1;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int root = list[0];

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < root)
                    left.Add(list[i]);
                else
                    right.Add(list[i]);
            }

            long leftWays = dfs(left);
            long rightWays = dfs(right);

            int m = list.Count;

            long ways = (leftWays * rightWays) % Mod;

            return (ways * comb[m - 1][left.Count]) % Mod;
        }
    }
}
