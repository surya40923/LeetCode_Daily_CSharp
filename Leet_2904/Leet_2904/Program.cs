namespace Leet_2904
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");string s = Console.ReadLine();
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+ShortestBeautifulSubstring(s,k));
        }

        public static string ShortestBeautifulSubstring(string s, int k)
        {
            int n = s.Length;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                    count++;
            }

            if (count < k)
                return "";

            string ans = s;
            int left = 0;
            int ones = 0;

            for (int right = 0; right < n; right++)
            {
                if (s[right] == '1')
                    ones++;

                while (ones > k || (left <= right && s[left] == '0'))
                {
                    if (s[left] == '1')
                        ones--;

                    left++;
                }

                if (ones == k)
                {
                    string t = s.Substring(left, right - left + 1);

                    if (t.Length < ans.Length ||
                        (t.Length == ans.Length && string.Compare(t, ans) < 0))
                    {
                        ans = t;
                    }
                }
            }

            return ans;
        }
    }
}
