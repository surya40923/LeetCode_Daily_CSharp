namespace _0005_LeetProblem_3650
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter Array : ");
            string input = Console.ReadLine();
            int[][] arr = input.Trim('[', ']').Split("],[").Select(row => row.Trim('[',']').Split(",").Select(int.Parse).ToArray()).ToArray();
            foreach (var row in arr)
            {
                Console.WriteLine($"[{string.Join(",", row)}]");
            }
        }
    }
}
