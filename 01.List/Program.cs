﻿namespace _01.List
{
    internal class Program
    {
        /*******************************************************
         * 리스트 (List)
         * 
         * 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
         * 배열요소의 갯수를 특정할 수 없는 경우 사용이 용이
         *******************************************************/

        // <리스트 구현>
        // 리스트는 배열기반의 자료구조이며, 배열은 크기를 변경할 수 없는 자료구조
        // 리스트는 동작 중 크기를 확장하기 위해 포함한 데이터보다 더욱 큰 배열을 사용
        //
        // 크기 = 3, 용량 = 8       크기 = 4, 용량 = 8       크기 = 5, 용량 = 8
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│ │ │ │ │ │        │1│2│3│4│ │ │ │ │        │1│2│3│4│5│ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


        // <리스트 삽입>
        // 중간에 데이터를 추가하기 위해 이후 데이터들을 뒤로 밀어내고 삽입 진행
        //      ↓                        ↓                        ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│ │ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│A│3│4│ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘

        //      ↓                        ↓                       
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐  
        // │1│2│3│4│ │ │ │ │   =>   │1│2│3│4│A│ │ │ │   
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘    


        // <리스트 삭제>
        // 중간에 데이터를 삭제한 뒤 빈자리를 채우기 위해 이후 데이터들을 앞으로 당김
        //      ↓                        ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│A│3│4│ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│3│4│ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘



        // <리스트 용량>
        // 용량을 가득 채운 상황에서 데이터를 추가하는 경우
        // 더 큰 용량의 배열을 새로 생성한 뒤 데이터를 복사하여 새로운 배열을 사용
        //
        // 1. 리스트가 가득찬 상황에서 새로운 데이터 추가 시도
        // 크기 = 8, 용량 = 8
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ ← A 추가
        // └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 2. 새로운 더 큰 배열 생성
        // 크기 = 8, 용량 = 8          크기 = 0, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ ← A 추가  │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 3. 새로운 배열에 기존의 데이터 복사
        // 크기 = 8, 용량 = 8          크기 = 8, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ ← A 추가  │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 4. 기본 배열 대신 새로운 배열을 사용
        // 크기 = 8, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │ ← A 추가
        // └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 5. 빈공간에 데이터 추가
        // 크기 = 9, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│A│ │ │ │ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘

        // <리스트 시간복잡도>
        // 접근    탐색    삽입    삭제
        // O(1)    O(n)   O(n)    O(n)

        static void Main(string[] args)
        {
            List<int> list1 = new List<int>(100000);
            for (int i = 0; i < 100000; i++)
            {
                list1.Add(i);
            }

            List<string> list = new List<string>(); // 값을 안넣었을 때 0개 짜리

            // 추가
            list.Add("0번째 데이터");
            list.Add("1번째 데이터");
            list.Add("2번째 데이터");
            list.Add("3번째 데이터");
            list.Add("4번째 데이터");                // 0(1)
            list.Insert(1, "중간 데이터 1에 추가");  // 0(n)
            list.Insert(3, "중간 데이터 3에 추가");


            // 삭제
            bool succes = list.Remove("2번째 데이터");
            list.Remove("3번째 데이터");
            list.RemoveAt(2);
            list.Remove("6번째 데이터");    // 없는건 못 지우니까 패스


            // 접근
            list[0] = "수정된 0번 데이터";
            string text = list[2];

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = text;
            }


            // 탐색
            int index = list.IndexOf("4번째 데이터");
        }
    }
}