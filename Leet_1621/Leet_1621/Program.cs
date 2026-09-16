namespace Leet_1621
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");int n = int.Parse(Console.ReadLine());
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+NumberOfSets(n,k));
        }

        public static int NumberOfSets(int n, int k)
        {
            long res = 1;
            long mod = 1000000007;

            for (int i = 1; i <= k * 2; i++)
            {
                res = res * (n + k - i) % mod;

                long inverse = ModPow(i, mod - 2, mod);
                res = res * inverse % mod;
            }

            return (int)res;
        }

        public static long ModPow(long a, long b, long mod)
        {
            long result = 1;

            while (b > 0)
            {
                if ((b & 1) == 1)
                    result = result * a % mod;

                a = a * a % mod;
                b >>= 1;
            }

            return result;
        }
    }
}
