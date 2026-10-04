namespace Leet_678
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");
            string s = Console.ReadLine();
            Console.WriteLine("Output : "+CheckValidString(s));
        }

        public static bool CheckValidString(string s)
        {
            Stack<int> openbrackets = new Stack<int>();
            Stack<int> aestriks = new Stack<int>();

            for(int i = 0;i < s.Length;i++)
            {
                char ch = s[i];
                if(ch == '(') openbrackets.Push(i);
                else if(ch == '*') aestriks.Push(i);
                else
                {
                    if (openbrackets.Count > 0) openbrackets.Pop();
                    else if(aestriks.Count > 0) aestriks.Pop();
                    else return false;
                }
            }

            while (openbrackets.Count > 0 && aestriks.Count > 0)
            {
                if (openbrackets.Pop() > aestriks.Pop()) return false;
            }

            return openbrackets.Count == 0;
        }
    }
}
