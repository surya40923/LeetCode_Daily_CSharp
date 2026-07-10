namespace Leet_3534
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter nums : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[', ']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter maxdiff : ");
            int maxdiff = int.Parse(Console.ReadLine());
            string queryInput = Console.ReadLine();
            int[][] queries = Parse2DArray(queryInput);

            //Input Checker
            Console.Write("\nOutput : ");
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"nums = [{string.Join(", ", nums)}]");
            Console.WriteLine($"maxDiff = {maxdiff}");
            Console.WriteLine("queries : ");
            foreach (var q in queries)
            {
                Console.WriteLine($"[{q[0]}, {q[1]}]");
            }

            //Output
            int[] result = PathExistenceQueries(n, nums, maxdiff, queries);
            Console.WriteLine("\nAnswer:");
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        static int[][] Parse2DArray(string input)
        {
            input = input.Trim();
            input = input.Substring(2, input.Length - 4);
            string[] rows = input.Split("],[");
            int[][] result = new int[rows.Length][];
            for(int i = 0;i < rows.Length; i++)
            {
                result[i] = rows[i].Split(",").Select(int.Parse).ToArray();
            }
            return result;
        }

        public static int[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
        {
            int[] sortedNums = (int[])nums.Clone();
            Array.Sort(sortedNums);

            List<int> arrList = new List<int>();
            arrList.Add(sortedNums[0]);

            for (int i = 1; i < n; i++)
            {
                if (sortedNums[i] != sortedNums[i - 1])
                    arrList.Add(sortedNums[i]);
            }

            int m = arrList.Count;
            int[] arr = arrList.ToArray();

            int[] comp = new int[m];
            for (int i = 1; i < m; i++)
            {
                if (arr[i] - arr[i - 1] <= maxDiff)
                    comp[i] = comp[i - 1];
                else
                    comp[i] = comp[i - 1] + 1;
            }

            const int LOG = 20;
            int[][] up = new int[LOG][];
            for (int i = 0; i < LOG; i++)
                up[i] = new int[m];

            for (int i = 0; i < m; i++)
            {
                int target = arr[i] + maxDiff;
                int left = i;
                int right = m - 1;
                int best = i;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (arr[mid] <= target)
                    {
                        best = mid;
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                up[0][i] = best;
            }

            for (int j = 1; j < LOG; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    up[j][i] = up[j - 1][up[j - 1][i]];
                }
            }

            int[] ans = new int[queries.Length];

            for (int q = 0; q < queries.Length; q++)
            {
                int a = nums[queries[q][0]];
                int b = nums[queries[q][1]];

                if (a > b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }

                if (a == b)
                {
                    ans[q] = 0;
                    continue;
                }

                int idxA = Array.BinarySearch(arr, a);
                int idxB = Array.BinarySearch(arr, b);

                if (comp[idxA] != comp[idxB])
                {
                    ans[q] = -1;
                    continue;
                }

                if (arr[idxA] + maxDiff >= b)
                {
                    ans[q] = 1;
                    continue;
                }

                int curr = idxA;
                int jumps = 0;

                for (int j = LOG - 1; j >= 0; j--)
                {
                    int nextCurr = up[j][curr];

                    if (arr[nextCurr] + maxDiff < b)
                    {
                        curr = nextCurr;
                        jumps += (1 << j);
                    }
                }

                ans[q] = jumps + 2;
            }

            return ans;
        }
    }
}
