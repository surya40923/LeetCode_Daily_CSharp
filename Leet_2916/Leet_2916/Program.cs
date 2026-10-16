namespace Leet_2916
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+ SumCounts(nums));
        }

        class BIT
        {
            int size;
            long[] tree1, tree2;

            public BIT(int n)
            {
                size = n;
                tree1 = new long[n + 2];
                tree2 = new long[n + 2];
            }

            int Lowbit(int index)
            {
                return index & -index;
            }

            public void Add(int left, int right, int delta)
            {
                _Add(left, delta);
                _Add(right + 1, -delta);
            }

            public long Query(int left, int right)
            {
                return _Query(right) - _Query(left - 1);
            }

            void _Add(int index, int delta)
            {
                index += 1;
                int rawIndex = index;

                while (index <= size)
                {
                    tree1[index] += delta;
                    tree2[index] += (long)(rawIndex - 1) * delta;
                    index += Lowbit(index);
                }
            }

            long _Query(int index)
            {
                index += 1;
                int rawIndex = index;
                long res = 0;

                while (index > 0)
                {
                    res += (long)rawIndex * tree1[index] - tree2[index];
                    index -= Lowbit(index);
                }

                return res;
            }

        }

        public static int SumCounts(int[] nums)
        {
            int n = nums.Length;
            BIT bit = new BIT(n);

            Dictionary<int, int> seen = new Dictionary<int, int>();

            long cur = 0, res = 0;
            long MOD = 1000000007;

            for (int i = 0; i < n; i++)
            {
                int a = nums[i];

                int j = (seen.ContainsKey(a) ? seen[a] : -1) + 1;

                long x_sum = bit.Query(j, i);

                long total_increase = (2 * x_sum + (i - j + 1)) % MOD;

                cur = (cur + total_increase) % MOD;
                res = (res + cur) % MOD;

                bit.Add(j, i, 1);

                seen[a] = i;
            }

            return (int)res;
        }
    }
}
