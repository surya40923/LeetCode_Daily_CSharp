using System.Numerics;

namespace Leet_1254
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Input : ");string input = Console.ReadLine();
            int[][] nums = input.Trim('[', ']')
                .Split("],[")
                .Select(x => x.Trim('[', ']').Split(',').Select(int.Parse).ToArray())
                .ToArray();
            Console.Write("Output : "+ClosedIsland(nums));
        }

        public static int ClosedIsland(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[][] visit = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visit[i] = new bool[n];
            }
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 0 && !visit[i][j] && dfs(i, j, m, n, grid, visit))
                    {
                        count++;
                    }
                }
            }
            return count;

        }

        public static bool dfs(int x, int y, int m, int n, int[][] grid, bool[][] visit)
        {
            if (x < 0 || x >= m ||  y < 0 || y >= n) return false;
            if (grid[x][y] == 1 || visit[x][y]) return true;

            visit[x][y] = true;
            bool isClosed = true;
            int[] dirx = { 0, 1, 0, -1 };
            int[] diry = { -1, 0, 1, 0 };

            for(int i = 0; i < 4; i++)
            {
                int r = x + dirx[i];
                int c = y + diry[i];
                if (!dfs(r, c, m, n, grid, visit))
                {
                    isClosed = false;
                }
            }
            return isClosed;
        }
    }
}
