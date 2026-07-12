namespace Leet_1331
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
            int[] result = ArrayRankTransform(nums);
            Console.Write("Output : ");
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
        public static int[] ArrayRankTransform(int[] arr)
        {
            Dictionary<int,int> rankSet = new Dictionary<int,int>();
            int[] sorted = (int[])arr.Clone();
            Array.Sort(sorted);
            int rank = 1;
            for (int i = 0; i < sorted.Length; i++)
            {
                if (i > 0 && sorted[i] > sorted[i - 1])
                {
                    rank++;
                }

                rankSet[sorted[i]] = rank;
            }

            for(int i = 0;i < arr.Length;i++)
            {
                arr[i] = rankSet[arr[i]];
            }

            return arr;
        }
    }
}
