namespace Leet_3513
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Nums : ");string input = Console.ReadLine();
            int[] nums = input.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Output : "+UniqueXorTriplets(nums));
        }

        public static int UniqueXorTriplets(int[] nums)
        {
            int n = nums.Length;
            if (n <= 2) return n;
            int ans = 1;
            while (ans <= n) ans <<= 1;
            return ans;
        }
    }
}
