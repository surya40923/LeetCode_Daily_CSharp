namespace Leet_3312
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[', ']').Split(',').Select(int.Parse).ToArray();

            Console.Write("Enter Query : ");
            string query = Console.ReadLine();
            int[] queries = query.Trim('[', ']').Split(',').Select(int.Parse).ToArray();

            int[] result = GcdValues(nums, queries);

            Console.WriteLine("Output: [" + string.Join(", ", result) + "]");
        }

        public static int[] GcdValues(int[] nums, int[] queries)
        {
            int m = 0;

            foreach (int num in nums)
                m = Math.Max(m, num);

            long[] cnt = new long[m + 1];

            // Count frequency of each number
            foreach (int num in nums)
                cnt[num]++;

            // Count how many numbers are divisible by i
            for (int i = 1; i <= m; i++)
            {
                for (int j = i * 2; j <= m; j += i)
                {
                    cnt[i] += cnt[j];
                }
            }

            // Number of pairs divisible by i
            for (int i = 1; i <= m; i++)
            {
                cnt[i] = cnt[i] * (cnt[i] - 1) / 2;
            }

            // Inclusion-Exclusion to count pairs whose GCD is exactly i
            for (int i = m; i >= 1; i--)
            {
                for (int j = i * 2; j <= m; j += i)
                {
                    cnt[i] -= cnt[j];
                }
            }

            // Prefix sum
            for (int i = 1; i <= m; i++)
            {
                cnt[i] += cnt[i - 1];
            }

            int[] ans = new int[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                long q = queries[i] + 1;

                int left = 1;
                int right = m;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (cnt[mid] >= q)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }

                ans[i] = left;
            }

            return ans;
        }
    }
}
