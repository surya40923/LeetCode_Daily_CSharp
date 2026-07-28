using System.ComponentModel;

namespace Leet_1464
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Output : " + MaxProduct(nums));
        }

        public static int MaxProduct(int[] nums)
        {
            /*
            int[] r = nums.OrderByDescending(x => x).Take(2).ToArray();
            return (r[0] - 1) * (r[1] - 1);
            */

            int max1 = 0, max2 = 0;

            foreach (int num in nums)
            {
                if (num > max1)
                {
                    max2 = max1;
                    max1 = num;
                }
                else if (num > max2)
                {
                    max2 = num;
                }
            }

            return (max1 - 1) * (max2 - 1);
        }
    }
}
