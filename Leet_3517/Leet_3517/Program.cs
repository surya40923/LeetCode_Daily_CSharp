using System.Text;

namespace Leet_3517
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");string input = Console.ReadLine();
            Console.Write("Output : "+SmallestPalindrome(input));
        }

        public static string SmallestPalindrome(string s)
        {
            int n = s.Length;
            int[] bucket = new int[26];

            for (int i = 0; i < n / 2; i++)
                bucket[s[i] - 'a']++;

            StringBuilder left = new StringBuilder();

            for (int i = 0; i < 26; i++)
                left.Append(new string((char)('a' + i), bucket[i]));

            string mid = n % 2 == 1 ? s[n / 2].ToString() : "";
            string right = new string(left.ToString().Reverse().ToArray());

            return left.ToString() + mid + right;
        }
    }
}
