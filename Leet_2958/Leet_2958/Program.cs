namespace Leet_2958
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array : ");string input = Console.ReadLine();
            int[] nums = input.Trim('[', ']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.Write("Output : "+MaxSubarrayLength(nums,k));
        }

        public static int MaxSubarrayLength(int[] nums, int k)
        {
            int ans = 0;int start = -1;
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            for(int end = 0;end < nums.Length; end++)
            {
                if (!frequency.ContainsKey(nums[end]))
                    frequency[nums[end]] = 0;

                frequency[nums[end]]++;

                while (frequency[nums[end]] > k)
                {
                    start++;
                    frequency[nums[start]]--;
                }

                ans = Math.Max(ans, end - start);
            }
            return ans;
        }
    }
}
