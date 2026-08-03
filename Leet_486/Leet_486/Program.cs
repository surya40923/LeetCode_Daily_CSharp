namespace Leet_486
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string input = Console.ReadLine();
            int[] nums = input.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+PredictTheWinner(nums));
        }

        public static int MaxDiff(int[] nums, int left, int right, int?[,] memo)
        {
            if (left == right)
                return nums[left];

            if (memo[left, right].HasValue)
                return memo[left, right].Value;

            int pickLeft = nums[left] - MaxDiff(nums, left + 1, right, memo);
            int pickRight = nums[right] - MaxDiff(nums, left, right - 1, memo);

            memo[left, right] = Math.Max(pickLeft, pickRight);

            return memo[left, right].Value;
        }

        public static bool PredictTheWinner(int[] nums)
        {
            int?[,] memo = new int?[nums.Length, nums.Length];
            return MaxDiff(nums, 0, nums.Length - 1, memo) >= 0;
        }
    }
}
