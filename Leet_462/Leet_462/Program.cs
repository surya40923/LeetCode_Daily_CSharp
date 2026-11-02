using System.ComponentModel;

namespace Leet_462
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Output : " + MinMoves2(nums));
        }

        public static int MinMoves2(int[] nums)
        {
            Array.Sort(nums);
            int middleNum = nums[nums.Length / 2];
            int moves = 0;
            foreach(int num in nums)
            {
                moves += Math.Abs(num - middleNum);
            }
            return moves;
        }
    }
}
