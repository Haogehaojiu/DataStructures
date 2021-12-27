using System;
namespace DataStructures
{
    //对应C#中的HashSet
    public class HashST1Set<Key> : ISet<Key>
    {
        private HashST1<Key> hashST1;

        public HashST1Set(int M)
        {
            hashST1 = new(M);
        }
        public HashST1Set()
        {
            hashST1 = new();
        }

        public int Count => hashST1.Count;

        public bool IsEmpty => hashST1.IsEmpty;

        public void Add(Key e) => hashST1.Add(e);

        public bool Contains(Key e) => hashST1.Contains(e);

        public void Remove(Key e) => hashST1.Remove(e);
    }
}
