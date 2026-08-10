namespace Leet_3302
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter word 1 : ");string word1 = Console.ReadLine();
            Console.Write("Enter word 2 : ");string word2 = Console.ReadLine();
            int[] result = ValidSequence(word1, word2);
            Console.WriteLine("Output: [" + string.Join(",", result) + "]");
        }

        public static int[] ValidSequence(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;

            int[] last = new int[m];

            int j = m - 1;

            for (int i = n - 1; i >= 0; i--)
            {
                if (j >= 0 && word1[i] == word2[j])
                {
                    last[j--] = i;
                }
            }

            int[] res = new int[m];

            int skip = 0, k = 0;
            j = 0;

            for (int i = 0; i < n && j < m; i++)
            {
                if (word1[i] == word2[j] ||
                    (skip == 0 && (j == m - 1 || i < last[j + 1])))
                {
                    if (word1[i] != word2[j])
                        skip++;

                    res[k++] = i;
                    j++;
                }
            }

            return j == m ? res : new int[0];
        }
    }
}
