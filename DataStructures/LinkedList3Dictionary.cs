namespace DataStructures
{
    //无重复元素的链表字典，查找效率不高，后面引入二分查找来减少时间复杂度
    //二分查找只能操作有序的数据，而链表是无序的，尽管可以维护住了链表的有序性，也很难取到链表的中间值，所以二分查找最好在数组上增加实现。
    public class LinkedList3Dictionary<Key, Value> : IDictionary<Key, Value>
    {
        private readonly LinkedList3<Key, Value> list;

        public LinkedList3Dictionary()
        {
            list = new LinkedList3<Key, Value>();
        }

        public int Count => list.Count;
        public bool IsEmpty => list.IsEmpty;
        public void Add(Key key, Value value) => list.Add(key, value);

        public void Remove(Key key) => list.Remove(key);

        public bool ContainsKey(Key key) => list.Contains(key);

        public Value Get(Key key) => list.Get(key);

        public void Set(Key key, Value newValue) => list.Set(key, newValue);
    }
}