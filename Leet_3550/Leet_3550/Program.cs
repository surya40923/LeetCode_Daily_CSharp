namespace Leet_3550
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array : ");string input = Console.ReadLine();
            int[] nums = input.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+SmallestIndex(nums));
        }

        public static int SmallestIndex(int[] nums)
        {
            for(int i = 0;i < nums.Length;i++)
            {
                if(getDigit(nums[i]) == i)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int getDigit(int num)
        {
            int total = 0;
            while(num > 0)
            {
                total += num % 10;
                num /= 10;
            }
            return total;
        }
    }
}
