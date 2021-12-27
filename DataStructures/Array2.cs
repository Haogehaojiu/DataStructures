using System;
using System.Text;

namespace DataStructures
{
    //循环队列，解决了Array1Queue删除时是O(n)时间复杂度的问题，对应C#中的Queue
    public class Array2<E>
    {
        private E[] data;
        private int first;
        private int last;
        private int N;

        public Array2(int capacity)
        {
            data = new E[capacity];
            first = 0;
            last = 0;
            N = 0;
        }

        public Array2() : this(10)
        {
        }

        public int Count => N;
        public bool IsEmpty => N == 0;

        public void AddLast(E e)
        {
            if (N == data.Length)
            {
                ResetCapacity(data.Length + data.Length);
            }

            data[last] = e;
            last = (last + 1) % data.Length;
            N++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("空数组");
            }

            if (N == data.Length / 4)
            {
                ResetCapacity(data.Length / 2);
            }

            var ret = data[first];
            data[first] = default;

            first = (first + 1) % data.Length;

            N--;

            return ret;
        }

        public E GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("空数组");
            }

            return data[first];
        }

        private void ResetCapacity(int newCapacity)
        {
            var newData = new E[newCapacity];
            for (var i = 0; i < N; i++)
            {
                newData[i] = data[(first + i) % data.Length];
            }

            data = newData;
            first = 0;
            last = N;
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append('[');
            for (var i = 0; i < N; i++)
            {
                res.Append($"{data[(first + i) % data.Length]}");
                if ((first + i + 1) % data.Length != last)
                {
                    res.Append(", ");
                }
            }

            res.Append(']');
            return res.ToString();
        }
    }
}