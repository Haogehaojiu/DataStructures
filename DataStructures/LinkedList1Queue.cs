namespace DataStructures
{
    public class LinkedList1Queue<E> : IQueue<E>
    {
        private readonly LinkedList1<E> list;

        public LinkedList1Queue()
        {
            list = new LinkedList1<E>();
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