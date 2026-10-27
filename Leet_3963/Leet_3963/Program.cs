using System.Net.Http.Headers;

namespace Leet_3963
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter m : ");int m = int.Parse(Console.ReadLine());
            Console.Write("Enter n : ");int n = int.Parse(Console.ReadLine());
            string[] res = CreateGrid(m, n);
            foreach(string s in res)
            {
                Console.WriteLine(s);
            }
        }

        public static string[] CreateGrid(int m, int n)
        {
            List<string> grid = new List<string>();
            grid.Add(new string('.', n));
            string row = new string('#', n - 1) + '.';
            for(int i = 1;i < m;i++)
            {
                grid.Add(row);
            }
            return grid.ToArray();
        }
    }
}
