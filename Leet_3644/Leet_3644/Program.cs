namespace Leet_3644
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Output : "+SortPermutation(nums));
        }

        public static int SortPermutation(int[] nums)
        {
            int res = -1;
            for(int i = 0;i < nums.Length;i++)
            {
                if (nums[i] == i) continue;
                res &= nums[i];
            }
            return res == -1 ? 0 : res;
        }
    }
}
