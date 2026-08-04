namespace Leet_3731
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string n = Console.ReadLine();
            int[] nums = n.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            var result = FindMissingElements(nums);
            Console.WriteLine(string.Join(", ",result));
        }

        public static IList<int> FindMissingElements(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            int mn = int.MaxValue;
            int mx = int.MinValue;

            foreach (int num in nums)
            {
                set.Add(num);
                mn = Math.Min(mn, num);
                mx = Math.Max(mx, num);
            }

            IList<int> ans = new List<int>();

            for (int i = mn + 1; i < mx; i++)
            {
                if (!set.Contains(i))
                    ans.Add(i);
            }

            return ans;
        }

        /*
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int num in nums)
                set.Add(num);

            IList<int> ans = new List<int>();

            for (int i = 1; i <= nums.Length; i++)
            {
                if (!set.Contains(i))
                    ans.Add(i);
            }

            return ans;
        }
        */
    }
}
