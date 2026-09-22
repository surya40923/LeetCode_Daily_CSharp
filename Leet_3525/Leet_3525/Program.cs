namespace Leet_3525
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Nums : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter K : ");int k = int.Parse(Console.ReadLine());
            Console.Write("Enter Queries : ");string query = Console.ReadLine();
            int[][] queries = query.Trim('[',']').Split("],[")
                .Select(row => row.Trim('[',']').Split(",").Select(int.Parse).ToArray())
                .ToArray();

            //2D array checker 
            /*foreach (int[] row in queries)
            {
                Console.WriteLine(string.Join(" ",row));
            }*/

            int[] res = ResultArray(nums, k, queries);
            Console.WriteLine("Output : ["+string.Join(",",res)+"]");
        }

        class Node
        {
            public int[] cnt = new int[5];
            public int prod = 0;
        }

        class SegmentTree
        {
            private int n, k;
            private Node[] segTree;

            public SegmentTree(int[] nums,int k)
            {
                this.k = k;
                this.n = nums.Length;
                segTree = new Node[4 * n];
                for (int i = 0; i < 4 * n; i++)
                {
                    segTree[i] = new Node();
                }
                Build(0, 0, n - 1, nums);
            }

            private void Build(int i, int l, int r, int[] nums)
            {
                if (l == r)
                {
                    LeafNode(i, nums[l]);
                    return;
                }

                int mid = l + (r - l) / 2;

                Build(2 * i + 1, l, mid, nums);
                Build(2 * i + 2, mid + 1, r, nums);

                segTree[i] = MergeNodes(segTree[2 * i + 1],segTree[2 * i + 2]);
            }

            private void LeafNode(int i, int value)
            {
                for (int x = 0; x < k; x++)
                {
                    segTree[i].cnt[x] = 0;
                }

                int r = value % k;

                segTree[i].cnt[r] = 1;
                segTree[i].prod = r;
            }

            private Node MergeNodes(Node left, Node right)
            {
                Node result = new Node();

                result.prod = (left.prod * right.prod) % k;

                for (int x = 0; x < k; x++)
                {
                    result.cnt[x] = left.cnt[x];
                }

                for (int x = 0; x < k; x++)
                {
                    int newRem = (left.prod * x) % k;
                    result.cnt[newRem] += right.cnt[x];
                }

                return result;
            }

            private void SegTreeUpdate(int i,int l,int r,int index,int value)
            {
                if (l == r)
                {
                    LeafNode(i, value);
                    return;
                }
                int mid = l + (r - l) / 2;
                if (index <= mid)
                {
                    SegTreeUpdate(2 * i + 1,l,mid,index,value);
                }
                else
                {
                    SegTreeUpdate(2 * i + 2,mid + 1,r,index,value);
                }
                segTree[i] = MergeNodes(segTree[2 * i + 1],segTree[2 * i + 2]);
            }

            public void Update(int index, int value)
            {
                SegTreeUpdate(0,0,n - 1,index,value);
            }

            private Node SegTreeQuery(int start,int end,int i,int l,int r)
            {
                if (l >= start && r <= end)
                {
                    return segTree[i];
                }

                int mid = l + (r - l) / 2;

                if (end <= mid)
                {
                    return SegTreeQuery(start,end,2 * i + 1,l,mid);
                }

                if (start > mid)
                {
                    return SegTreeQuery(start,end,2 * i + 2,mid + 1,r);
                }

                Node left = SegTreeQuery(start,end,2 * i + 1,l,mid);
                Node right = SegTreeQuery(start,end,2 * i + 2,mid + 1,r);

                return MergeNodes(left, right);
            }

            public Node Query(int start, int end)
            {
                return SegTreeQuery(start,end,0,0,n - 1);
            }
        }

        public static int[] ResultArray(int[] nums, int k, int[][] queries)
        {
            int n = nums.Length;

            SegmentTree segTree = new SegmentTree(nums, k);

            int[] result = new int[queries.Length];

            for (int idx = 0; idx < queries.Length; idx++)
            {
                int index = queries[idx][0];
                int value = queries[idx][1];
                int start = queries[idx][2];
                int x = queries[idx][3];

                segTree.Update(index, value);

                Node node = segTree.Query(start, n - 1);

                result[idx] = node.cnt[x];
            }

            return result;
        }
    }
}
