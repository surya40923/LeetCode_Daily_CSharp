using System.Text;

namespace Leet_301
{
    internal class Program
    {
        public static HashSet<string> valid = new HashSet<string>();
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");string s = Console.ReadLine();
            IList<string> list = RemoveInvalidParentheses(s);
            Console.WriteLine("Output : ["+string.Join(',',list)+"]");
        }

        public static void Recurse(string s, int index, int leftCount, int rightCount,
        int leftRem, int rightRem, StringBuilder expression)
        {
            if (index == s.Length)
            {
                if (leftRem == 0 && rightRem == 0)
                {
                    valid.Add(expression.ToString());
                }
            }
            else
            {
                char character = s[index];
                int length = expression.Length;

                if ((character == '(' && leftRem > 0) ||
                    (character == ')' && rightRem > 0))
                {
                    Recurse(
                        s,
                        index + 1,
                        leftCount,
                        rightCount,
                        leftRem - (character == '(' ? 1 : 0),
                        rightRem - (character == ')' ? 1 : 0),
                        expression
                    );
                }

                expression.Append(character);

                if (character != '(' && character != ')')
                {
                    Recurse(
                        s, index + 1,
                        leftCount, rightCount,
                        leftRem, rightRem,
                        expression
                    );
                }
                else if (character == '(')
                {
                    Recurse(
                        s, index + 1,
                        leftCount + 1, rightCount,
                        leftRem, rightRem,
                        expression
                    );
                }
                else if (rightCount < leftCount)
                {
                    Recurse(
                        s, index + 1,
                        leftCount, rightCount + 1,
                        leftRem, rightRem,
                        expression
                    );
                }

                expression.Remove(length, 1);
            }
        }

        public static IList<string> RemoveInvalidParentheses(string s)
        {
            int left = 0;
            int right = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    left++;
                }
                else if (s[i] == ')')
                {
                    right = left == 0 ? right + 1 : right;
                    left = left > 0 ? left - 1 : left;
                }
            }

            Recurse(s,0,0,0,left,right,new StringBuilder());

            return new List<string>(valid);

        }

    }
}
