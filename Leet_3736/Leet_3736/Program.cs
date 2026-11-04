namespace Leet_3736
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']')
                .Split(",")
                .Select(int.Parse)
                .ToArray();
            Console.Write("Output : " + MinMoves(nums));
        }

        public static int MinMoves(int[] nums)
        {
            Array.Sort(nums);
            int high = nums[nums.Length - 1];
            int moves = 0;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                moves += Math.Abs(high - nums[i]);
            }
            return moves;
        }
    }
}
