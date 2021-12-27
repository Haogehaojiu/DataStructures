using System.Runtime.InteropServices;

namespace DataStructures
{
    public class LinkedList2Queue<E> : IQueue<E>
    {
        private readonly LinkedList2<E> list;

        public LinkedList2Queue()
        {
            list = new LinkedList2<E>();
        }


        public int Count => list.Count;
        public bool IsEmpty => list.IsEmpty;
        public void Enqueue(E e) => list.AddLast(e);

        public E Dequeue() => list.RemoveFirst();

        public E Peek() => list.GetFirst();

        public override string ToString()
        {
            return $"Queue front {list} tail";
        }
    }
}