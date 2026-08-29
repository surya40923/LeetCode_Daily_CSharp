namespace Leet_2948
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            Console.Write("ENter Limit : ");int limit = int.Parse(Console.ReadLine());
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            int[] result = LexicographicallySmallestArray(nums, limit);
            Console.WriteLine("Output : ["+string.Join(",",result)+"]");
        }

        public static int[] LexicographicallySmallestArray(int[] nums, int limit)
        {
            int[] sortedNums = (int[])nums.Clone();
            Array.Sort(sortedNums);
            int currGroup = 0;
            Dictionary<int, int> numToGroup = new Dictionary<int, int>();
            numToGroup[sortedNums[0]] = currGroup;
            Dictionary<int, Queue<int>> groupToList = new Dictionary<int, Queue<int>>();
            groupToList[currGroup] = new Queue<int>();
            groupToList[currGroup].Enqueue(sortedNums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (Math.Abs(sortedNums[i] - sortedNums[i - 1]) > limit)
                {
                    currGroup++;
                }
                numToGroup[sortedNums[i]] = currGroup;
                if (!groupToList.ContainsKey(currGroup))
                {
                    groupToList[currGroup] = new Queue<int>();
                }
                groupToList[currGroup].Enqueue(sortedNums[i]);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                int group = numToGroup[num];
                nums[i] = groupToList[group].Dequeue();
            }
            return nums;
        }
    }
}
