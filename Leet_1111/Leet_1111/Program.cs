namespace Leet_1111
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");
            string seq = Console.ReadLine();
            int[] res = MaxDepthAfterSplit(seq);
            Console.WriteLine("Output : ["+string.Join(",",res)+"]");
        }

        public static int[] MaxDepthAfterSplit(string seq)
        {
            int[] ans = new int[seq.Length];
            for (int i = 0; i < seq.Length; i++)
            {
                if (seq[i] == '(') ans[i] = i % 2;
                else ans[i] = 1 - i % 2;
            }
            return ans;
        }
    }
}
