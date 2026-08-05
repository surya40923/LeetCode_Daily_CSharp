namespace Leet_3310
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");int n = int.Parse(Console.ReadLine());
            Console.Write("Enter k : ");int k = int.Parse(Console.ReadLine());
            Console.Write("Enter Array : ");string input = Console.ReadLine();

            //Display Test
            int[][] arr = Parse2DArray(input);
            foreach (int[] row in arr)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }

            //Display Output
            int[][] output = Parse2DArray(input);
            IList<int> result = RemainingMethods(n, k, arr);
            Console.WriteLine("Output: [" + string.Join(", ", result) + "]");
        }

        public static int[][] Parse2DArray(string input)
        {
            input = input.Replace(" ", "");
            input = input.Trim();

            input = input.Substring(2, input.Length - 4);

            string[] row = input.Split("],[");
            int[][] result = new int[row.Length][];

            for (int i = 0; i < row.Length; i++)
            {
                result[i] = row[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }

            return result;
        }

        public static IList<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            List<List<int>> edges = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                edges.Add(new List<int>());
            }

            int[] inDegree = new int[n];

            foreach (int[] inv in invocations)
            {
                edges[inv[0]].Add(inv[1]);
                inDegree[inv[1]]++;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(k);

            bool[] suspicious = new bool[n];
            suspicious[k] = true;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();

                foreach (int v in edges[u])
                {
                    inDegree[v]--;

                    if (!suspicious[v])
                    {
                        suspicious[v] = true;
                        queue.Enqueue(v);
                    }
                }
            }

            bool canRemoveAll = true;

            for (int i = 0; i < n; i++)
            {
                if (suspicious[i] && inDegree[i] > 0)
                {
                    canRemoveAll = false;
                    break;
                }
            }

            IList<int> result = new List<int>();

            if (canRemoveAll)
            {
                for (int i = 0; i < n; i++)
                {
                    if (!suspicious[i])
                        result.Add(i);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
