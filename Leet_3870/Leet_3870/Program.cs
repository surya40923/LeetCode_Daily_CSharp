namespace Leet_3870
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+CountCommas(n));
        }

        public static int CountCommas(int n)
        {
            return Math.Max(n - 999, 0);
        }
    }
}
