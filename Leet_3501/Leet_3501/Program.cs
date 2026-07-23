namespace Leet_3501
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string s = Console.ReadLine();

            Console.Write("Enter queries: ");
            string input = Console.ReadLine();

            int[][] queries = Parse2DArray(input);

            IList<int> result = MaxActiveSectionsAfterTrade(s, queries);

            Console.WriteLine("\nOutput:");
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        public static int[][] Parse2DArray(string input)
        {
            input = input.Replace(" ", "");
            input = input.Trim();

            // Remove outer [[ ]]
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

        private static void BuildSegmentTree(int i, int l, int r, int[] segmentTree, int[] arr)
        {
            if (l == r)
            {
                segmentTree[i] = arr[l];
                return;
            }

            int mid = l + (r - l) / 2;

            BuildSegmentTree(2 * i + 1, l, mid, segmentTree, arr);
            BuildSegmentTree(2 * i + 2, mid + 1, r, segmentTree, arr);

            segmentTree[i] = Math.Max(segmentTree[2 * i + 1], segmentTree[2 * i + 2]);
        }

        private static int[] ConstructST(int[] arr, int n)
        {
            int[] segmentTree = new int[4 * n];
            BuildSegmentTree(0, 0, n - 1, segmentTree, arr);
            return segmentTree;
        }

        private static int QuerySegmentTree(int start, int end, int i, int l, int r, int[] segmentTree)
        {
            if (l > end || r < start)
                return int.MinValue;

            if (l >= start && r <= end)
                return segmentTree[i];

            int mid = l + (r - l) / 2;

            return Math.Max(
                QuerySegmentTree(start, end, 2 * i + 1, l, mid, segmentTree),
                QuerySegmentTree(start, end, 2 * i + 2, mid + 1, r, segmentTree)
            );
        }

        private static int RMQ(int[] st, int n, int a, int b)
        {
            return QuerySegmentTree(a, b, 0, 0, n - 1, st);
        }

        private static int LowerBound(int[] arr, int len, int key)
        {
            int lo = 0;
            int hi = len;

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] < key)
                    lo = mid + 1;
                else
                    hi = mid;
            }

            return lo;
        }

        private static int UpperBound(int[] arr, int len, int key)
        {
            int lo = 0;
            int hi = len;

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] <= key)
                    lo = mid + 1;
                else
                    hi = mid;
            }

            return lo;
        }

        public static IList<int> MaxActiveSectionsAfterTrade(string s, int[][] queries)
        {
            int n = s.Length;

            int activeCount = 0;
            foreach (char ch in s)
            {
                if (ch == '1')
                    activeCount++;
            }

            int[] blockStart = new int[n];
            int[] blockEnd = new int[n];

            int m = 0;
            int i = 0;

            while (i < n)
            {
                if (s[i] == '0')
                {
                    int start = i;

                    while (i < n && s[i] == '0')
                        i++;

                    blockStart[m] = start;
                    blockEnd[m] = i - 1;
                    m++;
                }
                else
                {
                    i++;
                }
            }

            if (m < 2)
            {
                List<int> ans = new List<int>();

                for (int k = 0; k < queries.Length; k++)
                    ans.Add(activeCount);

                return ans;
            }

            int[] blockSize = new int[m];

            for (int k = 0; k < m; k++)
                blockSize[k] = blockEnd[k] - blockStart[k] + 1;

            int pairCount = m - 1;

            int[] pairSum = new int[pairCount];

            for (int k = 0; k < pairCount; k++)
                pairSum[k] = blockSize[k] + blockSize[k + 1];

            int[] st = ConstructST(pairSum, pairCount);

            List<int> result = new List<int>();

            foreach (int[] q in queries)
            {
                int l = q[0];
                int r = q[1];

                int low = LowerBound(blockEnd, m, l);
                int high = UpperBound(blockStart, m, r) - 1;

                int maxPairSum = 0;

                if (low < high)
                {
                    int firstLen = blockEnd[low] - Math.Max(blockStart[low], l) + 1;
                    int lastLen = Math.Min(blockEnd[high], r) - blockStart[high] + 1;

                    if (high - low == 1)
                    {
                        maxPairSum = firstLen + lastLen;
                    }
                    else
                    {
                        int pair1 = firstLen + blockSize[low + 1];
                        int pair2 = blockSize[high - 1] + lastLen;

                        int rmqMaxPair =
                            (low + 1 <= high - 2)
                            ? RMQ(st, pairCount, low + 1, high - 2)
                            : 0;

                        maxPairSum = Math.Max(pair1, Math.Max(pair2, rmqMaxPair));
                    }
                }

                result.Add(activeCount + maxPairSum);
            }

            return result;
        }

    }
}
