using System.ComponentModel.DataAnnotations;

namespace 코딩테스트
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] values = { 1, 2, 3, 4, 5, -99, 8 };
            int max = int.MinValue;

            // ex) [2, 4] : 2 ~ 4 더한 값
            int[,] result = new int[values.Length, values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                result[i , i ] = values[i];
                if (max < values[i])
                {
                    max = values[i];
                }
            }

            for (int start = 0; start < values.Length; start++)
            {
                for (int end = start + 1; end < values.Length; end++)
                {
                    result[start , end ] = result[start, end -1 ] + values[end];
                    if (max < result[start, end])
                    {
                        max = result[start, end];
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
