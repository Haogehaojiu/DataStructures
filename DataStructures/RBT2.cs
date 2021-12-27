using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class RBT2<Key, Value> where Key : IComparable<Key>
    {
        //红黑树 非红即黑 true表示红 false表示黑
        //记true和false可能会混乱，设置bool的Red和Black
        private const bool Red = true;
        private const bool Black = false;

        private class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;
            //红黑树 非红即黑 true表示红 false表示黑
            public bool color;

            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                left = right = default;
                color = Red;
            }
        }

        private Node root;
        private int N;

        public RBT2()
        {
            root = default;
            N = default;
        }

        public int Count => N;
        public bool IsEmpty => N is 0;
        private bool IsRed(Node node)
        {
            if (node is null)
                return Black;

            return node.color;
        }

        //     node               x
        //    /   \    左旋转    /   \
        //   T1    x   ---->  node   T3
        //       /   \       /   \
        //      T2    T3    T1   T2
        private Node LeftRotate(Node node)
        {
            var x = node.right;
            node.right = x.left;
            x.left = node;

            x.color = node.color;
            node.color = Red;

            return x;
        }
        private void FlipColor(Node node)
        {
            node.color = Red;
            node.left.color = node.right.color = Black;
        }
        //      node               x
        //     /   \    左旋转    /   \
        //    x    T2   ---->  T3   node
        //  /   \                   /   \
        // T3    T1                T1   T2
        private Node RightRotate(Node node)
        {
            var x = node.left;
            node.left = x.right;
            x.right = node;

            x.color = node.color;
            node.color = Red;
            return x;
        }

        //在红黑树中Add新node.Add方法为递归的方式
        public void Add(Key key, Value value)
        {
            root = Add(root, key, value);

            //红黑树的根为黑色
            root.color = Black;
        }
        //在以node为根的树中添加元素e，添加后返回根节点node
        private Node Add(Node node, Key key, Value value)
        {
            if (node is null)
            {
                N++;
                //新创建的node默认为红色
                return new Node(key, value);
            }
            if (key.CompareTo(node.key) < 0)
                node.left = Add(node.left, key, value);
            else if (key.CompareTo(node.key) > 0)
                node.right = Add(node.right, key, value);
            //key.CompareTo(node.key) == 0
            else
                node.value = value;

            //添加完需要维护红和树的平衡性，这里需要维护的情况为三种：
            //1、如果右子节点为红色，而左子节点为黑色，则需要左旋转
            if (IsRed(node.right) && !IsRed(node.left))
                node = LeftRotate(node);
            //2、如果出现连续左子节点都为红色，需要右旋转
            if (IsRed(node.left) && IsRed(node.left.left))
                node = RightRotate(node);
            //3、如果出现左右子节点均为红色，则需要颜色反转
            if (IsRed(node.left) && IsRed(node.right))
                FlipColor(node);

            return node;
        }

        public int MaxHeight()
        {
            return MaxHeight(root);
        }
        private int MaxHeight(Node node)
        {
            if (node is null)
                return 0;

            return Math.Max(MaxHeight(node.left) + 1, MaxHeight(node.right) + 1);
        }
        //返回以node为根节点的红黑树中，key所在的节点,返回该节点
        private Node GetNode(Node node, Key key)
        {
            if (node is null)
                return null;

            if (key.CompareTo(node.key) is 0)
                return node;
            else if (key.CompareTo(node.key) < 0)
                return GetNode(node.left, key);
            //(key.CompareTo(node.key) > 0)
            else
                return GetNode(node.right, key);
        }

        public bool Contains(Key key) => GetNode(root, key) is not null;

        public Value Get(Key key)
        {
            var node = GetNode(root, key);
            if (node is null)
                throw new ArgumentException($"键{key}不存在，无法获取对应的value值");
            else
                return node.value;
        }
        public void Set(Key key, Value newValue)
        {
            var node = GetNode(root, key);
            if (node is null)
                throw new ArgumentException($"键{key}不存在，无法设置对应的value值");
            else
                node.value = newValue;
        }


    }
}