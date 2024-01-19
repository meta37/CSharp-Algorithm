﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.DesignTechnique
{
    internal class DivideAndConquer
    {
        /*************************************************************************
		 * 분할정복 (Divide and Conquer)
		 * 
		 * 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
		 * 분할을 통해서 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정
		 **************************************************************************/

        // 예시 - 거듭 제곱
        int Pow(int x, int n)       // 0(logn)
        {
            if (n == 1)
            {
                return x;
            }

            int result = Pow(x, n / 2);
            return Pow(x, n/2 ) * Pow (x, n/2 );

            if (n % 2 == 0)
            {
                return Pow(x * x, n / 2);
            }
            else
            {
                return Pow(x * x, n / 2) * x;
            }
        }

        int Power(int x, int n)     // 시간복잡도 0(n)
        {
            int result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= x;
            }
            return result;
        }
    }
}
