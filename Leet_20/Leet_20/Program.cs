namespace Leet_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");
            string s = Console.ReadLine();
            Console.WriteLine("Output : "+isValid(s));
        }

        public static bool isValid(String s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count() == 0 || stack.Pop() != c)
                    return false;
            }
            return stack.Count() == 0;
        }
    }
}
