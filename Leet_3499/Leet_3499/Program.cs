namespace Leet_3499
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter input : ");
            string input = Console.ReadLine();
            Console.WriteLine("Output : "+MaxActiveSectionsAfterTrade(input));
        }

        public static int MaxActiveSectionsAfterTrade(string s)
        {
            int cnt1 = 0;
            foreach(char c in s)
            {
                if (c == '1') cnt1++;
            }
            int n = s.Length;
            int i = 0;
            int best_gain = 0;
            int prev = -(int)1e9;
            
            while(i < n)
            {
                int start = i;
                while (i < n && s[i] == s[start]) i++;
                if (s[start] == '0')
                {
                    int cur = i - start;
                    best_gain = Math.Max(best_gain, prev + cur);
                    prev = cur;
                }
            }
            return cnt1 + best_gain;
        }
    }
}
