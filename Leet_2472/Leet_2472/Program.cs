namespace Leet_2472
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");string input = Console.ReadLine();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+MaxPalindromes(input,k));
        }

        public static int MaxPalindromes(string s, int k)
        {
            int n = s.Length;
            int ans = 0;
            int start = 0;
            for(int r = k - 1; r < n; r++)
            {
                int l1 = r - k + 1;
                if(l1 >= start && check(s,l1,r))
                {
                    ans++;start = r + 1;continue;
                }
                int l2 = r - k;
                if(l2 >= start && check(s,l2,r))
                {
                    ans++;start = r + 1;
                }
            }
            return ans;
        }

        public static bool check(string s,int l,int r)
        {
            while(l < r)
            {
                if (s[l++] != s[r--]) return false;
            }
            return true;
        }
    }
}
