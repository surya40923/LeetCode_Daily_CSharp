using System.Security.Principal;

namespace Leet_3360
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");int n = int.Parse(Console.ReadLine());
            Console.Write("Output : " + CanAliceWin(n));
        }

        public static bool CanAliceWin(int n)
        {
            int take = 10;
            int k = 0;
            while(n >= take)
            {
                n -= take;
                take--;
                k++;
            }
            return k % 2 == 1;
        }
    }
}
