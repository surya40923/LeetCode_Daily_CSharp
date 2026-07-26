namespace Leet_628
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string s = Console.ReadLine();
            int[] n = s.Trim('[', ']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Output : "+MaximumProduct(n));
        }

        public static int MaximumProduct(int[] nums)
        {
            int min1 = int.MaxValue;int min2 = int.MaxValue;
            int max1 = int.MinValue;int max2 = int.MinValue;int max3 = int.MinValue;
            foreach(int n in nums)
            {
                if(n <= min1)
                {
                    min2 = min1;
                    min1 = n;
                }
                else if(n <= min2)
                {
                    min2 = n;
                }
                if(n >= max1)
                {
                    max3 = max2;max2 = max1;max1 = n;
                }
                else if(n >= max2)
                {
                    max3 = max2;max2 = n;
                }
                else if(n >= max3)
                {
                    max3 = n;
                }
            }
            return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
        }
    }
}
