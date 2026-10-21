namespace Leet_3863
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : ");string s = Console.ReadLine();
            Console.WriteLine("Output : "+MinOperations(s));
        }

        public static int MinOperations(string s)
        {
            int n = s.Length;
            char[] arr = s.ToCharArray();
            bool sorted = true;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    sorted = false;
                    break;
                }
            }
            if (sorted) return 0;            
            if (n == 2) return -1;
            char minChar = arr[0];
            char maxChar = arr[0];
            for (int i = 1; i < n; i++)
            {
                minChar = (char)Math.Min(minChar, arr[i]);
                maxChar = (char)Math.Max(maxChar, arr[i]);
            }
            if (arr[0] == minChar || arr[n - 1] == maxChar) return 1;
            char minMid = arr[1];
            char maxMid = arr[1];
            for (int i = 2; i < n - 1; i++)
            {
                minMid = (char)Math.Min(minMid, arr[i]);
                maxMid = (char)Math.Max(maxMid, arr[i]);
            }
            if (arr[0] > maxMid && arr[n - 1] < minMid) return 3;  
            return 2;
        }
    }
}
