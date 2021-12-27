using System;
namespace DataStructures
{
    public class HashST2<Key, Value> 
    {
        private LinkedList3<Key, Value>[] hashtable;
        private int N;
        private int M;

        public HashST2(int M)
        {
            this.M = M;
            N = default;
            hashtable = new LinkedList3<Key, Value>[M];
            for (int i = 0; i < M; i++)
            {
                hashtable[i] = new LinkedList3<Key, Value>();
            }
        }
        public HashST2() : this(97) { }

        public int Count => N;
        public bool IsEmpty => N is 0;

        private int Hash(Key key) => (key.GetHashCode() & 0x7fffffff) % M;

        public void Add(Key key, Value value)
        {
            var list = hashtable[Hash(key)];
            if (list.Contains(key))
                list.Set(key, value);
            else
            {
                list.Add(key, value);
                N++;
            }
        }
        public void Remove(Key key)
        {
            var list = hashtable[Hash(key)];
            if (list.Contains(key))
            {
                list.Remove(key);
                N--;
            }
        }
        public bool Contains(Key key)
        {
            var list = hashtable[Hash(key)];
            return list.Contains(key);
        }
        public Value Get(Key key)
        {
            var list = hashtable[Hash(key)];
            return list.Get(key);
        }
        public void Set(Key key, Value newValue)
        {
            var list = hashtable[Hash(key)];
            list.Set(key, newValue);
        }

    }
}
