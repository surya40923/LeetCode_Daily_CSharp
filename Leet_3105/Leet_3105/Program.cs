using System.Reflection;

namespace Leet_3105
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Output : " + LongestMonotonicSubarray(nums));
        }

        public static int LongestMonotonicSubarray(int[] nums)
        {
            int inc = 1;
            int dec = 1;
            int res = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    inc++;
                    dec = 1;
                    res = Math.Max(res, inc);
                }
                else if (nums[i] < nums[i - 1])
                {
                    dec++;
                    inc = 1;
                    res = Math.Max(res, dec);
                }
                else
                {
                    inc = 1;
                    dec = 1;
                }
            }
            return res;
        }
    }
}
