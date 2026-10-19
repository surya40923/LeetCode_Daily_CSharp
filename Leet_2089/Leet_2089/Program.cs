using System.Net.Http.Headers;

namespace Leet_2089
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter target : ");int target = int.Parse(Console.ReadLine());
            IList<int> res = TargetIndices(nums, target);
            Console.WriteLine("Output : ["+string.Join(",",res)+"]");
        }

        public static IList<int> TargetIndices(int[] nums, int target)
        {
            Sort(nums);
            int count1 = 0;int count2 = 0;
            foreach(int num in nums)
            {
                if(num < target) count1++; 
                else if(num == target) count2++;
            }
            List<int> res = new List<int>();
            for (int i = 0; i < count2; i++)
            {
                res.Add(count1 + i);
            }
            return res;
        }

        public static void Sort(int[] nums)
        {
            int n = nums.Length;
            int left; int right; int temp;
            bool swap;
            for(int i = 0; i < n - 1;i++)
            {
                swap = false;
                for(int j = 0;j < n - i - 1;j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                        swap = true;
                    }
                }
                if (swap == false) break;
            }
        }
    }
}
