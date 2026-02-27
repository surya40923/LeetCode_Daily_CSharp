namespace _0005_LeetProblem_67
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a : ");
            string a = Console.ReadLine();
            Console.Write("Enter b : ");
            string b = Console.ReadLine();
            Console.WriteLine("Result : "+AddBinary(a,b));
        }

        static string AddBinary(string a,string b)
        {
            int i = a.Length - 1;
            int j = b.Length - 1;
            int c = 0;
            string res = "";
            
            while(i >= 0 || j >= 0 || c > 0)
            {
                int sum = c;
                if (i >= 0) sum += a[i--] - '0';
                if (j >= 0) sum += b[j--] - '0';

                res = (sum % 2) + res;  
                c = sum / 2;
            }

            return res;
        }
    }
}
