namespace DataStructures
{
    //先进先出——数组队列
    public class Array1Queue<E> : IQueue<E>
    {
        private Array1<E> arr;

        public Array1Queue()
        {
            arr = new Array1<E>();
        }

        public Array1Queue(int capacity)
        {
            arr = new Array1<E>(capacity);
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