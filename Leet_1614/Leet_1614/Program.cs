using System.Threading.Channels;

namespace Leet_1614
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");
            string input = Console.ReadLine();
            Console.WriteLine("Output : "+MaxDepth(input));
        }

        public static int MaxDepth(string s)
        {
            int ans = 0;
            int openBrackets = 0;
            foreach(char c in s)
            {
                if (c == '(') openBrackets++;
                else if (c == ')') openBrackets--;
                ans = Math.Max(ans,openBrackets);
            }
            return ans;
        }
    }
}
