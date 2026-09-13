namespace Leet_835
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter img1: ");
            string input1 = Console.ReadLine();

            Console.Write("Enter img2: ");
            string input2 = Console.ReadLine();

            int[][] img1 = Parse2DArray(input1);
            int[][] img2 = Parse2DArray(input2);

            Console.WriteLine("img1:");
            for (int i = 0; i < img1.Length; i++)
            {
                Console.WriteLine("[" + string.Join(",", img1[i]) + "]");
            }

            Console.WriteLine("img2:");
            for (int i = 0; i < img2.Length; i++)
            {
                Console.WriteLine("[" + string.Join(",", img2[i]) + "]");
            }
        }

        public static int[][] Parse2DArray(string input)
        {
            input = input.Trim();

            // Remove the outer [[ and ]]
            input = input.Substring(2, input.Length - 4);

            // Separate rows
            string[] rows = input.Split(new string[] { "],[" }, StringSplitOptions.None);

            int[][] result = new int[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i].Replace("[", "").Replace("]", "");

                string[] values = row.Split(',');

                result[i] = new int[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    result[i][j] = int.Parse(values[j]);
                }
            }

            return result;
        }

        public int LargestOverlap(int[][] img1, int[][] img2)
        {
            int n = img1.Length;

            List<int[]> ones1 = new List<int[]>();
            List<int[]> ones2 = new List<int[]>();

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (img1[r][c] == 1)
                        ones1.Add(new int[] { r, c });

                    if (img2[r][c] == 1)
                        ones2.Add(new int[] { r, c });
                }
            }

            Dictionary<string, int> shiftCounts =
                new Dictionary<string, int>();

            int maxOverlap = 0;

            foreach (int[] p1 in ones1)
            {
                foreach (int[] p2 in ones2)
                {
                    string shift =
                        (p2[0] - p1[0]) + "," + (p2[1] - p1[1]);

                    if (!shiftCounts.ContainsKey(shift))
                    {
                        shiftCounts[shift] = 0;
                    }

                    shiftCounts[shift]++;

                    maxOverlap = Math.Max(
                        maxOverlap,
                        shiftCounts[shift]
                    );
                }
            }

            return maxOverlap;
        }
    }
}
