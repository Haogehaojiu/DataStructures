using System;
namespace DataStructures
{
    //有序数组字典
    public class SortedArray2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private readonly SortedArray2<Key, Value> sortedArray2;
        public SortedArray2Dictionary(int capacity)
        {
            sortedArray2 = new SortedArray2<Key, Value>(capacity);
        }
        public SortedArray2Dictionary() : this(10) { }

        public int Count => sortedArray2.Count;

        public bool IsEmpty => sortedArray2.IsEmpty;

        public void Add(Key key, Value value)
        {
            sortedArray2.Add(key, value);
        }

        public bool ContainsKey(Key key)
        {
            return sortedArray2.Contains(key);
        }

        public Value Get(Key key)
        {
            return sortedArray2.Get(key);
        }

        public void Remove(Key key)
        {
            sortedArray2.Remove(key);
        }

        public void Set(Key key, Value newValue)
        {
            sortedArray2.Add(key, newValue);
        }
    }
}
