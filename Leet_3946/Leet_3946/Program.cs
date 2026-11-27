namespace Leet_3946
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string input = Console.ReadLine();
            int[][] nums = input.Trim('[',']').Split("],[")
                .Select(x => x.Trim('[',']').Split(",").Select(int.Parse).ToArray())
                .ToArray();
            Console.Write("Enter budget : ");int budget = int.Parse(Console.ReadLine());
            int res = MaximumSaleItems(nums, budget);
            Console.Write("Output : " + res);
        }

        public static int MaximumSaleItems(int[][] items, int budget)
        {
            int[] f = new int[budget + 1];
            int mn = int.MaxValue;
            foreach (int[] item in items)
            {
                mn = Math.Min(mn, item[1]);
            }

            foreach (int[] item in items)
            {
                int factor = item[0];
                int price = item[1];
                int cnt = 0;
                foreach(int[] other in items)
                {
                    if (other[0] % factor == 0)
                        cnt++;
                }
                for(int j = budget;j >= price;j--)
                {
                    if (f[j - price] + cnt > f[j])
                    {
                        f[j] = f[j - price] + cnt;
                    }
                }
            }

            int ans = 0;
            for(int j = 0;j <= budget;j++)
            {
                ans = Math.Max(ans, f[j] + (budget - j) / mn);
            }
            return ans;
        }
    }
}
