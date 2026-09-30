using System.Runtime.CompilerServices;

namespace Leet_2267
{
    internal class Program
    {
        public static int m;
        public static int n;
        public static int[][][] t;

        static void Main(string[] args)
        {
            Console.Write("Enter Grid : ");string input = Console.ReadLine();
            input = input.Trim('[', ']');
            string[] rows = input.Split("],[");
            char[][] grid = new char[rows.Length][];
            for(int i = 0;i < rows.Length;i++)
            {
                string row = rows[i].Replace("[", "")
                                .Replace("]", "")
                                .Replace("\"", "")
                                .Replace(",", "");

                grid[i] = row.ToCharArray();
            }
            bool result = HasValidPath(grid);
            Console.WriteLine("Output : "+result);
        }

        public static bool Solve(int i, int j, int openCount, char[][] grid)
        {
            openCount += (grid[i][j] == '(') ? 1 : -1;
            if (openCount < 0) return false;
            if (t[i][j][openCount] != -1) return t[i][j][openCount] == 1;
            if (i == m - 1 && j == n - 1)
            {
                t[i][j][openCount] = (openCount == 0) ? 1 : 0;
                return openCount == 0;
            }

            // move down
            if (i + 1 < m)
            {
                if (Solve(i + 1, j, openCount, grid))
                {
                    t[i][j][openCount] = 1;
                    return true;
                }
            }

            // move right
            if (j + 1 < n)
            {
                if (Solve(i, j + 1, openCount, grid))
                {
                    t[i][j][openCount] = 1;
                    return true;
                }
            }

            t[i][j][openCount] = 0;
            return false;
        }

        public static bool HasValidPath(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            if ((m + n - 1) % 2 == 1) return false;
            if (grid[0][0] == ')' || grid[m - 1][n - 1] == '(') return false;
            t = new int[m][][];
            for(int i = 0;i < m; i++)
            {
                t[i] = new int[n][];
                for(int j = 0;j < n;j++)
                {
                    t[i][j] = new int[201];
                    for (int k = 0; k < 201; k++)
                    {
                        t[i][j][k] = -1;
                    }
                }
            }
            return Solve(0, 0, 0, grid);
        }
    }
}
