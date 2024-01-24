namespace _11.ShortesPath
{
    internal class Program
    {
        const int INF = 99999;
        static void Main(string[] args)
        {
            int[,] graph = new int[9, 9]
            {
                {   0, INF,   1,   7, INF, INF, INF,   5, INF},
                { INF,   0, INF, INF, INF,   4, INF, INF, INF},
                { INF, INF,   0, INF, INF, INF, INF, INF, INF},
                {   5, INF, INF,   0, INF, INF, INF, INF, INF},
                { INF, INF,   9, INF,   0, INF, INF, INF,   2},
                {   1, INF, INF, INF, INF,   0, INF,   6, INF},
                { INF, INF, INF, INF, INF, INF,   0, INF, INF},
                {   1, INF, INF, INF,   4, INF, INF,   0, INF},
                { INF,   5, INF,   2, INF, INF, INF, INF,   0}
            };

            Dijkstra.ShortestPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);

            PrintDijkstra(distance, parents);
        }

        private static void PrintDijkstra(int[] distance, int[] parents)
        {
            Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Path",8}");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write($"{i,8}");

                if (distance[i] >= INF)
                {
                    Console.Write($"{"INF",8}");
                }
                else
                {
                    Console.Write($"{distance[i],8}");
                }

                if (parents[i] < 0)
                    Console.WriteLine($"{"X",8}");
                else
                    Console.WriteLine($"{parents[i],8}");
            }
        }
    }
}
