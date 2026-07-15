using System;

namespace Leet_3658
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number : ");
            int num = int.Parse(Console.ReadLine());
            int output = GcdOfOddEvenSums(num);
            Console.WriteLine("Output : "+output);

        }

        public static int GcdOfOddEvenSums(int n)
        {
            int sumOdd = 0;
            int sumEven = 0;
            for (int i = 1; i <= n; i++)
            {
                sumOdd += (2 * i - 1);
                sumEven += (2 * i);
            }
            int result = GCD(sumOdd, sumEven);
            return result;
        }

        private static int GCD(int a,int b)
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
