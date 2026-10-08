using System.Text;

namespace Leet_1021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string s = Console.ReadLine();
            Console.WriteLine("Output : "+RemoveOuterParentheses(s));
        }

        public static string RemoveOuterParentheses(string s)
        {
            StringBuilder res = new StringBuilder();
            int level = 0;
            foreach (char c in s)
            {
                if (c == ')') level--;
                if (level > 0) res.Append(c);
                if (c == '(') level++;
            }
            return res.ToString();
        }
    }
}
