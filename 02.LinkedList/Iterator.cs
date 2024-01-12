using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList
{
    internal class Iterator
    {
        void Main1()
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, string> map = new SortedDictionary<int, string>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
                set.Add (i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]}");
            }

            for (int i = 0; i< linkedList.Count; i++)
            {
                Console.Write($"{list[i]}");
            }

            for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
            {
                Console.Write($"{node.Value}");
            }

            foreach (int value in list)
            {
                Console.Write($"{value}");
            }

            foreach  (int value in linkedList)
            {
                Console.Write($"{value}");
            }

            foreach (int value in set)
            {
                Console.Write($"{value}");
            }

            foreach (int value in Func())
            {
                Console.Write($"{value}");
            }
        }

        public static float Average(IEnumerable<int> container)
        {
            float average = 0;
            int count = 0;
            foreach (int value in container)
            {
                average += value;
                count++;
            }
            return average / count;
        }


        public static IEnumerable<int> Func()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
    }
}
