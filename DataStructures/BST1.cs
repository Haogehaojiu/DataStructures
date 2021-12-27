using System;
using System.Collections.Generic;

namespace DataStructures
{
    //数组和链表，特别是需要有序性情况下，在增、删、改、插中某个操作的时间复杂度很难下降
    //由此引入二叉查找树，二叉查找树的缺点：在顺序或者逆序添加数据时，退化为链表，时间复杂度为O(n)
    public class BST1<E> where E : IComparable<E>
    {
        public BST1()
        {
            root = default;
            N = default;
        }
        private class Node
        {
            public E e;
            public Node left;
            public Node right;
            public Node(E e)
            {
                this.e = e;
                left = right = default;
            }
        }
        private Node root;
        private int N;

        public int Count => N;
        public bool IsEmpty => N is 0;

        //AddNonRecursive方法为非递归的方式添加
        public void AddNonRecursive(E e)
        {
            if (root is null)
            {
                root = new Node(e);
                N++;
                return;
            }
            Node previous = null;
            Node current = root;

            while (current is not null)
            {
                if (e.CompareTo(current.e) == 0)
                {
                    return;
                }

                previous = current;

                if (e.CompareTo(current.e) < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            current = new(e);
            if (e.CompareTo(previous.e) < 0)
            {
                previous.left = current;
            }
            else
            {
                previous.right = current;
            }
            N++;
        }
        //Add方法为递归的方式添加
        public void Add(E e)
        {
            root = Add(root, e);

        }
        //在以node为根的树中添加元素e，添加后返回根节点node
        private Node Add(Node node, E e)
        {
            if (node is null)
            {
                N++;
                return new Node(e);
            }
            if (e.CompareTo(node.e) < 0)
            {
                node.left = Add(node.left, e);
            }
            else if (e.CompareTo(node.e) > 0)
            {
                node.right = Add(node.right, e);
            }
            return node;
        }
        public bool Contains(E e)
        {
            return Contains(root, e);

        }
        private bool Contains(Node node, E e)
        {
            if (node is null)
            {
                return false;
            }
            if (e.CompareTo(node.e) < 0)
            {
                return Contains(node.left, e);
            }
            else if (e.CompareTo(node.e) > 0)
            {
                return Contains(node.right, e);
            }
            else
            {
                return true;
            }
        }
        public void PreviousOrder()
        {
            PreviousOrder(root);
        }
        //前序遍历以node为根的二叉查找树
        private void PreviousOrder(Node node)
        {
            if (node is null)
            {
                return;
            }
            Console.WriteLine(node.e);
            PreviousOrder(node.left);
            PreviousOrder(node.right);
        }
        public void InOrder()
        {
            InOrder(root);
        }
        //中序遍历以node为根的二叉查找树,输出的结果是从小到大排列，这也是二叉树又叫排序树的原因
        //其中InOrder(node.left)、InOrder(node.right)和Console.WriteLine(node.e)不能更改顺序，否则输出的结果不是从小到大排列
        private void InOrder(Node node)
        {
            if (node is null)
            {
                return;
            }
            InOrder(node.left);
            Console.WriteLine(node.e);
            InOrder(node.right);
        }
        public void PostOrder()
        {
            PostOrder(root);
        }
        //后序遍历以node为根的二叉查找树,输出的结果是从小到大排列，这也是二叉树又叫排序树的原因
        private void PostOrder(Node node)
        {
            if (node is null)
            {
                return;
            }
            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.e);
        }
        public void ReverseOrder()
        {
            ReverseOrder(root);
        }
        //倒序遍历以node为根的二叉查找树,输出的结果是从大到小排列，这也是二叉树又叫排序树的原因
        //其中ReverseOrder(node.right)、Console.WriteLine(node.e)和ReverseOrder(node.left)不能更改顺序，否则输出的结果不是从小到大排列
        private void ReverseOrder(Node node)
        {
            if (node is null)
            {
                return;
            }
            ReverseOrder(node.right);
            Console.WriteLine(node.e);
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
                Console.WriteLine(current.e);

                if (current.left is not null)
                {
                    queue.Enqueue(current.left);
                }
                if (current.right is not null)
                {
                    queue.Enqueue(current.right);
                }
            }
        }
        public E Min()
        {
            return Min(root).e;
        }
        private Node Min(Node node)
        {
            if (IsEmpty)
            {
                throw new ArgumentNullException("空树");
            }
            if (node.left is null)
            {
                return node;
            }
            return Min(node.left);
        }
        public E Max()
        {
            return Max(root).e;
        }
        private Node Max(Node node)
        {
            if (IsEmpty)
            {
                throw new ArgumentNullException("空树");
            }
            if (node.right is null)
            {
                return node;
            }
            return Max(node.right);
        }
        public E RemoveMin()
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
        ////////////////////////
        //         8          //
        //       /   \        //
        //      4     12      //
        //    /  \   /   \    //
        //   2   6  10   14   //
        ////////////////////////
        public E RemoveMax()
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
        public void Remove(E e)
        {
            root = Remove(root, e);
        }
        //删除掉以node为根的二叉查找树中值为e的node
        //删除节点后，返回新二叉查找树的根
        private Node Remove(Node node, E e)
        {
            if (node is null)
            {
                return null;
            }
            if (e.CompareTo(node.e) < 0)
            {
                node.left = Remove(node.left, e);
                return node;
            }
            else if (e.CompareTo(node.e) > 0)
            {
                node.right = Remove(node.right, e);
                return node;
            }
            //e.CompareTo(node.e) is 0
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
        public int MaxHeight()
        {
            return MaxHeight(root);
        }
        private int MaxHeight(Node node)
        {
            if (node is null)
            {
                return 0;
            }

            return Math.Max(MaxHeight(node.left) + 1, MaxHeight(node.right) + 1);
        }
    }
}
