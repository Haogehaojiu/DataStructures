namespace DataStructures
{
    public class LinkedList1Stack<E> : IStack<E>
    {
        private readonly LinkedList1<E> list;

        public LinkedList1Stack()
        {
            list = new LinkedList1<E>();
        }

        public int Count => list.Count;
        public bool IsEmpty => list.IsEmpty;

        public void Push(E e) => list.AddFirst(e);

        public E Pop() => list.RemoveFirst();

        public E Peek() => list.GetFirst();

        public override string ToString()
        {
            return $"Stack: top {list}";
        }
    }
}