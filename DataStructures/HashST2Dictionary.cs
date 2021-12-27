using System;
namespace DataStructures
{
    //对应C#中的Dictionary
    public class HashST2Dictionary<Key, Value> : IDictionary<Key, Value>
    {
        private HashST2<Key, Value> hashST2;

        public HashST2Dictionary(int M)
        {
            hashST2 = new(M);
        }
        public HashST2Dictionary()
        {
            hashST2 = new();
        }

        public int Count => hashST2.Count;

        public bool IsEmpty => hashST2.IsEmpty;

        public void Add(Key key, Value value) => hashST2.Add(key, value);

        public bool ContainsKey(Key key) => hashST2.Contains(key);

        public Value Get(Key key) => hashST2.Get(key);

        public void Remove(Key key) => hashST2.Remove(key);

        public void Set(Key key, Value newValue) => hashST2.Set(key, newValue);
    }
}
