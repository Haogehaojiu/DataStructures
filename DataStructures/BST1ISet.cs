using System;
namespace DataStructures
{
    public class BST1ISet<E> : ISet<E> where E : IComparable<E>
    {
        private BST1<E> bST1;
        public BST1ISet()
        {
            bST1 = new();
        }

        public int Count => bST1.Count;

        public bool IsEmpty => bST1.IsEmpty;

        public void Add(E e) => bST1.Add(e);

        public bool Contains(E e) => bST1.Contains(e);

        public void Remove(E e) => bST1.Remove(e);

        public int MaxHeight() => bST1.MaxHeight();
    }
}
