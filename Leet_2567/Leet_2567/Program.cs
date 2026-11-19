namespace Leet_2567
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : " + MinimizeSum(nums));
        }

        public static int MinimizeSum(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            return Math.Min(nums[n - 3] - nums[0],Math.Min(nums[n - 1] - nums[2], nums[n - 2] - nums[1]));
        }
    }
}
