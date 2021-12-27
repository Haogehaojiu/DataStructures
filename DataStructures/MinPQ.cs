using System;
namespace DataStructures
{
    //基于最小堆的最小优先队列
    public class MinPQ<E> : IQueue<E> where E : IComparable<E>
    {
        private MinHeap<E> heap;

        public MinPQ(int capacity)
        {
            heap = new(capacity);
        }
        public MinPQ()
        {
            heap = new();
        }

        public int Count => heap.Count;

        public bool IsEmpty => heap.IsEmpty;

        public E Dequeue() => heap.RemoveMin();

        public void Enqueue(E e) => heap.Insert(e);

        public E Peek() => heap.Min();

        public override string ToString()
        {
            return heap.ToString();
        }
    }
}
