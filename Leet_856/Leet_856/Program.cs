namespace Leet_856
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter String : "); string s = Console.ReadLine();
            Console.WriteLine("Output : " + ScoreOfParentheses(s));
        }

        public static int ScoreOfParentheses(string s)
        {
            int score = 0;
            int depth = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') depth++;
                else
                {
                    depth--;
                    if (s[i - 1] == '(')
                        score += (1 << depth);
                }
            }

            return score;
        }
    }
}
