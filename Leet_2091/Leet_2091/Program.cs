namespace Leet_2091
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+MinimumDeletions(nums));
        }

        public static int MinimumDeletions(int[] nums)
        {
            int n = nums.Length;
            int minIdx = 0;int maxIdx = 0;
            for(int i = 0;i < n; i++)
            {
                if(nums[i] < nums[minIdx]) minIdx = i;
                if(nums[i] > nums[maxIdx]) maxIdx = i;
            }
            int l = Math.Min(minIdx, maxIdx);
            int r = Math.Max(minIdx, maxIdx);
            return Math.Min(r + 1, Math.Min(n - l,(l + 1) + (n - r)));
        }
    }
}
