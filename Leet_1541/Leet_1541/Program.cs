namespace Leet_1541
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");string s = Console.ReadLine();
            Console.WriteLine("Output : "+MinInsertions(s));
        }

        public static int MinInsertions(string s)
        {
            int len = s.Length;
            int insertion = 0;
            int leftcount = 0;
            int idx = 0;
            while(idx < len)
            {
                if (s[idx] == '(')
                {
                    leftcount++;
                    idx++;
                }
                else
                {
                    if (leftcount > 0) leftcount--;
                    else insertion++;
                    if (idx < len - 1 && s[idx + 1] == ')') idx += 2;
                    else
                    {
                        insertion++;
                        idx++;
                    }
                }
            }
            insertion += leftcount * 2;
            return insertion;
        }
    }
}
