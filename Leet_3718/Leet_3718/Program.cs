namespace Leet_3718
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+MissingMultiple(nums,k));
        }

        public static int MissingMultiple(int[] nums, int k)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach(int num in nums)
            {
                seen.Add(num);
            }

            int ans = k;
            while(seen.Contains(ans))
            {
                ans += k;
            }
            return ans;
        }
    }
}
