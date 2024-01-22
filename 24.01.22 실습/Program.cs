using System.Security.Cryptography;

namespace _24._01._22_실습
{
    internal class Program
    {
        public static void Swap(IList<int> list, int leftIndex, int rightIndex)
        {
            int temp = list[leftIndex];
            list[leftIndex] = list[rightIndex];
            list[rightIndex] = temp;
        }

        public static void Selectionsort(IList<int> list, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j <= end; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(list, i, minIndex);
            }
        }

        public static void InsertionSort(IList<int> list, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (list[j - 1] < list[j])
                    {
                        break;
                    }

                    Swap(list, j - 1, j);
                }
            }
        }

        public static void Merge(IList<int> list, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            while (leftIndex <= mid && rightIndex <= end)
            {
                if (list[leftIndex] < list[rightIndex])
                {
                    sortedList.Add(list[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sortedList.Add(list[rightIndex]);
                    rightIndex++;
                }
            }

            if (leftIndex > mid)
            {
                for (int i = rightIndex; i <= end; i++)
                {
                    sortedList.Add(list[i]);
                }
            }
            else
            {
                for (int i = leftIndex; i <= mid; i++)
                {
                    sortedList.Add(list[i]);
                }
            }

            for (int i = 0; i < sortedList.Count; i++)
            {
                list[start + i] = sortedList[i];
            }
        }

        public static void MergeSort(IList<int> list, int start, int end)
        {
            if (start == end)
                return;

            int mid = (start + end) / 2;
            MergeSort(list, start, mid);
            MergeSort(list, mid + 1, end);
            Merge(list, start, mid, end);
        }

        public static void BubbleSort(IList<int> list, int start, int end)
        {
            for (int i = start; i <= end - 1; i++)
            {
                for (int j = start; j < end - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + i);
                    }
                }
            }
        }

        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right)
            {
                while (list[left] <= list[pivot] && left < end)
                {
                    left++;
                }
                while (list[right] > list[pivot] && left <= right)
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(list, left, right);
                }
                else
                {
                    Swap(list, pivot, right);
                    break;
                }
            }

            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 10;

            List<int> selectionlist = new List<int>();
            List<int> insertionlist = new List<int>();
            List<int> mergelist = new List<int>();
            List<int> bubblelist = new List<int>();
            List<int> quicklist = new List<int>();

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(0, 100);
                Console.WriteLine($"{rand, 3}");

                selectionlist.Add(rand);
                insertionlist.Add(rand);
                mergelist.Add(rand);
                bubblelist.Add(rand);
                quicklist.Add(rand);
            }
            Console.WriteLine();

            Console.WriteLine("선택정렬 결과 : ");
            Selectionsort(selectionlist, 0, selectionlist.Count - 1);
            foreach( int value  in selectionlist)
            {
                Console.WriteLine($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("삽입정렬 결과 : ");
            InsertionSort(insertionlist, 0, insertionlist.Count -1);
            foreach ( int value2 in insertionlist)
            {
                Console.WriteLine($"{value2,3}");
            }
            Console.WriteLine();

            Console.WriteLine("병합정렬 결과 : ");
            MergeSort(mergelist, 0, mergelist.Count - 1);
            foreach (int value3 in insertionlist)
            {
                Console.WriteLine($"{value3,3}");
            }
            Console.WriteLine();

            Console.WriteLine("버블정렬 결과 : ");
            BubbleSort(bubblelist, 0, bubblelist.Count - 1);
            foreach (int value4 in bubblelist)
            {
                Console.WriteLine($"{value4,3}");
            }
            Console.WriteLine();

            Console.WriteLine("퀵정렬 결과 : ");
            QuickSort(quicklist, 0, quicklist.Count - 1);
            foreach (int value5 in quicklist)
            {
                Console.WriteLine($"{value5,3}");
            }
            Console.WriteLine();
        }
    }
}
