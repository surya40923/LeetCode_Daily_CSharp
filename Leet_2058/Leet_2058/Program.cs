using System.Globalization;

namespace Leet_2058
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array : ");string arr = Console.ReadLine();
            int[] nums = arr.Trim('[',']').Split(',').Select(int.Parse).ToArray();
            ListNode head = BuildLinkedList(nums);
            int[] result = NodesBetweenCriticalPoints(head);
            Console.WriteLine("Output : ["+string.Join(",",result)+"]");
        }

        public static ListNode BuildLinkedList(int[] nums)
        {
            if (nums.Length == 0)
                return null;

            ListNode head = new ListNode(nums[0]);
            ListNode current = head;

            for (int i = 1; i < nums.Length; i++)
            {
                current.next = new ListNode(nums[i]);
                current = current.next;
            }

            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public static int[] NodesBetweenCriticalPoints(ListNode head)
        {
            int[] result = { -1, -1 };
            int minDistance = int.MaxValue;

            ListNode prev = head;
            ListNode curr = head.next;

            int currentIndex = 1;
            int previousCriticalIndex = 0;
            int firstCriticalIndex = 0;

            while (curr.next != null)
            {
                if ((curr.val < prev.val && curr.val < curr.next.val) ||
                    (curr.val > prev.val && curr.val > curr.next.val))
                {
                    if (previousCriticalIndex == 0)
                    {
                        previousCriticalIndex = currentIndex;
                        firstCriticalIndex = currentIndex;
                    }
                    else
                    {
                        minDistance = Math.Min(
                            minDistance,
                            currentIndex - previousCriticalIndex
                        );

                        previousCriticalIndex = currentIndex;
                    }
                }

                currentIndex++;
                prev = curr;
                curr = curr.next;
            }

            if (minDistance != int.MaxValue)
            {
                result[0] = minDistance;
                result[1] = previousCriticalIndex - firstCriticalIndex;
            }

            return result;
        }
    }
}
