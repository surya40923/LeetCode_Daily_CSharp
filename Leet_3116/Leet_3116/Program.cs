using System.Numerics;

namespace Leet_3116
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+FindKthSmallest(nums,k));
        }

        public static long FindKthSmallest(int[] coins, int k)
        {
            Array.Sort(coins);
            List<int> newCoinList = new List<int>();
            foreach (int x in coins)
            {
                bool redundant = false;
                foreach (int y in newCoinList)
                {
                    if (x % y == 0)
                    {
                        redundant = true;
                        break;
                    }
                }
                if (!redundant)
                {
                    newCoinList.Add(x);
                }
            }

            int n = newCoinList.Count;
            int m = 1 << n;
            long[] lcm = new long[m];
            Array.Fill(lcm, 1);

            long left = k;
            long right = (long)newCoinList[0] * k + 1;

            for (int mask = 1; mask < m; mask++)
            {
                int preMask = mask & (mask - 1);
                int i = BitOperations.TrailingZeroCount(mask);
                long coin = newCoinList[i];

                long gcdVal = gcd(lcm[preMask], coin);
                long tmp = (lcm[preMask] / gcdVal) * coin;

                if (tmp <= right && tmp > 0)
                {
                    lcm[mask] = tmp;
                }
                else
                {
                    lcm[mask] = right + 1;
                }
            }
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if (count(mid, m, lcm) >= k)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        private static long count(long x, int m, long[] lcm)
        {
            long res = 0;
            for (int mask = 1; mask < m; mask++)
            {
                if (BitOperations.PopCount((uint)mask) % 2 == 1)
                {
                    res += x / lcm[mask];
                }
                else
                {
                    res -= x / lcm[mask];
                }
            }
            return res;
        }

        private static long gcd(long a, long b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }
    }
}
