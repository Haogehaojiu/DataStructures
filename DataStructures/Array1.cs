using System;
using System.Text;

namespace DataStructures
{
    //第一版数组，除了具有数组的功能外，增加了功能有：自动动态扩容、支持泛型
    public class Array1<E>
    {
        private E[] data;
        private int N;

        public Array1(int capacity)
        {
            data = new E[capacity];
            N = 0;
        }

        public Array1() : this(10)
        {
        }

        public int Capacity => data.Length;
        public int Count => N;
        public bool IsEmpty => N == 0;

        public void Add(int index, E e)
        {
            if (index < 0 || index > N)
            {
                throw new ArgumentException("数组索引越界。");
            }

            if (N == Capacity)
            {
                ResetCapacity(Capacity + Capacity);
            }

            for (var i = N - 1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }

            data[index] = e;
            N++;
        }

        public void AddLast(E e)
        {
            Add(N, e);
        }

        public void AddFirst(E e)
        {
            Add(0, e);
        }

        public E Get(int index)
        {
            if (index < 0 || index >= N)
            {
                throw new ArgumentException("数组索引越界。");
            }

            return data[index];
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
            if (index < 0 || index >= N)
            {
                throw new ArgumentException("数组索引越界。");
            }

            data[index] = newE;
        }

        public void SetFirst(E newE)
        {
            data[0] = newE;
        }

        public void SetLast(E newE)
        {
            data[N - 1] = newE;
        }

        public bool Contains(E e)
        {
            for (var i = 0; i < N; i++)
            {
                if (data[i].Equals(e))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(E e)
        {
            for (var i = 0; i < N; i++)
            {
                if (data[i].Equals(e))
                {
                    return i;
                }
            }

            return -1;
        }

        public E RemoveAt(int index)
        {
            if (index < 0 || index >= N)
            {
                throw new ArgumentException("数组索引越界。");
            }

            var del = data[index];

            if (index == N - 1)
            {
                data[index] = default;
            }
            else
            {
                for (var i = index; i < N; i++)
                {
                    data[i] = data[i + 1];
                }
            }

            N--;
            data[N] = default;
            if (N == Capacity / 4)
            {
                ResetCapacity(Capacity / 2);
            }

            return del;
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
            var index = IndexOf(e);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        private void ResetCapacity(int newCapacity)
        {
            var newData = new E[newCapacity];
            for (var i = 0; i < N; i++)
            {
                newData[i] = data[i];
            }

            data = newData;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            // res.Append($"Array1: Count= {N}, Capacity= {data.Length}\n");
            res.Append('[');
            for (var i = 0; i < N; i++)
            {
                res.Append(data[i]);
                if (i != N - 1)
                {
                    res.Append(", ");
                }
            }

            res.Append(']');
            return res.ToString();
        }
    }
}