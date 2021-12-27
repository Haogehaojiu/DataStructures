using System;
using System.Text;

namespace DataStructures
{
    //第一版单链表，真正的动态数据结构，有多少元素就有多少个节点，C#中自带的链表是双向链表
    public class LinkedList1<E>
    {
        private class Node
        {
            public E e;
            public Node next;

            public Node(E e, Node next)
            {
                this.e = e;
                this.next = next;
            }

            public Node(E e)
            {
                this.e = e;
                this.next = null;
            }

            public override string ToString()
            {
                return e.ToString();
            }
        }

        private Node head;
        private int N;

        public LinkedList1()
        {
            head = null;
            N = 0;
        }

        public int Count => N;
        public bool IsEmpty => N == 0;

        public void Add(int index, E e)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("非法索引");
            }

            if (index == 0)
            {
                // var node = new Node(e);
                // node.next = head;
                // head = node;
                head = new Node(e, head);
            }
            else
            {
                var pre = head;
                for (var i = 0; i < index - 1; i++)
                {
                    pre = pre.next;
                }

                // var node = new Node(e);
                // node.next = pre.next;
                // pre.next = node;
                pre.next = new Node(e, pre.next);
            }

            N++;
        }

        public void AddFirst(E e)
        {
            Add(0, e);
        }

        public void AddLast(E e)
        {
            Add(N, e);
        }

        public E Get(int index)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("非法索引");
            }

            var current = head;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.e;
        }

        public E GetFirst()
        {
            return Get(0);
        }

        public E GetLast()
        {
            return Get(N - 1);
        }

        public void Set(int index, E newE)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("非法索引");
            }

            var current = head;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }

            current.e = newE;
        }

        public void SetFirst(E newE)
        {
            Set(0, newE);
        }

        public void SetLast(E newE)
        {
            Set(N - 1, newE);
        }

        public bool Contains(E e)
        {
            var current = head;
            while (current != null)
            {
                if (current.e.Equals(e))
                {
                    return true;
                }

                current = current.next;
            }

            return false;
        }

        public E RemoveAt(int index)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("非法索引");
            }

            if (index == 0)
            {
                var delHeadE = head.e;
                head = head.next;
                N--;
                return delHeadE;
            }

            var pre = head;
            for (var i = 0; i < index - 1; i++)
            {
                pre = pre.next;
            }

            var delE = pre.next.e;
            pre.next = pre.next.next;
            N--;
            return delE;
        }

        public E RemoveFirst()
        {
            return RemoveAt(0);
        }

        public E RemoveLast()
        {
            return RemoveAt(N - 1);
        }

        public void Remove(E e)
        {
            if (head == null)
            {
                return;
            }

            if (head.e.Equals(e))
            {
                head = head.next;
                N--;
            }

            Node pre = null;
            var current = head;
            while (current != null)
            {
                if (current.e.Equals(e))
                {
                    break;
                }

                pre = head;
                current = current.next;
            }

            if (current != null)
            {
                pre.next = pre.next.next;
                N--;
            }
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append($"数量： {Count}\n");
            var current = head;
            while (current != null)
            {
                res.Append($"{current} -> ");
                current = current.next;
            }

            res.Append("Null");

            return res.ToString();
        }
    }
}