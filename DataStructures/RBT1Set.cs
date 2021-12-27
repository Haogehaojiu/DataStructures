using System;
namespace DataStructures
{
    //对应C#中的SortedSet
    public class RBT1Set<E> : ISet<E> where E : IComparable<E>
    {
        private RBT1<E> rBT1;
        public RBT1Set()
        {
            rBT1 = new();
        }

        public int Count => rBT1.Count;

        public bool IsEmpty => rBT1.IsEmpty;

        public void Add(E e) => rBT1.Add(e);

        public bool Contains(E e) => rBT1.Contains(e);

        public void Remove(E e) => Console.WriteLine("移除方法待实现");

        public int MaxHeight() => rBT1.MaxHeight();
    }
}
