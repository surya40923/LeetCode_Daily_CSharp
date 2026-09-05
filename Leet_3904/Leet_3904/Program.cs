namespace Leet_3904
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : " + FirstStableIndex(nums,k));
        }

        public static int FirstStableIndex(int[] nums, int k)
        {
            int n = nums.Length;
            int[] minValue = new int[n];
            minValue[n - 1] = nums[n - 1];
            for(int i = n - 2;i >= 0; i--)
            {
                minValue[i] = Math.Min(minValue[i + 1], nums[i]);
            }
            int maxValue = 0;
            for(int i = 0; i < n; i++)
            {
                maxValue = Math.Max(maxValue, nums[i]);
                if(maxValue - minValue[i] <= k)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

