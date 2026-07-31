namespace Leet_3016
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");string s = Console.ReadLine();
            Console.Write("Output : "+MinimumPushes(s));
        }

        public static int MinimumPushes(string word)
        {
            int[] freq = new int[26];
            foreach(char c in word)
            {
                freq[c - 'a']++;
            }
            Array.Sort(freq);
            int push = 0;
            for(int i = 25;i >= 0;i--)
            {
                if (freq[i] == 0)
                {
                    break;
                }
                push += ((25 - i) / 8 + 1) * freq[i];
            }
            return push;
        }
    }
}
