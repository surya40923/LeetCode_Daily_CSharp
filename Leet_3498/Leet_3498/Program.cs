namespace Leet_3498
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");string input = Console.ReadLine();
            Console.WriteLine("Output : "+ReverseDegree(input));
        }

        public static int ReverseDegree(string s)
        {
            int ans = 0;
            for(int i = 0;i < s.Length;i++)
            {
                ans += (26 - (s[i] - 'a')) * (i + 1);
            }
            return ans;
        }
    }
}
