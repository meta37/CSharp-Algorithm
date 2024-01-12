using _02.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (head == null)
            {

            }
            InsertNodeBefore(head, newNode);
            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            InsertNodeBefore(node, newNode);
            return newNode;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T> (value);
            InsertNodeBefore(node, newNode);
            return newNode;
        }

        public void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> value)
        {
            newNode.prev = node;
            newNode.next = node;    

            if (node == tail)
            {

            }
        }

        private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            LinkedListNode<T> prevNode = node.prev;
            // 1. newNode의 prev를 node의 prev로
            newNode.prev = prevNode;
            // 2. newNode의 next를 node로
            newNode.next = node;
            // 3. node의 prev의 next를 newNode로
            if (node == head) // 3.1 head를 newNode로
            {
                head = newNode;
            }
            else // 3.2 node의 prev의 next를 newNode로
            {
                prevNode.next = newNode;
            }
            // 4. node의 prev를 newNode로
            node.prev = newNode;
            count++;
        }
    }

    public class LinkedListNode<T>
    {
        private T Value;

        public LinkedListNode<T> prev;
        public LinkedListNode<T> next;

        public LinkedListNode(T value)
        {
            this.Value = value;
            this.prev = null;
            this.next = null;
        }

        public LinkedListNode(T value, LinkedListNode<T> prev, LinkedListNode<T> next) : this(value)
        {
            this.Value = value;
            this.prev = prev;
            this.next = next;
        }

    }
}
