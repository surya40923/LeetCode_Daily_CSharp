namespace Leet_1658
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+MinOperations(nums,x));
        }

        public static int MinOperations(int[] nums, int x)
        {
            int totalSum = 0;
            foreach (int num in nums) totalSum += num;

            int target = totalSum - x;
            if (target < 0) return -1;

            int maxLen = -1;
            int currentSum = 0;
            int left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                currentSum += nums[right];

                while (currentSum > target && left <= right)
                {
                    currentSum -= nums[left];
                    left++;
                }

                if (currentSum == target)
                {
                    maxLen = Math.Max(maxLen, right - left + 1);
                }
            }

            return maxLen == -1 ? -1 : nums.Length - maxLen;
        }
    }
}
