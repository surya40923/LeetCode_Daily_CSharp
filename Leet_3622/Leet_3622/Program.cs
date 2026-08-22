namespace Leet_3622
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Input : ");int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+CheckDivisibility(n));
        }

        public static bool CheckDivisibility(int n)
        {
            int digit_sum = 0;
            int digit_product = 1;
            int temp = n;

            while(temp > 0)
            {
                int digit = temp % 10;
                temp = temp / 10;

                digit_sum = digit_sum + digit;
                digit_product = digit_product * digit;
            }

            return n % (digit_sum + digit_product) == 0;
        }
    }
}
