using System.ComponentModel;

namespace _24._01._11_실습
{
    internal class Program
    {
        // 사용자에게 숫자를 입력 받아서
        // 0부터 숫자까지 가지는 리스트를 만들기
        // 0요소를 제거
        // 리스트가 가지는 모든 요소들을 출력해주는 반복문 작성 add remove 접근
        
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            Console.Write("숫자를 입력하세요 : ");
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i <= input; i++)
            {
                list.Add(i);
            }
            list.Remove(0);
            for (int i = 0;i < list.Count; i++)
            {
                Console.Write(list[i]);
            }

        }
    }
}
