namespace Leet_1096
{
    internal class Program
    {
        public static string s;
        public static int n;
        public static int idx = 0;

        static void Main(string[] args)
        {
            Console.Write("Enter string : ");
            string input = Console.ReadLine();
            IList<string> result = BraceExpansionII(input);
            Console.WriteLine("[\"" + string.Join("\",\"", result) + "\"]");
        }

        public static IList<string> BraceExpansionII(string expression)
        {
            n = expression.Length;
            s = expression;
            idx = 0;
            SortedSet<string> st = PerformUnion();
            return new List<string>(st);
        }

        public static SortedSet<string> GetUnit()
        {
            SortedSet<string> result;
            if (s[idx] == '{')
            {
                idx++;
                result = PerformUnion();
            }
            else
            {
                result = new SortedSet<string>();
                result.Add(s[idx].ToString());
            }
            idx++;
            return result;
        }

        public static SortedSet<string> PerformConcat()
        {
            SortedSet<string> result = new SortedSet<string>();
            result.Add("");
            while (idx < n && (s[idx] == '{' || char.IsLetter(s[idx])))
            {
                SortedSet<string> temp = GetUnit();
                SortedSet<string> concatResult = new SortedSet<string>();
                foreach (string left in result)
                {
                    foreach (string right in temp)
                    {
                        concatResult.Add(left + right);
                    }
                }
                result = concatResult;
            }
            return result;
        }

        public static SortedSet<string> PerformUnion()
        {
            SortedSet<string> result = new SortedSet<string>();
            while (true)
            {
                SortedSet<string> temp = PerformConcat();
                foreach (string str in temp)
                {
                    result.Add(str);
                }

                if (idx < n && s[idx] == ',')
                {
                    idx++;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
