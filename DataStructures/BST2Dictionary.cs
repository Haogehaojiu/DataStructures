using System;
namespace DataStructures
{
    public class BST2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private readonly BST2<Key, Value> bST2;
        public BST2Dictionary()
        {
            bST2 = new();
        }

        public int Count => bST2.Count;

        public bool IsEmpty => bST2.IsEmpty;

        public void Add(Key key, Value value) => bST2.Add(key, value);

        public bool ContainsKey(Key key) => bST2.Contains(key);

        public Value Get(Key key) => bST2.Get(key);

        public void Remove(Key key) => bST2.Remove(key);

        public void Set(Key key, Value newValue) => bST2.Set(key, newValue);
    }
}
