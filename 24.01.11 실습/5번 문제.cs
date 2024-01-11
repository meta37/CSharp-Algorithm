using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._01._11_실습
{
    internal class _5번_문제
    {
        // 사용자의 입력을 받아서 없는 데이터면 추가, 있던 데이터면 삭제하는 리스트
        // a. ex) 1, 6, 7, 8, 3 들고 있던 상황이면
        // b. 2입력하면 없던 경우니까 1, 6, 7, 8, 3, 2
        // c. 7입력하면 있던 경우니까 1, 6, 8, 3
        static void Main1()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(3);

            Console.WriteLine("숫자를 입력하세요 : ");
            int input = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());

            if (!list.Contains(num))
            {
                list.Add(num);
            }
            else list.Remove(num);
            foreach (int i in list) { Console.WriteLine(i); }
        }
    }
}
