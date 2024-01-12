using System.Security.Cryptography.X509Certificates;

namespace _24._01._12_실습
{
    internal class Program
    {
        // 사용자의 입력으로 숫자를 입력 받아서 (마이너스도 허용)
        // 음수는 앞에 추가하고, 양수는 뒤에 추가하여
        // 음수&양수를 반으로 나누는 연결리스트 구현
        // 입력 받을 때마다 처음부터 끝까지 출력 진행

        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            while (true)
            {
                Console.Write("숫자를 입력하세요 :");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine($"{input}을 입력하셨습니다.");
                if (input == 0)
                {
                    Console.WriteLine("0은 종료합니다.");
                    break;
                }

                if (input > 0) 
                {
                    linkedList.AddLast(input);
                }
                else 
                {
                    linkedList.AddFirst(input);
                }

                Console.Write("연결리스트 출력 : ");
                for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
                {
                    Console.Write($"{node.Value} ");
                }
            }

        }
    }
    
}
