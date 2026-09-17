namespace Leet_1477
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Enter array : "); string arr = Console.ReadLine();
                int[] nums = arr.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
                Console.Write("Enter target : "); int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Output : " + MinSumOfLengths(nums, target));

                Console.Write("Enter x to exit : ");char c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (c == 'x' || c == 'X') break;
            }
        }

        public static int MinSumOfLengths(int[] arr, int target)
        {
            int n = arr.Length;
            int ans = n + 1;
            int total = 0;
            int left = 0;
            int[] dp = new int[n + 1];
            Array.Fill(dp, n);
            for(int right = 0; right < n; right++)
            {
                total += arr[right];
                while(total > target) total -= arr[left++];
                dp[right + 1] = dp[right];
                if(total == target)
                {
                    ans = Math.Min(ans,right - left + 1 + dp[left]);
                    dp[right + 1] = Math.Min(dp[right + 1], right - left + 1);
                }
            }
            return ans == n + 1 ? -1 : ans;
        }
    }
}
