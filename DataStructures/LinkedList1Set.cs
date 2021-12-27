namespace DataStructures
{
    //无重复元素的链表集合
    public class LinkedList1Set<E> : ISet<E>
    {
        private readonly LinkedList1<E> list;

        public LinkedList1Set()
        {
            list = new LinkedList1<E>();
        }

        public int Count => list.Count;
        public bool IsEmpty => list.IsEmpty;

        public void Add(E e)
        {
            if (!Contains(e))
            {
                list.AddFirst(e);
            }
        }

        public void Remove(E e) => list.Remove(e);

        public bool Contains(E e) => list.Contains(e);
    }
}