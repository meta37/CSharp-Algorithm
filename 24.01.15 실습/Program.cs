using System.Security.Cryptography.X509Certificates;

namespace _24._01._15_실습
{
    internal class Program
    {
        // 아래와 같이 추가와 삭제가 순서대로 진행될 경우 스택, 큐의 출력 순서를 적어주자.(코딩없이)
        // a. 추가(1, 2, 3, 4, 5), 모두 꺼내기 : 스택 : 1, 2, 3, 4, 5 큐 : 1, 2, 3, 4, 5
        // b. 추가(1,2,3), 꺼내기(2번), 추가(4,5,6), 꺼내기(1번), 추가(7), 모두꺼내기 : 스택 : 3, 2, 6, 7, 5, 4, 1 큐 : 1, 2, 3, 4, 5, 6, 7
        // c. 추가(3,2,1), 꺼내기(1번), 추가(6,5,4), 꺼내기(3번), 추가(9,8,7), 모두꺼내기 : 스택 : 1, 4, 5, 6, 7, 8, 9, 2, 3 큐 : 3, 2, 1, 6, 5, 4, 9, 8, 7
        // d. 추가(1,3,5), 꺼내기(1번), 추가(2,4,8), 꺼내기(2번), 추가(1,3), 모두꺼내기 : 스택 : 5, 8, 4, 3, 1, 2, 3, 1 큐 : 1, 3, 5, 2, 4, 8, 1, 3
        // e. 추가(3,2,1), 꺼내기(2번), 추가(3,2,1), 꺼내기(2번), 추가(3,2,1), 모두꺼내기 : 스택 : 1, 2, 1, 2, 1, 3, 3 큐 : 3, 2, 1, 3, 2, 1
        
        public static bool IsOk(string text)
        {
            Stack<char> stack = new Stack<char>();
            char temp;
            foreach (char c in text)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    temp = stack.Peek();
                    if (temp == '(' && c == ')') { stack.Pop(); }
                    else if (temp == '{' && c == '}') { stack.Pop(); }
                    else if (temp == '[' && c == ']') { stack.Pop(); }
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }
            else return false;
        }

        static void Main(string[] args)
        {
            Console.Write("괄호를 입력하세요 : ");
            string input = Console.ReadLine();
            if (IsOk(input))
            {
                Console.WriteLine("완성입니다.");
            }
            else
            {
                Console.WriteLine("미완성입니다.");
            }
        }

    }
}
