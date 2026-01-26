namespace _0004_LeetProblem_1984
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            input = input.Trim('[', ']').Replace(" ", "");
            string[] parts = input.Split(",");
            int[] nums = new int[parts.Length];
            for(int i = 0; i < parts.Length; i++)
            {
                nums[i] = int.Parse(parts[i]);
            }
            Console.Write("Enter k : ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(MinimumDifference(nums,k));
        }

        static int MinimumDifference(int[] nums, int k)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int ans = int.MaxValue;
            for (int i = 0; i + k - 1 < n; ++i)
            {
                ans = Math.Min(ans, nums[i + k - 1] - nums[i]);
            }
            return ans;
        }
    }
}
