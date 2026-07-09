namespace Leet_3532
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter nums : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter maxDiff: ");
            int maxDiff = int.Parse(Console.ReadLine());
            Console.Write("Enter queries : ");
            string queryInput = Console.ReadLine();
            int[][] queries = Parse2DArray(queryInput);


            //Input Checker
            Console.Write("\nOutput : ");
            Console.WriteLine($"n = {n}");
            Console.WriteLine($"nums = [{string.Join(", ", nums)}]");
            Console.WriteLine($"maxDiff = {maxDiff}");
            Console.WriteLine("queries : ");
            foreach (var q in queries)
            {
                Console.WriteLine($"[{q[0]}, {q[1]}]");
            }

            bool[] result = queryPaths(n, nums, maxDiff, queries);

            // Display the result
            Console.WriteLine("\nAnswer:");
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        static int[][] Parse2DArray(string input)
        {
            input = input.Trim();
            input = input.Substring(2, input.Length - 4);
            string[] rows = input.Split("],[");
            int[][] result = new int[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = rows[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }
            return result;
        }

        public static bool[] queryPaths(int n, int[] nums,int maxDiff, int[][] queries)
        {
            int[] groups = new int[n];
            int currId = 0;
            for(int i = 1;i < n; i++)
            {
                if (nums[i] - nums[i-1] > maxDiff)
                {
                    currId++;
                }
                groups[i] = currId;
            }

            bool[] ans = new bool[queries.Length];
            for(int i = 0; i < queries.Length; i++)
            {
                ans[i] = groups[queries[i][0]] == groups[queries[i][1]];
            }
            return ans;
        }
    }
}
