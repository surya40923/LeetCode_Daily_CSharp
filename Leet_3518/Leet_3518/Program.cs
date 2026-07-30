using System;
using System.Text;

namespace Leet_3518
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string input = Console.ReadLine();

            Console.Write("Enter num: ");
            int k = int.Parse(Console.ReadLine());

            string result = SmallestPalindrome(input, k);

            Console.WriteLine("\nOutput:");
            Console.WriteLine(result);
        }

        public static string SmallestPalindrome(string s, int k)
        {
            int n = s.Length;

            char mid = '\0';
            if (n % 2 == 1)
            {
                mid = s[n / 2];
            }

            int[] count = new int[26];

            for (int i = 0; i < n; i++)
            {
                if (n % 2 == 1 && i == n / 2)
                    continue;

                count[s[i] - 'a']++;
            }

            // Only half of each character is needed
            for (int i = 0; i < 26; i++)
            {
                count[i] /= 2;
            }

            StringBuilder halfResult = new StringBuilder();
            int half = n / 2;

            for (int i = 0; i < half; i++)
            {
                bool placedCharacter = false;

                for (int j = 0; j < 26; j++)
                {
                    if (count[j] > 0)
                    {
                        count[j]--;

                        long ways = 1;
                        int letters = 0;

                        for (int c = 0; c < 26; c++)
                        {
                            letters += count[c];
                        }

                        for (int c = 0; c < 26; c++)
                        {
                            if (count[c] > 0)
                            {
                                ways *= NCR(letters, count[c], k);
                                letters -= count[c];
                            }

                            if (ways >= k)
                                break;
                        }

                        if (ways >= k)
                        {
                            halfResult.Append((char)(j + 'a'));
                            placedCharacter = true;
                            break;
                        }

                        k -= (int)ways;
                        count[j]++;
                    }
                }

                if (!placedCharacter)
                    return "";
            }

            StringBuilder rev = new StringBuilder(halfResult.ToString());

            char[] arr = rev.ToString().ToCharArray();
            Array.Reverse(arr);
            rev = new StringBuilder(new string(arr));

            if (mid != '\0')
            {
                halfResult.Append(mid);
            }

            return halfResult.ToString() + rev.ToString();
        }

        private static long NCR(int n, int r, int k)
        {
            r = Math.Min(r, n - r);

            long result = 1;

            for (int i = 1; i <= r; i++)
            {
                result = result * (n - r + i) / i;

                if (result >= k)
                    return k;
            }

            return result;
        }
    }
}
