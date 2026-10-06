namespace Leet_921
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter String : "); string s = Console.ReadLine();
            Console.WriteLine("Output : " + MinAddToMakeValid(s));
        }

        public static int MinAddToMakeValid(string s)
        {
            int openbrackets = 0;
            int validbrackets = 0;

            foreach (char c in s)
            {
                if (c == '(') openbrackets++;
                else
                {
                    if (openbrackets > 0) openbrackets--;
                    else validbrackets++;
                }
            }

            return openbrackets + validbrackets;
        }
    }
}
