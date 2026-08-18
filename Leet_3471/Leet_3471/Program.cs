namespace Leet_3471
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string input = Console.ReadLine();
            int[] nums = input.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+LargestInteger(nums,k));
        }

        public static int LargestInteger(int[] nums, int k)
        {
            if (k == nums.Length)
            {
                return nums.Max();
            }

            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq[num] = 1;
            }

            int res = -1;

            if (k == 1)
            {
                foreach (int num in nums)
                {
                    if (freq[num] == 1)
                    {
                        res = Math.Max(res, num);
                    }
                }

                return res;
            }

            if (freq[nums[0]] == 1)
            {
                res = nums[0];
            }

            if (freq[nums[nums.Length - 1]] == 1)
            {
                res = Math.Max(res, nums[nums.Length - 1]);
            }

            return res;
        }
    }
}
