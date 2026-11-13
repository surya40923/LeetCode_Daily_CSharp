namespace Leet_3420
{
    internal class Program
    {
        public static long[] cumSum;
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter k : "); int k = int.Parse(Console.ReadLine());
            Console.Write("Output : " + CountNonDecreasingSubarrays(nums,k));
        }

        public static long RangeSum(int i, int j)
        {
            if (i > j)
                return 0;

            return cumSum[j] - (i > 0 ? cumSum[i - 1] : 0);
        }

        public static long CountNonDecreasingSubarrays(int[] nums, int k)
        {
            int n = nums.Length;

            cumSum = new long[n];
            cumSum[0] = nums[0];

            for (int i = 1; i < n; i++)
            {
                cumSum[i] = nums[i] + cumSum[i - 1];
            }

            // NGR[i] = index of next strictly greater element, or n if none
            int[] NGR = new int[n];
            Array.Fill(NGR, n);

            Stack<int> st = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                while (st.Count > 0 && nums[st.Peek()] < nums[i])
                {
                    NGR[st.Pop()] = i;
                }

                st.Push(i);
            }

            // Operations[i] = total operations to make [i...n-1] non-decreasing
            long[] Operations = new long[n + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                int m = NGR[i];

                // i to m-1 segment
                long segmentOprns =
                    ((long)nums[i] * (m - i)) - RangeSum(i, m - 1);

                Operations[i] = segmentOprns + Operations[m];
            }

            // Ready for Sliding Window Maximum
            LinkedList<int> deq = new LinkedList<int>();

            long result = 0;
            int left = 0;
            int j = 0;

            while (j < n)
            {
                // Maintain decreasing order - monotonic deque
                while (deq.Count > 0 && nums[deq.Last.Value] < nums[j])
                {
                    deq.RemoveLast();
                }

                deq.AddLast(j);

                // Shrink if required
                while (left <= j)
                {
                    int m = deq.First.Value;

                    // Cost of [left...j]
                    long oprnsCount =
                        (Operations[left] - Operations[m])
                        + ((long)nums[m] * (j - m + 1))
                        - RangeSum(m, j);

                    if (oprnsCount <= k)
                        break;

                    left++;

                    if (deq.First.Value < left)
                    {
                        deq.RemoveFirst();
                    }
                }

                result += (j - left + 1);
                j++;
            }

            return result;
        }
    }
}
