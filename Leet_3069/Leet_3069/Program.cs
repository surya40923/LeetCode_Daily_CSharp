using System.Data;

namespace Leet_3069
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            int[] output = ResultArray(nums);
            Console.WriteLine("Output : [" + string.Join(",",output) + "]");
        }

        public static int[] ResultArray(int[] nums)
        {
            List<int> arr1 = new List<int>();
            List<int> arr2 = new List<int>();
            arr1.Add(nums[0]);
            arr2.Add(nums[1]);
            for(int i = 2; i < nums.Length;i++)
            {
                if (arr1[arr1.Count - 1] > arr2[arr2.Count - 1]) arr1.Add(nums[i]);
                else arr2.Add(nums[i]);
            }
            int[] result = new int[nums.Length];
            int idx = 0;
            foreach(int num in arr1) result[idx++] = num;
            foreach(int num in arr2) result[idx++] = num;
            return result;
        }
    }
}
