namespace Leet_1979
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            int[] nums = input.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Output : "+FindGcd(nums));
        }

        public static int FindGcd(int[] nums)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }
            return Gcd(min, max);
        }

        public static int Gcd(int a,int b)
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
