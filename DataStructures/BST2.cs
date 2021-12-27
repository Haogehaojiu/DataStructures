using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class BST2<Key, Value> where Key : IComparable<Key>
    {
        public BST2()
        {
            root = default;
            N = default;
        }

        private class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;
            public Node(Key key, Value value)
            {
                this.key = key;
                this.value = value;
                left = right = default;
            }
        }

        private Node root;
        private int N;

        public int Count => N;
        public bool IsEmpty => N is 0;

        //Add方法为递归的方式添加
        public void Add(Key key, Value value) => root = Add(root, key, value);
        //在以node为根的树中添加元素e，添加后返回根节点node
        private Node Add(Node node, Key key, Value value)
        {
            if (node is null)
            {
                N++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) < 0)
                node.left = Add(node.left, key, value);
            else if (key.CompareTo(node.key) > 0)
                node.right = Add(node.right, key, value);
            else
                node.value = value;

            return node;
        }

        //返回以node为根节点的二叉查找树中，key所在的节点,返回该节点
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

        public Key Min() => Min(root).key;
        private Node Min(Node node)
        {
            if (IsEmpty)
                throw new ArgumentNullException("空树");

            if (node.left is null)
                return node;

            return Min(node.left);
        }
        public Key Max() => Max(root).key;
        private Node Max(Node node)
        {
            if (IsEmpty)
                throw new ArgumentNullException("空树");

            if (node.right is null)
                return node;

            return Max(node.right);
        }
        public Key RemoveMin()
        {
            var result = Min();
            root = RemoveMin(root);
            return result;
        }
        //删除以node为根的二叉查找树中的最小节点
        //返回删除节点后新的二叉查找树的根
        private Node RemoveMin(Node node)
        {
            if (node.left is null)
            {
                N--;
                return node.right;
            }
            node.left = RemoveMin(node.left);
            return node;
        }

        public Key RemoveMax()
        {
            var result = Max();
            root = RemoveMax(root);

            return result;
        }
        private Node RemoveMax(Node node)
        {
            if (node.right is null)
            {
                N--;
                return node.left;
            }

            node.right = RemoveMax(node.right);

            return node;
        }

        public void Remove(Key key) => root = Remove(root, key);
        //删除掉以node为根的二叉查找树中值为e的node
        //删除节点后，返回新二叉查找树的根
        private Node Remove(Node node, Key key)
        {
            if (node is null)
                return null;

            if (key.CompareTo(node.key) < 0)
            {
                node.left = Remove(node.left, key);
                return node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.right = Remove(node.right, key);
                return node;
            }
            //e.CompareTo(node.key) is 0
            else
            {
                if (node.left is null)
                {
                    N--;
                    return node.right;
                }
                else if (node.right is null)
                {
                    N--;
                    return node.left;
                }
                //要删除的节点，左右都有字节点
                //找到待删除节点大的最小节点，既待删除节点的右子树的最小节点
                //用这个节点顶替待删除节点的位置
                ////////////////////////
                //         8          //
                //       /   \        //
                //      4     12      //
                //    /  \   /   \    //
                //   2   6  10   14   //
                ////////////////////////
                var maxMin = Min(node.right);
                maxMin.right = RemoveMin(node.right);
                maxMin.left = node.left;

                return maxMin;
            }
        }

        public int MaxHeight() => MaxHeight(root);
        private int MaxHeight(Node node)
        {
            if (node is null)
                return 0;

            return Math.Max(MaxHeight(node.left) + 1, MaxHeight(node.right) + 1);
        }

        public void PreviousOrder() => PreviousOrder(root);
        //前序遍历以node为根的二叉查找树
        private void PreviousOrder(Node node)
        {
            if (node is null)
                return;

            Console.WriteLine(node.key);
            PreviousOrder(node.left);
            PreviousOrder(node.right);
        }
        public void InOrder() => InOrder(root);
        //中序遍历以node为根的二叉查找树,输出的结果是从小到大排列，这也是二叉树又叫排序树的原因
        //其中InOrder(node.left)、InOrder(node.right)和Console.WriteLine(node.e)不能更改顺序，否则输出的结果不是从小到大排列
        private void InOrder(Node node)
        {
            if (node is null)
                return;

            InOrder(node.left);
            Console.WriteLine($"{node.key},{node.value}");
            InOrder(node.right);
        }
        public void PostOrder() => PostOrder(root);
        //后序遍历以node为根的二叉查找树,输出的结果是从小到大排列，这也是二叉树又叫排序树的原因
        private void PostOrder(Node node)
        {
            if (node is null)
                return;

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.key);
        }
        public void ReverseOrder() => ReverseOrder(root);
        //倒序遍历以node为根的二叉查找树,输出的结果是从大到小排列，这也是二叉树又叫排序树的原因
        //其中ReverseOrder(node.right)、Console.WriteLine(node.e)和ReverseOrder(node.left)不能更改顺序，否则输出的结果不是从小到大排列
        private void ReverseOrder(Node node)
        {
            if (node is null)
                return;

            ReverseOrder(node.right);
            Console.WriteLine(node.key);
            ReverseOrder(node.left);
        }
        //层序遍历,从根节点一层一层遍历二叉树
        public void LevelOrder()
        {
            Queue<Node> queue = new();
            queue.Enqueue(root);
            while (queue.Count is not 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current.key);

                if (current.left is not null)
                    queue.Enqueue(current.left);

                if (current.right is not null)
                    queue.Enqueue(current.right);
            }
        }
    }
}