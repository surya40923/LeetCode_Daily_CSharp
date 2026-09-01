using System.Data.Common;

namespace Leet_3568
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter classroom : ");
            string input = Console.ReadLine();

            string[] classroom = input
                .Trim('[', ']')
                .Split(',')
                .Select(x => x.Trim().Trim('"'))
                .ToArray();

            Console.Write("Enter energy : ");
            int energy = int.Parse(Console.ReadLine());

            int result = MinimumMoves(classroom, energy);

            Console.WriteLine("Output : " + result);
        }

        public static int MinimumMoves(string[] classroom, int energy)
        {
            int rows = classroom.Length;
            int cols = classroom[0].Length;

            List<int[]> litters = new List<int[]>();

            int startR = 0;
            int startC = 0;

            // Find starting position and all litter positions
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (classroom[r][c] == 'S')
                    {
                        startR = r;
                        startC = c;
                    }
                    else if (classroom[r][c] == 'L')
                    {
                        litters.Add(new int[] { r, c });
                    }
                }
            }

            // Bitmask representing all litter collected
            int targetMask = (1 << litters.Count) - 1;

            if (targetMask == 0)
                return 0;

            // Queue stores:
            // moves, row, column, mask, energy
            Queue<int[]> q = new Queue<int[]>();

            q.Enqueue(new int[] { 0, startR, startC, 0, energy });

            // visited[row][column][mask] = maximum energy
            // with which we have reached this state
            int[][][] visited = new int[rows][][];

            for (int r = 0; r < rows; r++)
            {
                visited[r] = new int[cols][];

                for (int c = 0; c < cols; c++)
                {
                    visited[r][c] = new int[1 << litters.Count];

                    Array.Fill(visited[r][c], -1);
                }
            }

            visited[startR][startC][0] = energy;

            int[][] dirs =
            {
            new int[] { -1, 0 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { 0, 1 }
        };

            while (q.Count > 0)
            {
                int[] curr = q.Dequeue();

                int moves = curr[0];
                int r = curr[1];
                int c = curr[2];
                int mask = curr[3];
                int currE = curr[4];

                // Can't move if energy is zero
                if (currE == 0)
                    continue;

                foreach (int[] d in dirs)
                {
                    int nr = r + d[0];
                    int nc = c + d[1];

                    // Check boundaries and obstacle
                    if (nr >= 0 &&
                        nr < rows &&
                        nc >= 0 &&
                        nc < cols &&
                        classroom[nr][nc] != 'X')
                    {
                        int nextE = currE - 1;
                        int nextMask = mask;

                        char cell = classroom[nr][nc];

                        // Recharge
                        if (cell == 'R')
                        {
                            nextE = energy;
                        }

                        // Pick up litter
                        if (cell == 'L')
                        {
                            for (int i = 0; i < litters.Count; i++)
                            {
                                if (litters[i][0] == nr &&
                                    litters[i][1] == nc)
                                {
                                    nextMask |= (1 << i);
                                    break;
                                }
                            }
                        }

                        // All litter collected
                        if (nextMask == targetMask)
                            return moves + 1;

                        // Only visit if we arrive with more energy
                        if (visited[nr][nc][nextMask] < nextE)
                        {
                            visited[nr][nc][nextMask] = nextE;

                            q.Enqueue(new int[]
                            {
                            moves + 1,
                            nr,
                            nc,
                            nextMask,
                            nextE
                            });
                        }
                    }
                }
            }

            return -1;
        }
    }
}
