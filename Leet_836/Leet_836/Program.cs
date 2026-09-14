namespace Leet_836
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter rec1 : "); string rec1 = Console.ReadLine();
            Console.Write("Enter rec2 : "); string rec2 = Console.ReadLine();
            int[] num1 = rec1.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
            int[] num2 = rec2.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+IsRectangleOverlap(num1,num2));
        }

        public static bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            if (rec1[0] == rec1[2] || rec1[1] == rec1[3] || rec2[0] == rec2[2] || rec2[1] == rec2[3])
            {  return false; }
            return !(rec1[2] <= rec2[0] ||
                rec1[3] <= rec2[1] || rec1[0] >= rec2[2]
                || rec1[1] >= rec2[3]);
        }
    }
}
