using Microsoft.Win32.SafeHandles;
using System.Text;

namespace Leet_1081
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");
            string input = Console.ReadLine();
            Console.WriteLine("Output : "+smallestSubsequence(input));
        }

        public static string smallestSubsequence(string s)
        {
            int[] vis = new int[26];
            int[] num = new int[26];

            // Count the frequency of each character
            foreach (char ch in s)
            {
                num[ch - 'a']++;
            }

            StringBuilder stk = new StringBuilder();

            foreach (char ch in s)
            {
                int idx = ch - 'a';

                if (vis[idx] == 0)
                {
                    while (stk.Length > 0 && stk[stk.Length - 1] > ch)
                    {
                        int topIdx = stk[stk.Length - 1] - 'a';

                        if (num[topIdx] > 0)
                        {
                            vis[topIdx] = 0;
                            stk.Remove(stk.Length - 1, 1);
                        }
                        else
                        {
                            break;
                        }
                    }

                    vis[idx] = 1;
                    stk.Append(ch);
                }

                num[idx]--;
            }

            return stk.ToString();
        }
    }
}
