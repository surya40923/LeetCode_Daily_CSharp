namespace Leet_2265
{
    internal class Program
    {
        public static int count = 0;
        static void Main(string[] args)
        {
            Console.Write("Enter root : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+AverageOfSubtree(nums));
        }

        public static int AverageOfSubtree(TreeNode root)
        {
            postOrder(root);
            return count;
        }

        public static int[] postOrder(TreeNode root)
        {
            if(root == null)
            {
                return new int[] { 0, 0 };
            }

            int[] left = postOrder(root.left);
            int[] right = postOrder(root.right);

            int nodeSum = left[0] + right[0] + root.val;
            int nodeCount = left[1] + right[1] + 1;

            if(root.val == nodeSum / nodeCount)
            {
                count++;
            }

            return new int[] { nodeSum, nodeCount };
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
