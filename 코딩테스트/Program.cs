using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace 코딩테스트
{
    internal class Program
    {

        public static void ShortestPath(in int[,] graph, in int start, out bool[] visited, out int[] distance, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            distance = new int[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                distance[i] = INF;
                parents[i] = -1;
                visited[i] = false;
            }
            distance[start] = 0;

            for (int i = 0; i < size; i++)
            {
                int next = -1;
                int minDistance = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&
                        distance[j] < minDistance)
                    {
                        next = j;
                        minDistance = distance[j];
                    }
                }
                if (next < 0)
                    break;

                for (int j = 0; j < size; j++)
                {
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        parents[j] = next;
                    }
                }

                visited[next] = true;
            }
        }



        const int INF = 20;
        public static void Main(string[] args)
        {
            int[,] graph =
            {
                { 0,    6,    6, INF, INF, INF, INF,   7, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
                { 6,   0, INF, INF, INF,     9, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
                { 6, INF,    0,    7, INF, INF,   8, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF },
                { INF, INF,   7,   0, INF, INF,   8, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   3 },
                { INF, INF, INF, INF,   0,   2, INF,   7,   8, INF, INF, INF, INF, INF, INF, INF, INF, INF },
                { INF,   9, INF, INF,   2,   0,   1, INF, INF,   2, INF, INF, INF, INF, INF, INF, INF, INF },
                { INF, INF,   8,   8, INF,   1,   0, INF, INF,   2,   8, INF, INF, INF, INF, INF, INF, INF },
                { 7, INF, INF, INF,    7, INF, INF,    0,   4, INF, INF,   5, INF, INF,   5, INF, INF, INF },
                { INF, INF, INF, INF,   8, INF, INF,   4,   0,   3, INF, INF,   4, INF, INF, INF, INF, INF },
                { INF, INF, INF, INF, INF,   2,   2, INF,   3,   0,   5, INF,   1, INF, INF, INF, INF, INF },
                { INF, INF, INF, INF, INF, INF,   8, INF, INF,   5,   0, INF, INF, INF, INF, INF, INF,   7 },
                { INF, INF, INF, INF, INF, INF, INF,   5, INF, INF, INF,   0, INF, INF,   3, INF, INF, INF },
                { INF, INF, INF, INF, INF, INF, INF, INF,   4,   1, INF, INF,   0, INF, INF,   4,   7, INF },
                { INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   0, INF, INF,   1, INF },
                { INF, INF, INF, INF, INF, INF, INF,   5, INF, INF, INF,   3, INF, INF,   0,   2, INF, INF },
                { INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   4, INF,   2,   0,   3,   6 },
                { INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF, INF,   7,   1, INF,   3,   0, INF },
                { INF, INF, INF,   3, INF, INF, INF, INF, INF, INF,   7, INF, INF, INF, INF,   6, INF,   0 }
            };

            ShortestPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);

            PrintDijkstra(distance, parents);

            static void PrintDijkstra(int[] distance, int[] parents)
            {
                Console.WriteLine($"{"Vertex",8}{"Visited",8}{"Parent",8}");

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
                        Console.WriteLine($"{"-1",8}");
                    else
                        Console.WriteLine($"{parents[i],8}");
                }
            }
        }
    }
}
