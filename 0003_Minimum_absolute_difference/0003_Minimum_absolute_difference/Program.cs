namespace _0003_Minimum_absolute_difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            input = input.Trim('[', ']').Replace(" ","");
            string[] parts = input.Split(',');
            int[] num = new int[parts.Length];
            for(int i = 0; i < parts.Length; i++)
            {
                num[i] = int.Parse(parts[i]);
            }
            var output = MinimumAbsDifference(num);
            foreach (var pair in output)
            {
                Console.Write($"[{pair[0]},{pair[1]}]");
            }
        }

        static IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            Array.Sort(arr);

            int minDiff = int.MaxValue;

            for (int i = 1; i < arr.Length; i++)
            {
                int diff = arr[i] - arr[i - 1];
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }

            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] == minDiff)
                {
                    result.Add(new List<int> { arr[i - 1], arr[i] });
                }
            }

            return result;
        }

    }
}
