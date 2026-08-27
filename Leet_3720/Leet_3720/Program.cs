using System.Text;

namespace Leet_3720
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter s : ");string s = Console.ReadLine();
            Console.Write("Enter target : ");string target = Console.ReadLine();
            Console.WriteLine("Output : "+LexGreaterPermutation(s,target));
        }

        public static string LexGreaterPermutation(string s, string target)
        {
            int[] cnt = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                cnt[s[i] - 'a']++;
                cnt[target[i] - 'a']--;
            }

            char[] t = target.ToCharArray();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                int b = t[i] - 'a';
                cnt[b]++;

                bool possible = true;

                foreach (int c in cnt)
                {
                    if (c < 0)
                        possible = false;
                }

                if (!possible)
                    continue;

                for (int j = b + 1; j < 26; j++)
                {
                    if (cnt[j] > 0)
                    {
                        cnt[j]--;

                        t[i] = (char)('a' + j);

                        StringBuilder sb = new StringBuilder();

                        sb.Append(t, 0, i + 1);

                        for (int k = 0; k < 26; k++)
                        {
                            while (cnt[k] > 0)
                            {
                                sb.Append((char)('a' + k));
                                cnt[k]--;
                            }
                        }

                        return sb.ToString();
                    }
                }
            }

            return "";
        }
    }
}
