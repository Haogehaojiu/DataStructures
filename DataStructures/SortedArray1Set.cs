using System;

namespace DataStructures
{
    //有序数组集合
    public class SortedArray1Set<Key> : ISet<Key> where Key : IComparable<Key>
    {
        private readonly SortedArray1<Key> sortedArray1;

        public SortedArray1Set(int capacity)
        {
            sortedArray1 = new SortedArray1<Key>(capacity);
        }
        public SortedArray1Set()
        {
            sortedArray1 = new SortedArray1<Key>();
        }

        public int Count => sortedArray1.Count;
        public bool IsEmpty => sortedArray1.IsEmpty;

        public void Add(Key e)
        {
            sortedArray1.Add(e);
        }

        public void Remove(Key e)
        {
            sortedArray1.Remove(e);
        }

        public bool Contains(Key e)
        {
            return sortedArray1.Contains(e);
        }
    }
}