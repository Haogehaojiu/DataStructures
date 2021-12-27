using System;
using System.Text;

namespace DataStructures
{
    //最小堆
    public class MinHeap<E> where E : IComparable<E>
    {
        private E[] heap;
        private int N;

        public MinHeap(int capacity)
        {
            //由于0的位置不存储，所以容量要多一个
            //这样的好处是，想知道左子节点，只需要父节点的index * 2；想知道右子节点，只需要父节点的index * 2 + 1；想知道父节点，左子节点或右子节点只需index / 2。
            heap = new E[capacity + 1];
            N = default;
        }
        public MinHeap() : this(10) { }
        public int Count => N;
        public bool IsEmpty => N is 0;

        public void Insert(E e)
        {
            if (N == heap.Length - 1)
                ResetCapacity(heap.Length * 2);

            heap[N + 1] = e;
            N++;

            Swim(N);


        }
        public E RemoveMin()
        {
            if (IsEmpty)
                throw new ArgumentNullException("空的最大堆");

            (heap[1], heap[N]) = (heap[N], heap[1]);
            E max = heap[N];
            heap[N] = default;
            N--;

            if (N == (heap.Length - 1) / 4)
                ResetCapacity(heap.Length / 2);

            Sink(1);

            return max;
        }

        //查找最小元素
        public E Min()
        {
            if (IsEmpty)
                throw new ArgumentNullException("空的最大堆");

            return heap[1];
        }

        //元素下沉
        private void Sink(int v)
        {
            while (2 * v <= N)
            {
                var j = 2 * v;
                if (j + 1 <= N && heap[j + 1].CompareTo(heap[j]) < 0)
                    j++;
                if (heap[v].CompareTo(heap[j]) <= 0)
                    break;
                (heap[v], heap[j]) = (heap[j], heap[v]);
                v = j;
            }
        }

        //元素上游
        private void Swim(int n)
        {
            while (n > 1 && heap[n].CompareTo(heap[n / 2]) < 0)
            {
                (heap[n], heap[n / 2]) = (heap[n / 2], heap[n]);
                n /= 2;
            }
        }
        private void ResetCapacity(int newCapacity)
        {
            var newHeap = new E[newCapacity];
            for (var i = 1; i <= N; i++)
            {
                newHeap[i] = heap[i];
            }

            heap = newHeap;
        }

        public override string ToString()
        {
            StringBuilder res = new();
            // res.Append($"Array1: Count= {N}, Capacity= {data.Length}\n");
            res.Append('[');
            for (var i = 1; i <= N; i++)
            {
                res.Append(heap[i]);
                if (i != N)
                {
                    res.Append(", ");
                }
            }

            res.Append(']');
            return res.ToString();
        }
    }
}
