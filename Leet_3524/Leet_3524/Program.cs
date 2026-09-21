namespace Leet_3524
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            long[] res = ResultArray(nums, k);
            Console.WriteLine("Ouput : ["+String.Join(",",res)+"]");
        }

        public static long[] ResultArray(int[] nums, int k)
        {
            long[] result = new long[k];
            long[] dp = new long[k];
            foreach(int num in nums)
            {
                long[] nextdp = new long[k];
                nextdp[num % k] += 1;
                for(int r = 0;r < k;r++)
                {
                    if (dp[r] > 0)
                    {
                        int newr = (int)(((long)r * num) % k);
                        nextdp[newr] += dp[r];
                    }
                }
                dp = nextdp;
                for(int r = 0;r < k;r++)
                {
                    result[r] += dp[r];
                }
            }
            return result;
        }

    }
}
