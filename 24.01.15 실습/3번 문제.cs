using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._01._15_실습
{
    internal class _3번_문제
    {
        public const int workTime = 8;

        public static int[] ProcessJob(int[] jobList)
        {
            Queue<int> queue = new Queue<int>();
            int remainTime = 0;
            int day = 1;
            List<int> days = new List<int>();

            for (int i = 0; i < jobList.Length; i++)
            {
                queue.Enqueue(jobList[i]);
            }

            while (queue.Count > 0)
            {
                int workTime=queue.Dequeue();
                while (true)
                {
                    if (workTime <= remainTime)
                    {
                        remainTime -= workTime;
                        // 작업 완료
                        days.Add(day);
                        break;
                    }
                    else
                    {
                        workTime -= remainTime;
                        // 다음 날로
                        day++;
                        remainTime = 8;
                    }
                }
            }
            return days.ToArray();
        }

        static void Main(string[] args)
        {
            int[] result = ProcessJob(new int[] { 4, 4, 12, 10, 2, 10 });
            foreach (int day in result)
            {
                Console.WriteLine(day);
            }
        }
    }
}
