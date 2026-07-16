namespace Leet_3867
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[', ']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Output : " + GcdSum(nums));
        }

        public static long GcdSum(int[] nums)
        {
            int n = nums.Length;
            int prefixMax = 0;
            int[] prefixGCD = new int[n];

            for(int i = 0;i < n;i++)
            {
                prefixMax = Math.Max(prefixMax, nums[i]);
                prefixGCD[i] = GCD(nums[i],prefixMax);
            }

            Array.Sort(prefixGCD);

            int ans = 0;
            int left = 0; int right = n - 1;
            while(left < right)
            {
                ans += GCD(prefixGCD[left], prefixGCD[right]);
                left++;
                right--;
            }
            return ans;
        }

        public static int GCD(int a,int b)
        {
            while(b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
