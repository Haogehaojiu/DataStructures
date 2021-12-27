using System;
namespace DataStructures
{
    //对应C#中的SortDictionary
    public class RBT2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private RBT2<Key, Value> rBT2;
        public RBT2Dictionary()
        {
            rBT2 = new();
        }

        public int Count => rBT2.Count;

        public bool IsEmpty => rBT2.IsEmpty;

        public void Add(Key key, Value value) => rBT2.Add(key, value);

        public bool ContainsKey(Key key) => rBT2.Contains(key);

        public Value Get(Key key) => rBT2.Get(key);

        public void Remove(Key key)
        {
            Console.WriteLine("删除功能待实现");
        }

        public void Set(Key key, Value newValue) => rBT2.Set(key, newValue);
    }
}
