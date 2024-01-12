using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList
{
    internal class Node
    {
        /*******************************************************************
		 * 노드 (Node)
		 * 
		 * 여러 자료구조에서 사용하는 기본 단위
		 * 데이터와 다른 노드를 참조하는 값을 가짐
		 * 다른 노드의 참조를 연결하는 방식에 따라 여러 자료구조를 구현가능
		 *******************************************************************/

        // <노두 구현>
        // 노드에 데이터와 다른 노드를 참조하는 값을 구성하여 구현

        // 연결된 노드를 가지는 List를 통해 유동적인 연결구조를 가짐
        // 연결구조가 일정하지 않은 트리/그래프 등에 사용

        public class LinkedListNode<T>
		{
			public T value;

			public LinkedListNode<T> prev; // 이전 위치
			public LinkedListNode<T> next; // 다음 위치도 알고 있음
		}


        public class BinaryTreeNode<T>
        {
            public T value;

            public BinaryTreeNode<T> parent;
            public BinaryTreeNode<T> left;
            public BinaryTreeNode<T> right;
        }

        public class OctTreeNode<T>
        {
            public T value;

            public OctTreeNode<T> parent;
            public OctTreeNode<T>[] children = new OctTreeNode<T>[8];
        }

        public class AdjacentNode<T>
        {
            public T value;

            public List<AdjacentNode<T>> connect = new List<AdjacentNode<T>>();
        }
    }
}
