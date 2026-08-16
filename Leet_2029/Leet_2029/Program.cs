namespace Leet_2029
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Stones : ");string stones = Console.ReadLine();
            int[] nums = stones.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            Console.Write("Output : " + StoneGameIX(nums));
        }

        public static bool StoneGameIX(int[] stones)
        {
            int cnt0 = 0;int cnt1 = 0;int cnt2 = 0;
            foreach(int value in stones)
            {
                int typ = value % 3;
                if (typ == 0) cnt0++;
                else if(typ == 1) cnt1++;
                else cnt2++;
            }

            if(cnt0 % 2 == 0)
            {
                return cnt1 >= 1 && cnt2 >= 1;
            }
            return cnt1 - cnt2 > 2 || cnt2 - cnt1 > 2;
        }
    }
}
