namespace Leet_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N : ");
            int n = int.Parse(Console.ReadLine());
            List<string> res = generateParenthesis(n);
            Console.WriteLine("Output : ["+string.Join(",",res)+"]");
        }

        public static List<String> generateParenthesis(int n)
        {
            List<String> res = new List<String>();
            backtrack(res, "", 0, 0, n);
            return res;
        }

        public static void backtrack(List<String> res, String currentStr, int openCount, int closedCount, int max)
        {
            if (currentStr.Length == max * 2)
            {
                res.Add(currentStr);
                return;
            }

            if (openCount < max) backtrack(res, currentStr + "(", openCount + 1, closedCount, max);
            if (closedCount < openCount) backtrack(res, currentStr + ")", openCount, closedCount + 1, max);
        }
    }
}
