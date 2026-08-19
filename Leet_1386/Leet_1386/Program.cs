namespace Leet_1386
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");int n = int.Parse(Console.ReadLine());
            Console.Write("Enter reservedSeats : ");string input = Console.ReadLine();
            int[][] reservedSeats = Parse2DArray(input);

            //Print Checker
            Console.WriteLine("Parsed array:");
            for (int i = 0; i < reservedSeats.Length; i++)
            {
                Console.WriteLine("[" + string.Join(",", reservedSeats[i]) + "]");
            }

            //Output
            int result = MaxNumberOfFamilies(n, reservedSeats);
            Console.WriteLine("Output : " + result);
        }

        public static int[][] Parse2DArray(string input)
        {
            input = input.Trim();
            input = input.Trim('[', ']');
            string[] rows = input.Split("],[");
            int[][] result = new int[rows.Length][];
            for(int i = 0;i < rows.Length;i++)
            {
                rows[i] = rows[i].Trim('[', ']');
                string[] values = rows[i].Split(',');
                result[i] = new int[values.Length];
                for(int j = 0;j < values.Length;j++)
                {
                    result[i][j] = int.Parse(values[j].Trim());
                }
            }
            return result;
        }

        public static int MaxNumberOfFamilies(int n, int[][] reservedSeats)
        {
            int left = 0b11110000;
            int middle = 0b11000011;
            int right = 0b00001111;
            Dictionary<int, int> occupied = new Dictionary<int, int>();
            foreach (int[] seat in reservedSeats)
            {
                if (seat[1] >= 2 && seat[1] <= 9)
                {
                    if(!occupied.ContainsKey(seat[0]))
                        occupied[seat[0]] = 0;

                    occupied[seat[0]] |= (1 << (seat[1] - 2));
                }
            }
            int ans = (n - occupied.Count) * 2;
            foreach (int bitmask in occupied.Values)
            {
                if ((bitmask | left) == left ||
                    (bitmask | middle) == middle ||
                    (bitmask | right) == right)
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
