using System.Net.Sockets;

namespace Leet_3876
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+UniformArray(nums));
        }

        public static bool UniformArray(int[] nums1)
        {
            int mn = nums1[0];
            bool hasOdd = false;
            foreach(int v in nums1)
            {
                if (v < mn) mn = v;
                if(v % 2 != 0) hasOdd = true;
            }
            if(mn % 2 != 0) return true;
            return !hasOdd;
        }
    }
}
