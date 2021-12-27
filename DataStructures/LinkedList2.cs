using System;
using System.Text;

namespace DataStructures
{
    public class LinkedList2<E>
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
        private Node tail;
        private int N;

        public LinkedList2()
        {
            head = null;
            tail = null;
            N = 0;
        }

        public int Count => N;

        public bool IsEmpty => N == 0;

        public void AddLast(E e)
        {
            var node = new Node(e);
            if (IsEmpty)
            {
                head = tail = node;
            }
            else
            {
                tail = tail.next = node;
            }

            N++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("空链表");
            }

            var delE = head.e;
            head = head.next;
            N--;
            if (head == null)
            {
                tail = null;
            }

            return delE;
        }

        public E GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("空链表");
            }

            return head.e;
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            var current = head;
            while (current != null)
            {
                res.Append($"{current.e} ");
                current = current.next;
            }

            res.Append("Null");
            return res.ToString();
        }
    }
}