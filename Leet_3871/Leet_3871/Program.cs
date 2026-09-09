namespace Leet_3871
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num : ");
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+CountCommas(n));
        }

        public static long CountCommas(long n)
        {
            long p = 1000;
            long res = 0;
            while (p <= n)
            {
                res += n - p + 1;
                p *= 1000;
            }
            return res;
        }
    }
}
