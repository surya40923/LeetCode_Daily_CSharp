namespace _0001_Palindrome_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number As 121 or -121");
            Console.Write("Enter Number : ");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(IsPalindrome(input));
        }

        //Method 1 : Mathematical
        static bool IsPalindrome(int num)
        {
            if (num < 0 || (num % 10 == 0 && num != 0)) return false;
            int reversedHalf = 0;
            while(num > reversedHalf)
            {
                reversedHalf = reversedHalf * 10 + num % 10;
                num = num / 10;
            }
            return num == reversedHalf || num == reversedHalf / 10;
        }
        

        //Method 2 : String Reverse
        /*
        static bool IsPalindrome(int num)
        {
            string s = num.ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);
            return s == reversed;
        }
        */
    }
}
