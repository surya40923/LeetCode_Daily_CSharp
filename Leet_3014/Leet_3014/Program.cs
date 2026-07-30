namespace Leet_3014
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter word : ");string word = Console.ReadLine();
            Console.Write("Output : "+MinimumPushes(word));
        }

        public static int MinimumPushes(string word)
        {
            int total = 0;
            for(int i = 0;i < word.Length;i++)
            {
                total += (i / 8) + 1;
            }
            return total;
        }
    }
}
