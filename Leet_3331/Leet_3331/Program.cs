namespace Leet_3331
{
    internal class Program
    {
        public static Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        public static int[] resultSize;
        public static int[] last;
        static void Main(string[] args)
        {
            Console.Write("Enter array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter s : ");string s = Console.ReadLine();
            int[] res = FindSubtreeSizes(nums, s);
            Console.WriteLine("Output : [" + string.Join("",res) + "]");
        }

        public static void DFS(int currNode, string s, int[] parent)
        {
            int c = s[currNode] - 'a';

            int nearestAncestor = last[c];

            last[c] = currNode;

            if (adj.ContainsKey(currNode))
            {
                foreach (int child in adj[currNode])
                {
                    DFS(child, s, parent);
                }
            }

            last[c] = nearestAncestor;

            if (currNode != 0)
            {
                int newParent = parent[currNode];

                if (nearestAncestor != -1)
                    newParent = nearestAncestor;

                parent[currNode] = newParent;

                resultSize[newParent] += resultSize[currNode];
            }
        }

        public static int[] FindSubtreeSizes(int[] parent, string s)
        {
            int n = parent.Length;

            for (int i = 1; i < n; i++)
            {
                int u = parent[i];
                int v = i;

                if (!adj.ContainsKey(u))
                    adj[u] = new List<int>();

                adj[u].Add(v);
            }

            resultSize = new int[n];
            Array.Fill(resultSize, 1);

            last = new int[26];
            Array.Fill(last, -1);

            DFS(0, s, parent);

            return resultSize;
        }
    }
}
