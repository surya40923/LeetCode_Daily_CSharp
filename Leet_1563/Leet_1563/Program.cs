namespace Leet_1563
{
    internal class Program
    {
        public static int[][] memo;
        static void Main(string[] args)
        {
            Console.Write("Enter Stones : ");string stone = Console.ReadLine();
            int[] nums = stone.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            int result = StoneGameV(nums);
            Console.WriteLine("Output: " + result);
        }

        public static int StoneGameV(int[] stoneValue)
        {
            int n = stoneValue.Length;
            memo = new int[n][];
            for (int i = 0; i < n; i++)
            {
                memo[i] = new int[n];
            }
            int[] prefixSum = new int[n + 1];
            for(int i = 0; i < n;i++) prefixSum[i + 1] = prefixSum[i] + stoneValue[i];
            return dfs(stoneValue,0,n - 1,prefixSum);
        }

        public static int dfs(int[] stoneValue,int left,int right, int[] prefixSum)
        {
            if(left == right) return 0;
            if (memo[left][right] != 0) return memo[left][right];
            int ans = 0;
            for(int i = left;i < right;i++)
            {
                int leftSum = prefixSum[i + 1] - prefixSum[left];
                int rightSum = prefixSum[right + 1] - prefixSum[i + 1];
                if (leftSum < rightSum) ans = Math.Max(ans, leftSum + dfs(stoneValue, left, i, prefixSum));
                else if (leftSum > rightSum) ans = Math.Max(ans, rightSum + dfs(stoneValue, i + 1, right, prefixSum));
                else ans = Math.Max(ans,leftSum + Math.Max(dfs(stoneValue,left,i,prefixSum),dfs(stoneValue,i + 1, right, prefixSum)));
            }
            return memo[left][right] = ans;
        }
    }
}
