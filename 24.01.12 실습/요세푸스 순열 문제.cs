using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._01._12_실습
{
    internal class 요세푸스_순열_문제
    {
        public void main1()
        {
            int n = 7;
            int k = 3;
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.WriteLine("사람의 수를 입력하세요 : ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("제거할 순서를 입력하세요 : ");
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                linkedList.AddLast(i);
            }

            while (linkedList.Count > 0)
            {
                for (int i = 0; i <= k; i++)
                {
                    LinkedListNode<int> node = linkedList.First;
                    if(i == k)
                    {
                        // 빠지기
                        linkedList.Remove(node);
                        Console.Write($"{node.Value} ");
                    }
                    else
                    {
                        // 뒤로 들어가기
                        linkedList.Remove(node);
                        linkedList.AddLast(node);
                    }
                }
            }

        }
    }
}
