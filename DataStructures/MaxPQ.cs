using System;
namespace DataStructures
{
    //基于最大堆的最大优先队列
    public class MaxPQ<E> : IQueue<E> where E : IComparable<E>
    {
        private MaxHeap<E> heap;

        public MaxPQ(int capacity)
        {
            heap = new(capacity);
        }
        public MaxPQ()
        {
            heap = new();
        }

        public int Count => heap.Count;

        public bool IsEmpty => heap.IsEmpty;

        public E Dequeue() => heap.RemoveMax();

        public void Enqueue(E e) => heap.Insert(e);

        public E Peek() => heap.Max();

        public override string ToString()
        {
            return heap.ToString();
        }
    }
}
