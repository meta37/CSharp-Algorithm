using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace 코딩테스트
{
    internal class Program
    {
        
        static void Permute(int[] elements, int left, int right)
        {
            if (left == right)
            {
                PrintArray(elements);
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    Swap(elements, left, i);
                    Permute(elements, left + 1, right);
                    Swap(elements, left, i);
                }
            }
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }

        static void Main()
        {
            Console.WriteLine("순열을 구할 원소의 개수를 입력하세요:");
            int n = int.Parse(Console.ReadLine());

            int[] elements = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"원소 {i + 1} 입력:");
                elements[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("순열 결과:");
            Permute(elements, 0, n - 1);
        
        }
        
        /*
        void ATM(int time)
        {
            int[] people = { 1, 2, 3, 4, 5 };
            int value = 0;

            foreach (int minute in people)
            {
                while (time <= minute)
                {
                    time -= minute;
                }
            }

        }*/
    }
}
