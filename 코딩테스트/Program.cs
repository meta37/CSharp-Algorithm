namespace 코딩테스트
{
    internal class Program
    {
        public class Solution
        {

            public static int[] solution(int[] num_list)
            {
                int[] answer = new int[2];

                for (int i = 0; i < num_list.Length; i++)
                {
                    if (num_list[i] % 2 == 0)
                    {
                        answer[0]++;
                    }
                    else
                    {
                        answer[1]++;
                    }
                }
                return answer;
            }

            static void Main()
            {
                int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                int[] result = solution(inputArray);

                // 결과 출력
                Console.WriteLine("Even Count: " + result[0]);
                Console.WriteLine("Odd Count: " + result[1]);
            }
        }
    }
}
