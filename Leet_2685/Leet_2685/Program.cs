namespace Leet_2685
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter egdes : ");
            string input = Console.ReadLine();
            int[][] edges = Parse2DArray(input);

            //Output
            int ans = CountCompleteComponents(n, edges);
            Console.Write("Output : " + ans);
            
        }

        static int[][] Parse2DArray(string input)
        {
            input = input.Trim();

            input = input.Substring(2, input.Length - 4);

            string[] rows = input.Split("],[");

            int[][] result = new int[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                result[i] = rows[i]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }

            return result;
        }

        public static int CountCompleteComponents(int n, int[][] edges)
        {
            List<int>[] graph = new List<int>[n];

            for (int i = 0; i < n; i++) graph[i] = new List<int>();

            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            bool[] visited = new bool[n];
            int completeCount = 0;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    int[] info = new int[2];

                    dfs(i, graph, visited, info);

                    if (info[1] == info[0] * (info[0] - 1))
                        completeCount++;
                }
            }
            return completeCount;
        }

        public static void dfs(int curr, List<int>[] graph, bool[] visited, int[] info)
        {
            visited[curr] = true;

            info[0]++;
            info[1] += graph[curr].Count;

            foreach (int next in graph[curr])
            {
                if (!visited[next])
                    dfs(next, graph, visited, info);
            }
        }
    }
}
