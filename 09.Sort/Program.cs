namespace _09.Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 20;

            List<int> selectionlist = new List<int>();
            List<int> insertionlist = new List<int>();
            List<int> bubblelist = new List<int>();
            List<int> mergelist = new List<int>();
            List<int> quicklist = new List<int>();

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(0, 100);
                Console.WriteLine($"{rand},3");

                selectionlist.Add(rand);
                insertionlist.Add(rand);
                bubblelist.Add(rand);
                mergelist.Add(rand);
                quicklist.Add(rand);
            }
            Console.WriteLine();

            Console.WriteLine("선택정렬 결과 : ");
            Sorting.SelectionSort(selectionlist, 0, selectionlist.Count - 1);
            foreach(int value in selectionlist)
            {
                Console.WriteLine($"{value,3}");
            }
            Console.WriteLine();
        }
    }
}
