namespace Leet_2333
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array 1 : "); string arr1 = Console.ReadLine();
            Console.Write("Enter Array 2 : "); string arr2 = Console.ReadLine();
            int[] num1 = arr1.Trim('[', ']').Split(',').Select(int.Parse).ToArray();
            int[] num2 = arr2.Trim('[', ']').Split(',').Select(int.Parse).ToArray();
            int k1 = int.Parse(Console.ReadLine());
            int k2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+minSumSquareDiff(num1,num2,k1,k2));

        }

        public static long minSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
        {
            int n = nums1.Length;
            int[] diffs = new int[n];
            long totalDiff = 0;
            int maxDiff = 0;
            for (int i = 0; i < n; i++)
            {
                diffs[i] = Math.Abs(nums1[i] - nums2[i]);
                totalDiff += diffs[i];
                maxDiff = Math.Max(maxDiff, diffs[i]);
            }
            long k = (long)k1 + k2;
            if (k >= totalDiff) return 0;
            int[] counts = new int[maxDiff + 1];
            foreach (int d in diffs) counts[d]++;
            for (int i = maxDiff; i > 0 && k > 0; i--)
            {
                if (counts[i] == 0) continue;
                long reduce = Math.Min((long)counts[i], k);
                counts[i] -= (int)reduce;
                counts[i - 1] += (int)reduce;
                k -= reduce;
            }
            long ans = 0;
            for (int i = 0; i <= maxDiff; i++)
            {
                if (counts[i] > 0) ans += (long)counts[i] * i * i;
            }
            return ans;
        }
    }
}
