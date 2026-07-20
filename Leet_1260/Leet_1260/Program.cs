namespace Leet_1260
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Grid: ");
            string input = Console.ReadLine();
            int[][] nums = Parse2DArray(input);

            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());

            IList<IList<int>> result = ShiftGrid(nums, k);

            Console.WriteLine("\nOutput:");
            Console.WriteLine("[");

            foreach (IList<int> row in result)
            {
                Console.WriteLine($"  [{string.Join(", ", row)}]");
            }

            Console.WriteLine("]");
        }

        static int[][] Parse2DArray(string input)
        {
            input = input.Replace(" ", "");
            input = input.Trim();

            // Remove outer [[ and ]]
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

        public static IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int row = grid.Length;
            int col = grid[0].Length;

            int n = row * col;
            k %= n;

            if (k == 0)
                return grid.Select(r => (IList<int>)r.ToList()).ToList();

            // Reverse the entire grid (flattened)
            Reverse(grid, 0, n - 1, col);

            // Reverse the first k elements
            Reverse(grid, 0, k - 1, col);

            // Reverse the remaining elements
            Reverse(grid, k, n - 1, col);

            return grid.Select(r => (IList<int>)r.ToList()).ToList();
        }

        private static void Reverse(int[][] grid, int left, int right, int col)
        {
            while (left < right)
            {
                int r1 = left / col;
                int c1 = left % col;

                int r2 = right / col;
                int c2 = right % col;

                // Swap the two elements
                (grid[r1][c1], grid[r2][c2]) = (grid[r2][c2], grid[r1][c1]);

                left++;
                right--;
            }
        }
    }
}
