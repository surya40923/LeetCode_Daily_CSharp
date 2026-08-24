namespace Leet_1872
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Stones : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+StoneGameVIII(nums));
        }

        public static int StoneGameVIII(int[] stones)
        {
            int n = stones.Length;

            int[] prefixSum = new int[n];
            prefixSum[0] = stones[0];

            for (int i = 1; i < n; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + stones[i];
            }

            int[] t = new int[n];
            t[n - 1] = prefixSum[n - 1];

            for (int i = n - 2; i >= 1; i--)
            {
                int take = prefixSum[i] - t[i + 1];
                int skip = t[i + 1];

                t[i] = Math.Max(take, skip);
            }

            return t[1];
        }
    }
}
