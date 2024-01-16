using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public bool Add(T item)
        {
            Node<T> newNode = new Node<T>(item, null, null, null);

            if (root == null)
            {
                root = newNode;
                return true;
            }

            Node<T> current = root;  // 현재 비교하고 있는 노드
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    // 왼쪽으로 가는 경우
                    if (current.left != null)
                    {
                        // 왼쪽 자식이 있는 경우
                        // 왼쪽으로 가서 계속 하강작업을 반복
                        current = current.left;
                    }
                    else
                    {
                        // 왼쪽 자식이 없는 경우
                        // 이 자리가 추가될 자리
                        current.left = newNode;
                        newNode.Parent = current;
                        break;
                    }
                }
                else if (item.CompareTo(current.item) < 0)
                {
                    // 오른쪽 가는 경우
                    if (current.right != null)
                    {
                        // 오른쪽 자식이 있는 경우
                        // 오른쪽으로 가서 계속 하강작업을 반복
                        current = current.right;
                    }
                    else
                    {
                        // 오른쪽 자식이 없는 경우
                        // 이 자리가 추가될 자리
                        current.right = newNode;
                        newNode.Parent = current;
                        break;
                    }
                }
                else
                {
                    // 똑같은 값을 찾았을 경우
                    // 중복 무시
                    return false;
                }
            }
            return true;
        }

        private void EraseNode(Node<T> node)
        {
            if (node.HasNoChild)
            {
                // 자식이 0개인 경우
                if (node.IsLeftChild)
                {
                    node.Parent.left = null;
                }
                else if (node.IsRightChild)
                {
                    node.Parent.right = null;
                }
                else // (node.IsRootNode)
                {
                    root = null;
                }
            }
            else if (node.HasNoChild || node.HasRightChild)
            {
                // 자식이 1개인 경우
                Node<T> parent = node.Parent;
                Node<T> child = node.HasLeftChild ? node.left : node.right;

                //부모와 자식을 연결해주고 삭제
                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.Parent = parent;
                }
                else if (node.IsRightChild)
                {
                    parent.right = child;
                    child.Parent = parent;
                }
                else // if (node.IsRootNode)
                {
                    root = child;
                    child.Parent = null;
                }
            }
            else // if (node.HasBothChild) 
            {
                // 자식이 2개인 경우
                Node<T> nextNode = node.right;
                while (nextNode.left != null)
                {
                    nextNode = nextNode.left;
                }
                node.item = nextNode.item;
                EraseNode(nextNode);
            }
        }
        public bool Remove(T item)
        {
            Node<T> findNode = FindNode(item);
            if (findNode == null)
            {
                return false;
            }
            else
            {
                EraseNode(findNode);
                return true;
            }
        }

        public bool Contains(T item)
        {
            Node<T> findNode = FindNode(item);
            if (findNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private Node<T> FindNode(T item)
        {
            if (root == null)
            {
                return null;
            }

            Node<T> current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    // 왼쪽으로 가는 경우
                    current=current.left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    // 오른쪽으로 가는 경우
                    current = current.right;
                }
                else
                {
                    // 똑같은 짓을 발견한 경우
                    // 찾았다.
                    return current;
                }
            }

            return null;
        }
    }

    public class Node<T>
    {
        public T item;

        public Node<T> Parent;
        public Node<T> left;
        public Node<T> right;

        public Node(T item, Node<T> parent, Node<T> left, Node<T> right)
        {
            this.item = item;
            Parent = parent;
            this.left = left;
            this.right = right;
        }

        public bool IsRootNode { get { return Parent != null; } }

        public bool IsLeftChild { get { return Parent != null && Parent.left == this; } }
        public bool IsRightChild { get { return Parent != null && Parent.right == this; } }

        public bool HasNoChild { get { return left == null && right == null; } }
        public bool HasLeftChild { get { return left != null && right == null; } }
        public bool HasRightChild { get { return left != null && right != null; } }
        public bool HasBothChild { get { return left != null && right != null; } }

    }

}
