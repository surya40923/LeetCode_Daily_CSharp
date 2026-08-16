namespace Leet_3702
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Output : "+LongestSubsequence(nums));
        }

        public static int LongestSubsequence(int[] nums)
        {
            int n = nums.Length;
            int totalXor = 0;
            bool allZero = true;
            foreach(int x in nums)
            {
                totalXor ^= x;
                if(x > 0) allZero = false;
            }
            if (totalXor > 0) return n;
            return allZero ? 0 : n - 1;
        }
    }
}
