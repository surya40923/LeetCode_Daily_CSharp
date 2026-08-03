namespace Leet_877
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string input = Console.ReadLine();
            int[] nums = input.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+StoneGame(nums));
        }

        //O(1) Constant Time and Space Complexity - Optimal option...
        /*
        public static bool StoneGame(int[] piles)
        {
            return true;
        }
        */

        public static int MaxDiff(int[] piles, int left, int right, int?[,] memo)
        {
            if (left == right)
                return piles[left];

            if (memo[left, right].HasValue)
                return memo[left, right].Value;

            int takeLeft = piles[left] - MaxDiff(piles, left + 1, right, memo);
            int takeRight = piles[right] - MaxDiff(piles, left, right - 1, memo);

            memo[left, right] = Math.Max(takeLeft, takeRight);

            return memo[left, right].Value;
        }

        public static bool StoneGame(int[] piles)
        {
            int n = piles.Length;
            int?[,] memo = new int?[n, n];

            return MaxDiff(piles, 0, n - 1, memo) > 0;
        }
    }
}
