using System;
using System.Text;

namespace DataStructures
{
    //有序数组，后面在此之上实现字典（映射）
    public class SortedArray2<Key, Value> where Key : IComparable<Key>
    {
        private Key[] keys;
        private Value[] values;
        private int N;

        public SortedArray2(int capacity)
        {
            keys = new Key[capacity];
            values = new Value[capacity];
        }

        public SortedArray2() : this(10)
        {
        }

        public int Count => N;
        public bool IsEmpty => N == 0;

        public int Rank(Key key)
        {
            //在[l...r]中查找key
            var l = 0;
            var r = N - 1;

            while (l <= r)
            {
                //当l或r是大整型值时，mid的值会溢出，不能用加法，改用减法
                // var mid = (l + r) / 2;
                var mid = l + (r - l) / 2;

                switch (key.CompareTo(keys[mid]))
                {
                    //在keys[l...mid-1]查找key
                    case < 0:
                        r = mid - 1;
                        break;
                    //在keys[mid+1...r]中查找key
                    case > 0:
                        l = mid + 1;
                        break;
                    default:
                        //找到key，并返回索引
                        return mid;
                }
            }

            //未找到key，范围l，l为小于key的key数量
            return l;
        }

        public Value Get(Key key)
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空数组");
            }

            var i = Rank(key);
            if (i < N && keys[i].CompareTo(key) == 0)
            {
                return values[i];
            }

            throw new ArgumentException($"{key}不存在");
        }

        public void Add(Key key, Value value)
        {
            var i = Rank(key);
            if (N == keys.Length)
            {
                ResetCapacity(keys.Length * 2);
                ResetCapacity(values.Length * 2);
            }

            if (i < N && keys[i].CompareTo(key) == 0)
            {
                values[i] = value;
                return;
            }

            for (var j = N - 1; j >= i; j--)
            {
                keys[j + 1] = keys[j];
                values[j + 1] = values[j];
            }

            keys[i] = key;
            values[i] = value;
            N++;
        }

        public void Remove(Key key)
        {
            if (IsEmpty)
            {
                return;
            }

            var i = Rank(key);
            if (i == N && keys[i].CompareTo(key) != 0)
            {
                return;
            }

            for (var j = i; j < N - 1; j++)
            {
                keys[j] = keys[j + 1];
                values[j] = values[j + 1];
            }

            N--;
            keys[N] = default;
            values[N] = default;
            if (N == keys.Length / 4)
            {
                ResetCapacity(keys.Length / 2);
                ResetCapacity(values.Length / 2);
            }
        }

        public Key Min()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空数组");
            }

            return keys[0];
        }

        public Key Max()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空数组");
            }

            return keys[N - 1];
        }

        public Key Selet(int k)
        {
            if (IsEmpty || k < 0 || k >= N)
            {
                throw new ArgumentException("索引越界");
            }

            return keys[k - 1];
        }

        public bool Contains(Key key)
        {
            var i = Rank(key);
            return i < N && keys[i].CompareTo(key) == 0;
        }

        //找出小于或等于key的最大键
        public Key Floor(Key key)
        {
            var i = Rank(key);
            if (i < N && keys[i].CompareTo(key) == 0)
            {
                return keys[i];
            }

            if (i == 0)
            {
                throw new ArgumentException($"没有找到小于或等于{key}的最大键");
            }

            return keys[i - 1];
        }

        public Key Ceiling(Key key)
        {
            var i = Rank(key);
            if (i == N)
            {
                throw new ArgumentException($"没有找到大于或等于{key}的最大键");
            }

            return keys[i];
        }

        private void ResetCapacity(int newCapacity)
        {
            var newKeys = new Key[newCapacity];
            var newValues = new Value[newCapacity];
            for (var i = 0; i < N; i++)
            {
                newKeys[i] = keys[i];
                newValues[i] = values[i];
            }

            keys = newKeys;
            values = newValues;
        }

        public override string ToString()
        {
            var res = new StringBuilder();
            // res.Append($"Array1: Count= {N}, Capacity= {data.Length}\n");
            res.Append('[');
            for (var i = 0; i < N; i++)
            {
                res.Append($"{{{keys[i]}, {values[i]}}}");
                if (i != N - 1)
                {
                    res.Append(", ");
                }
            }

            res.Append(']');
            return res.ToString();
        }
    }
}