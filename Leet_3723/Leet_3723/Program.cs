using System.Security.AccessControl;
using System.Text;

namespace Leet_3723
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num : "); int num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter sum : "); int sum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Output : "+MaxSumOfSquares(num,sum));
        }

        public static string MaxSumOfSquares(int num, int sum)
        {
            if (sum > 9 * num) return "";
            int q = sum / 9;
            int r = sum % 9;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < q; i++)
            {
                sb.Append("9");
            }
            if (r > 0) sb.Append(r);
            while(sb.Length < num) sb.Append("0");
            return sb.ToString();
        }
    }
}
