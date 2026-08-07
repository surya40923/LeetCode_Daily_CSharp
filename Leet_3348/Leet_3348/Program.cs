using System.Text;

namespace Leet_3348
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter num : ");string num = Console.ReadLine();
            Console.Write("Enter t : ");int t = int.Parse(Console.ReadLine());
            Console.Write("Output : "+SmallestNumber(num,t));
        }

        public static string SmallestNumber(string num, long t)
        {
            long temp = t;

            for (int i = 2; i <= 9; i++)
            {
                while (temp % i == 0)
                    temp /= i;
            }

            if (temp > 1)
                return "-1";

            int n = num.Length;
            long[] rem = new long[n + 1];
            rem[0] = t;

            int pos = n - 1;
            char[] numArr = num.ToCharArray();

            for (int i = 0; i < n; i++)
            {
                if (numArr[i] == '0')
                {
                    pos = i;
                    break;
                }

                rem[i + 1] = rem[i] / Gcd(rem[i], numArr[i] - '0');
            }

            if (rem[n] == 1 && pos == n - 1 && numArr[pos] != '0')
                return num;

            for (int i = pos; i >= 0; i--)
            {
                int startDigit = (i < n) ? (numArr[i] - '0') + 1 : 1;

                for (int d = startDigit; d <= 9; d++)
                {
                    long tNow = rem[i] / Gcd(rem[i], d);

                    StringBuilder suffix = new StringBuilder();
                    long currT = tNow;

                    for (int j = n - 1; j > i; j--)
                    {
                        for (int v = 9; v >= 1; v--)
                        {
                            if (currT % v == 0)
                            {
                                suffix.Append(v);
                                currT /= v;
                                break;
                            }
                        }
                    }

                    if (currT == 1)
                    {
                        StringBuilder ans = new StringBuilder();

                        for (int k = 0; k < i; k++)
                            ans.Append(numArr[k]);

                        ans.Append(d);
                        ans.Append(ReverseString(suffix.ToString()));

                        return ans.ToString();
                    }
                }
            }

            long curr = t;
            List<int> digits = new List<int>();

            for (int v = 9; v >= 2; v--)
            {
                while (curr % v == 0)
                {
                    digits.Add(v);
                    curr /= v;
                }
            }

            digits.Sort();

            int reqLen = Math.Max(n + 1, digits.Count);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < reqLen - digits.Count; i++)
                result.Append('1');

            foreach (int d in digits)
                result.Append(d);

            return result.ToString();
        }

        private static long Gcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = a % b;
                a = b;
                b = temp;
            }

            return a;
        }

        private static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
