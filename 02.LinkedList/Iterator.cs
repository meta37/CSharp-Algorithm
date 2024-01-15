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
        /*******************************************************************
		 * 반복기 (Iterator)
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순차적으로 접근하기 위한 객체
		 * C# 대부분의 자료구조는 반복기를 포함
		 * 이를 통해 자료구조종류와 내부구조에 무관하게 순회가능
		 *******************************************************************/

        // <반복기 사용>
        // 반복기 객체를 자료구조에서 생성하여 순차적으로 확인하며 순회
        // IEnumerable : 자료구조의 반복기 생성 인터페이스
        // IEnumerator : 자료구조의 반복기 객체 인터페이스
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
