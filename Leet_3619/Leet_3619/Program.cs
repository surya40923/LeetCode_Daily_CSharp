using System.ComponentModel.Design;

namespace Leet_3619
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Input : ");string arr = Console.ReadLine();
            int[][] nums = arr.Trim('[',']')
                .Split("],[")
                .Select(x => x.Trim('[',']').Split(",").Select(int.Parse).ToArray())
                .ToArray();
            Console.Write("Enter Num : ");int n = int.Parse(Console.ReadLine());
            Console.Write("Output : "+CountIslands(nums,n));
        }

        public static int CountIslands(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        int total = dfs(grid, i, j);
                        if (total % k == 0) count++;
                    }
                }
            }
            return count;
        }

        public static int dfs(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length
                || grid[i][j] == 0)
                return 0;
            int val = grid[i][j];
            grid[i][j] = 0;
            val += dfs(grid, i + 1, j);
            val += dfs(grid, i - 1, j);
            val += dfs(grid, i, j + 1);
            val += dfs(grid, i, j - 1);
            return val;
        }
    }
}
