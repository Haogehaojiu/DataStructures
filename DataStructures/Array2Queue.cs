namespace DataStructures
{
    public class Array2Queue<E> : IQueue<E>
    {
        private Array2<E> arr;

        public Array2Queue()
        {
            arr = new Array2<E>();
        }

        public Array2Queue(int capacity)
        {
            arr = new Array2<E>(capacity);
        }

        public int Count => arr.Count;
        public bool IsEmpty => arr.IsEmpty;
        public void Enqueue(E e) => arr.AddLast(e);
        public E Dequeue() => arr.RemoveFirst();
        public E Peek() => arr.GetFirst();

        public override string ToString()
        {
            return $"Queue: front {arr} tail";
        }
    }
}