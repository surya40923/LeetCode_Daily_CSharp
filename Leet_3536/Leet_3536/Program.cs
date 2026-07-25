namespace Leet_3536
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num : ");
            int input = int.Parse(Console.ReadLine());
            Console.Write("Output : " + MaxProduct(input));
        }

        public static int MaxProduct(int n)
        {
            int first = 0; int second = 0;
            while(n > 0)
            {
                int x = n % 10;
                if( x > first )
                {
                    second = first;
                    first = x;
                }
                else if (x > second)
                {
                    second = x;
                }
                n /= 10;
            }
            return first * second;
        }
    }
}
