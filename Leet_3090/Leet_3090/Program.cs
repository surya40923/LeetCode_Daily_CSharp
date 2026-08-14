using System.Text.Json.Serialization.Metadata;

namespace Leet_3090
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter s : ");string s = Console.ReadLine();
            Console.Write("Output : "+MaximumLengthSubstring(s));
        }

        public static int MaximumLengthSubstring(string s)
        {
            int[] count = new int[26];
            int left = 0;int res = 0;
            for(int right = 0;right < s.Length;right ++)
            {
                count[s[right] - 'a']++;
                while (count[s[right] - 'a'] > 2)
                {
                    count[s[left] - 'a']--;
                    left++;
                }
                res = Math.Max(res, right - left + 1);
            }
            return res;
        }
    }
}
