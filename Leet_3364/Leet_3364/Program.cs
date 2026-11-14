namespace Leet_3364
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            List<int> list = new List<int>(nums);
            Console.Write("Enter l : ");int l = int.Parse(Console.ReadLine());
            Console.Write("Enter r : ");int r = int.Parse(Console.ReadLine());
            Console.Write("Output : " + MinimumSumSubarray(list,l,r));
        }

        public static int MinimumSumSubarray(IList<int> nums, int l, int r)
        {
            int n = nums.Count();
            int result = int.MaxValue;

            for (int i = 0; i < n; ++i)
            {
                int currSum = 0;

                for (int j = i; j < n && (j - i + 1) <= r; ++j)
                {
                    currSum += nums[j];

                    if ((j - i + 1) >= l && currSum > 0)
                    {
                        result = Math.Min(result, currSum);
                    }
                }
            }

            return result == int.MaxValue ? -1 : result;
        }
    }
}
