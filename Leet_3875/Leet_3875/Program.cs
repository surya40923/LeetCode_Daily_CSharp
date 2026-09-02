namespace Leet_3875
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.WriteLine("Output : "+UniformArray(nums));
        }

        public static bool UniformArray(int[] nums1)
        {
            return true;
        }

        /* 
         * Why true? Lets take an array [2,4,7]
         * 2 -> even
         * 4 -> even
         * 7 -> odd 
         * Can we make num[2] , which is 7 as even with the elements present
         * inside the array, Our condition is....
         * 
         * For each index i, you must choose exactly one of the following (in any order):
         * nums2[i] = nums1[i]
         * nums2[i] = nums1[i] - nums1[j], for an index j != i
         * 
         * So 7 - 2 -> 5 is odd and 7 - 4 -> odd which can be turned to odd but the
         * other elements can be made to odd..
         * 
         * 2 - 7 = -5 -> odd
         * 4 - 7 = -3 -> odd
         * 7 - 2 = 5 -> odd
         * 
         * we have equal parity of all nums the new array [-5,-3,5]
         * 
         * For every case whether to make it odd or even it can be done and the
         * parity always exists so the condition always passes to true
         * 
         * So , the program function always returns True.......
         * 
         */
    }
}
