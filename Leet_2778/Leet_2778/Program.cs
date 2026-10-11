namespace Leet_2778
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+SumOfSquares(nums));
        }

        public static int SumOfSquares(int[] nums)
        {
            int n = nums.Length;
            int ans = 0;
            for(int i = 0; i < n;i++)
            {
                if(n % (i + 1) == 0)
                {
                    ans += nums[i] * nums[i];
                }
            }
            return ans; 
        }
    }
}
