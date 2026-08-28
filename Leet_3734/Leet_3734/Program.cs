using System;
using System.Text;
using System.Linq;

namespace Leet_3734
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter s : ");
            string s = Console.ReadLine();

            Console.Write("Enter target : ");
            string target = Console.ReadLine();

            string result = LexPalindromicPermutation(s, target);

            Console.WriteLine("Result : " + result);
        }

        public static string LexPalindromicPermutation(string s, string target)
        {
            int n = s.Length;

            if (n == 1)
                return string.Compare(s, target) > 0 ? s : "";

            int[] cnt = new int[26];

            // Count characters
            foreach (char c in s)
            {
                cnt[c - 'a']++;
            }

            string oddChar = "";

            // Check for odd-frequency character
            for (int i = 0; i < 26; i++)
            {
                if (cnt[i] % 2 == 1)
                {
                    if (!string.IsNullOrEmpty(oddChar))
                        return "";

                    oddChar = ((char)('a' + i)).ToString();
                }

                cnt[i] /= 2;
            }

            StringBuilder prefix = new StringBuilder();

            for (int i = 0; i < n / 2; i++)
            {
                bool placed = false;

                for (int j = 0; j < 26; j++)
                {
                    if (cnt[j] > 0)
                    {
                        cnt[j]--;
                        prefix.Append((char)('a' + j));

                        StringBuilder remLeft = new StringBuilder();

                        // Build remaining characters in descending order
                        for (int k = 25; k >= 0; k--)
                        {
                            for (int count = 0; count < cnt[k]; count++)
                            {
                                remLeft.Append((char)('a' + k));
                            }
                        }

                        string candLeft =
                            prefix.ToString() + remLeft.ToString();

                        // Reverse candLeft
                        string reversedCandLeft =
                            new string(candLeft.Reverse().ToArray());

                        string candPal =
                            candLeft +
                            oddChar +
                            reversedCandLeft;

                        if (string.Compare(candPal, target) > 0)
                        {
                            placed = true;
                            break;
                        }

                        // Undo the choice
                        prefix.Remove(prefix.Length - 1, 1);
                        cnt[j]++;
                    }
                }

                if (!placed)
                    return "";
            }

            string finalLeft = prefix.ToString();

            // Reverse finalLeft
            string reversedFinalLeft =
                new string(finalLeft.Reverse().ToArray());

            return finalLeft +
                   oddChar +
                   reversedFinalLeft;
        }
    }
}