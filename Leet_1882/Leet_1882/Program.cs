namespace Leet_1882
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Servers : ");string server = Console.ReadLine();
            int[] num1 = server.Trim('[',']').Split(",").Select(int.Parse).ToArray();
            Console.Write("Enter Tasks : "); string task = Console.ReadLine();
            int[] num2 = task.Trim('[', ']').Split(",").Select(int.Parse).ToArray();
            int[] res = AssignTasks(num1, num2);
            Console.WriteLine("Output : [" + string.Join(",",res) + "]");
        }

        public static int[] AssignTasks(int[] servers, int[] tasks)
        {
            int n = servers.Length;
            int m = tasks.Length;

            // Free servers: (weight, index)
            PriorityQueue<int[], (int, int)> freeServers =
                new PriorityQueue<int[], (int, int)>();

            // Busy servers: (finishTime, weight, index)
            PriorityQueue<long[], (long, long, long)> busyServers =
                new PriorityQueue<long[], (long, long, long)>();

            for (int i = 0; i < n; i++)
            {
                freeServers.Enqueue(
                    new int[] { servers[i], i },
                    (servers[i], i)
                );
            }

            int[] result = new int[m];

            for (int i = 0; i < m; i++)
            {
                // Busy Servers ---> Free Servers
                while (busyServers.Count > 0 &&
                       busyServers.Peek()[0] <= i)
                {
                    long[] cur = busyServers.Dequeue();

                    int weight = (int)cur[1];
                    int index = (int)cur[2];

                    freeServers.Enqueue(
                        new int[] { weight, index },
                        (weight, index)
                    );
                }

                if (freeServers.Count == 0)
                {
                    // Nobody free: wait for earliest finishing server
                    long[] cur = busyServers.Dequeue();

                    result[i] = (int)cur[2];

                    busyServers.Enqueue(
                        new long[] { cur[0] + tasks[i], cur[1], cur[2] },
                        (cur[0] + tasks[i], cur[1], cur[2])
                    );
                }
                else
                {
                    // Free server starts immediately
                    int[] cur = freeServers.Dequeue();

                    result[i] = cur[1];

                    long finishTime = (long)i + tasks[i];

                    busyServers.Enqueue(
                        new long[] { finishTime, cur[0], cur[1] },
                        (finishTime, cur[0], cur[1])
                    );
                }
            }

            return result;
        }
    }
}
