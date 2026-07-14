using System.ComponentModel;

namespace Leet_1291
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Low : ");int low = int.Parse(Console.ReadLine());
            Console.Write("Enter High : ");int high = int.Parse(Console.ReadLine());
            IList<int> result = SequentialDigits(low, high);
            Console.WriteLine("Output:");
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        public static IList<int> SequentialDigits(int low,int high)
        {
            string sample = "123456789";
            IList<int> nums = new List<int>();

            for (int length = 2; length <= 9; length++)
            {
                for (int i = 0; i <= 9 - length; i++)
                {
                    string substring = sample.Substring(i, length);
                    int num = int.Parse(substring);

                    if (num >= low && num <= high)
                    {
                        nums.Add(num);
                    }
                }
            }

            return nums;
        }
    }
}
