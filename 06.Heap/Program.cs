﻿namespace _06.Heap
{
    internal class Program
    {
        /*************************************************************************************
         * 힙 (Heap)
         * 
         * 부모 노드가 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
         * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
         *************************************************************************************/

        // <힙 구현>
        // 힙은 노드들이 트리의 왼쪽부터 채운 완전이진트리를 구조를 가지며
        // 부모 노드가 두 자식노드보다 우선순위가 높은 값을 위치시킴
        // 힙 상태를 만족하는 경우 가장 최상단 노드가 모든 노드 중 우선순위가 가장 높음
        //
        //               2
        //       ┌───────┴───────┐
        //       8               52
        //   ┌───┴───┐       ┌───┴───┐
        //   13      37      67      92
        // ┌─┴─┐   ┌─┘
        // 17  43  52


        // <힙 노드 삽입>
        // 1. 힙의 최고 깊이, 마지막에 새 노드를 추가
        //
        //               2
        //       ┌───────┴───────┐
        //       8               52
        //   ┌───┴───┐       ┌───┴───┐
        //   13      37      67      92
        // ┌─┴─┐   ┌─┴─┐
        // 17  43  52 (7)
        //
        // 2. 삽입한 노드와 부모 노드를 비교하여 우선순위가 더 높은 경우 교체
        //
        //               2                               2                               2
        //       ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐
        //       8               52              8               52             (7)              52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13      37      67      92      13     (7)      67      92      13      8       67      92
        // ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐
        // 17  43  52 (7)                  17  43  52  37                  17  43  52  37
        //
        // 3. 더이상 교체되지 않을때까지 과정을 반복
        //
        //               2                               2
        //       ┌───────┴───────┐               ┌───────┴───────┐
        //      (7)              52              7               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13      8       67      92      13      8       67      92
        // ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐
        // 17  43  52  37                  17  43  52  37


        // <힙 노드 삭제>
        // 1. 최상단의 노드와 마지막 노드를 교체한 뒤 마지막 노드를 삭제
        //
        //              (2)                             (37)                           (37)
        //       ┌───────┴───────┐               ┌───────┴───────┐              ┌───────┴───────┐
        //       7               52              7               52             7               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐  =>  ┌───┴───┐       ┌───┴───┐
        //   13      8       67      92      13      8       67      92     13      8       67      92
        // ┌─┴─┐   ┌─┴─┐                   ┌─┴─┐   ┌─┴─┐                  ┌─┴─┐   ┌─┘
        // 17  43  52 (37)                 17  43  52 (2)                 17  43  52
        //
        // 2. 교체된 노드와 두 자식 노드를 비교하여 우선순위가 더 높은 노드와 교체
        //
        //              (37)                             7                               7
        //       ┌───────┴───────┐               ┌───────┴───────┐               ┌───────┴───────┐
        //       7               52             (37)             52              8               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13      8       67      92      13      8       67      92      13     (37)     67      92
        // ┌─┴─┐   ┌─┘                     ┌─┴─┐   ┌─┘                     ┌─┴─┐   ┌─┘
        // 17  43  52                      17  43  52                      17  43  52
        //
        // 3. 더이상 교체되지 않을때까지 과정을 반복
        //
        //               7                               7
        //       ┌───────┴───────┐               ┌───────┴───────┐
        //       8               52              8               52
        //   ┌───┴───┐       ┌───┴───┐  =>   ┌───┴───┐       ┌───┴───┐
        //   13     (37)     67      92      13      37      67      92
        // ┌─┴─┐   ┌─┘                     ┌─┴─┐   ┌─┘
        // 17  43  52                      17  43  52


        // <힙 구현>
        // 힙의 완전이진트리 특징의 경우 배열을 통해서 구현하기 좋음
        // 노드의 위치를 배열에 순서대로 저장
        // 노드가 위치한 인덱스에 연산을 진행하여 노드 이동이 가능
        // 
        // 부모로 이동         : (index - 1) / 2
        // 왼쪽자식으로 이동   : 2 * index + 1
        // 오른쪽자식으로 이동 : 2 * index + 2
        //
        //        0
        //    ┌───┴───┐
        //    1       2       ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        //  ┌─┴─┐   ┌─┴─┐ =>  │0│1│2│3│4│5│6│7│8│9│
        //  3   4   5   6     └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        // ┌┴┐ ┌┘
        // 7 8 9

        // <우선순위 큐>
        // 연결리스트 구현 : 삽입 0(n), 삭제 0(1)
        // 힙 구현 : 삽입 0(logN), 삭제 0(logN)

        static void Main(string[] args)
        {
            // 응급실
            /*Queue<string> queue = new Queue<string>();
            queue.Enqueue("환자1 - 감기");
            queue.Enqueue("환자2 - 타박상");
            queue.Enqueue("환자3 - 심장마비");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }*/

            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
            pq.Enqueue("환자1 - 감기", 5);
            pq.Enqueue("환자2 - 타박상", 8);
            pq.Enqueue("환자3 - 심장마비", 1);
            pq.Enqueue("환자4 - 교통사고", 3);
            pq.Enqueue("환자5 - 탈모", 9);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(pq.Dequeue());
            }

            pq.Enqueue("환자6 - 심장마비", 1);
            pq.Enqueue("환자7 - 교통사고", 3);

            while (pq.Count > 0)
            {
                Console.WriteLine(pq.Dequeue());
            }

            // 내림차순 : int 우선순위에 * -1을 적용하여 사용
            PriorityQueue<string, int> pq2 = new PriorityQueue<string, int>();

            pq2.Enqueue("Data1", -1);
            pq2.Enqueue("Data7", -7);
            pq2.Enqueue("Data5", -5);
            pq2.Enqueue("Data3", -3);
            pq2.Enqueue("Data9", -9);
        }
    }
}
