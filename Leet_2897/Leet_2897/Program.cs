namespace Leet_2897
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+MaxSum(nums,k));
        }

        public static int MaxSum(IList<int> nums, int k)
        {
            int MOD = 1000000007;
            int[] cnt = new int[30];

            foreach (int x in nums)
            {
                for (int i = 0; i < 30; i++)
                {
                    if ((x & (1 << i)) != 0)
                    {
                        cnt[i]++;
                    }
                }
            }

            long res = 0;
            for (int i = 0; i < k; i++)
            {
                long cur = 0;
                for (int j = 29; j >= 0; j--)
                {
                    if (cnt[j] > 0)
                    {
                        cnt[j]--;
                        cur |= (1 << j);
                    }
                }
                res = (res + cur * cur) % MOD;
            }

            return (int)res;
        }
    }
}
