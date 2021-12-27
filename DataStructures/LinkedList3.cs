using System;

namespace DataStructures
{
    public class LinkedList3<Key, Value>
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node next;

            public Node(Key key, Value value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }

            public override string ToString()
            {
                return $"{key.ToString()}: {value.ToString()}";
            }
        }

        private Node head;
        private int N;

        public LinkedList3()
        {
            head = null;
            N = 0;
        }

        public int Count => N;
        public bool IsEmpty => N == 0;

        private Node GetNode(Key key)
        {
            var current = head;
            while (current != null)
            {
                if (current.key.Equals(key))
                {
                    return current;
                }

                current = current.next;
            }

            return null;
        }

        public void Add(Key key, Value value)
        {
            var node = GetNode(key);
            if (node == null)
            {
                head = new Node(key, value, head);
                N++;
            }
            else
            {
                node.value = value;
            }
        }

        public bool Contains(Key key)
        {
            return GetNode(key) != null;
        }

        public Value Get(Key key)
        {
            var node = GetNode(key);
            if (node == null)
            {
                throw new ArgumentException($"Key: {key}不存在");
            }

            return node.value;
        }

        public void Set(Key key, Value newValue)
        {
            var node = GetNode(key);
            if (node == null)
            {
                throw new ArgumentException($"Key: {key}不存在");
            }

            node.value = newValue;
        }

        public void Remove(Key key)
        {
            if (head == null)
            {
                return;
            }

            if (head.key.Equals(key))
            {
                head = head.next;
                N--;
            }
            else
            {
                var current = head;
                Node pre = null;
                if (current != null)
                {
                    while (current != null)
                    {
                        if (current.key.Equals(key))
                        {
                            break;
                        }

                        pre = current;
                        current = current.next;
                    }

                    if (current != null)
                    {
                        pre.next = pre.next.next;
                        N--;
                    }
                }
            }
        }
    }
}