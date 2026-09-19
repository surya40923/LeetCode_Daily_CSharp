namespace Leet_1401
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter radius : ");int radius = int.Parse(Console.ReadLine());
            Console.Write("Enter xCenter : ");int xCenter = int.Parse(Console.ReadLine());
            Console.Write("Enter yCenter : ");int yCenter = int.Parse(Console.ReadLine());
            Console.Write("Enter x1 : ");int x1 = int.Parse(Console.ReadLine());
            Console.Write("Enter y1 : ");int y1 = int.Parse(Console.ReadLine());
            Console.Write("Enter x2 : ");int x2 = int.Parse(Console.ReadLine());
            Console.Write("Enter y2 : ");int y2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Output : "+CheckOverlap(radius,xCenter,yCenter,x1,y1,x2,y2));

        }

        public static bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
        {
            double distance = 0;
            if(xCenter < x1 || xCenter > x2)
            {
                distance += Math.Min(Math.Pow(x1 - xCenter, 2), Math.Pow(x2 - xCenter, 2));
            }
            if(yCenter < y1 || yCenter > y2)
            {
                distance += Math.Min(Math.Pow(y1 - yCenter, 2), Math.Pow(y2 - yCenter, 2));
            }
            return distance <= radius * radius;
        }
    }
}
