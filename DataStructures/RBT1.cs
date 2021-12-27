using System;
using System.Collections.Generic;

namespace DataStructures
{
    //基于二叉查找树
    //无论数据是顺序、逆序、随机的添加，都能维护树的高度，时间复杂度均为O(log n)不至于想二叉查找树退化为链表
    //在数据规模小、随机添加的情况下，时间复杂度与二分查找树近似。
    public class RBT1<E> where E : IComparable<E>
    {
        //红黑树 非红即黑 true表示红 false表示黑
        //记true和false可能会混乱，设置bool的Red和Black
        private const bool Red = true;
        private const bool Black = false;

        private class Node
        {
            public E e;
            public Node left;
            public Node right;
            //红黑树 非红即黑 true表示红 false表示黑
            public bool color;

            public Node(E e)
            {
                this.e = e;
                left = right = default;
                color = Red;
            }
        }

        private Node root;
        private int N;

        public RBT1()
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
        public void Add(E e)
        {
            root = Add(root, e);

            //红黑树的根为黑色
            root.color = Black;
        }
        //在以node为根的树中添加元素e，添加后返回根节点node
        private Node Add(Node node, E e)
        {
            if (node is null)
            {
                N++;
                //新创建的node默认为红色
                return new Node(e);
            }
            if (e.CompareTo(node.e) < 0)
                node.left = Add(node.left, e);
            else if (e.CompareTo(node.e) > 0)
                node.right = Add(node.right, e);

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

        public bool Contains(E e)
        {
            return Contains(root, e);

        }
        private bool Contains(Node node, E e)
        {
            if (node is null)
                return false;
            if (e.CompareTo(node.e) < 0)
                return Contains(node.left, e);
            else if (e.CompareTo(node.e) > 0)
                return Contains(node.right, e);
            else
                return true;
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



    }
}