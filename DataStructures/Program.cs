using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.IO.Enumeration;
using System.Text;

namespace DataStructures
{
    class Program
    {
        private static void Main(string[] args)
        {

            //Console.WriteLine("双城记");
            //var path = "Resource/ATaleOfTwoCities.txt";
            //var strList = TestHelper.ReadFile(path);
            //Console.WriteLine($"词汇量总数：{strList.Count}{Environment.NewLine}");
            //long stopWatch;

            //Console.WriteLine($"字典{Environment.NewLine}");

            //Console.WriteLine("有序红黑树字典RBT2Dictionary，对比C#中的SortDictionary");
            //RBT2Dictionary<string, int> rBT2Dictionary = new();
            //stopWatch = Test(rBT2Dictionary, strList);
            //Console.WriteLine($"不同单词总数：{rBT2Dictionary.Count}{Environment.NewLine}city出现的次数：{rBT2Dictionary.Get("city")}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");

            //Console.WriteLine("无序字典Hash，对比C#中的Dictionary");
            //HashST2Dictionary<string, int> hashST2Dictionary = new(997);
            //stopWatch = Test(hashST2Dictionary, strList);
            //Console.WriteLine($"不同单词总数：{hashST2Dictionary.Count}{Environment.NewLine}city出现的次数：{hashST2Dictionary.Get("city")}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");

            //Console.WriteLine("C#中的无序红黑树字典Dictionary");
            //Dictionary<string, int> dictionary = new();
            //stopWatch = Test(dictionary, strList);
            //Console.WriteLine($"不同单词总数：{dictionary.Count}{Environment.NewLine}city出现的次数：{dictionary["city"]}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");

            //Console.WriteLine("C#中的有序红黑树字典SortedDictionary");
            //SortedDictionary<string, int> sortedDictionary = new();
            //stopWatch = Test(sortedDictionary, strList);
            //Console.WriteLine($"不同单词总数：{sortedDictionary.Count}{Environment.NewLine}city出现的次数：{sortedDictionary["city"]}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");

            //Console.WriteLine($"集合{Environment.NewLine}");

            //Console.WriteLine("有序红黑树集合RBT1Set，对比C#中的SortSet");
            //RBT1Set<string> rBT1Set = new();
            //stopWatch = Test(rBT1Set, strList);
            //Console.WriteLine($"不同单词数：{rBT1Set.Count}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");

            //Console.WriteLine("无序哈希集合HashST1Set，对比C#中的HashSet");
            //HashST1Set<string> hashST1Set = new(997);
            //stopWatch = Test(hashST1Set, strList);
            //Console.WriteLine($"不同单词总数：{hashST1Set.Count}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");

            //Console.WriteLine("C#中的有序红黑树集合SortSet");
            //SortedSet<string> sortedSet = new();
            //stopWatch = Test(sortedSet, strList);
            //Console.WriteLine($"不同单词总数：{sortedSet.Count}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");

            //Console.WriteLine("C#中的无序哈希集合HashSet");
            //HashSet<string> hashSet = new();
            //stopWatch = Test(hashSet, strList);
            //Console.WriteLine($"不同单词总数：{hashSet.Count}{Environment.NewLine}运行时间：{stopWatch}ms{Environment.NewLine}");


            //Stack stack = new();
            //Queue queue = new();
            //Array array = new Array[10];
            //ArrayList arrayList = new();
            //List<int> list = new();
            //LinkedList<int> linkedList = new();
            //SortedList sortedList = new();
            //SortedList<int,int> intSortedList = new();
            //Dictionary<int, int> dictionary = new();
            //SortedDictionary<int, int> sortedDictionary = new();
            //Hashtable hashtable = new();
            //SortedSet<int> sortedSet = new();
            //HashSet<int> hashSet = new();


            //Date[] dates =
            //{
            //    new Date(2020,10,1,"国庆节"),
            //    new Date(2020, 1, 1, "元旦节"),
            //    new Date(2020,9,10,"教师节"),
            //    new Date(2020, 3, 8, "妇女节"),
            //    new Date(2021,6,1,"儿童节"),
            //    new Date(2020, 2, 14, "情人节"),
            //    new Date(2020,7,7,"七夕节"),
            //    new Date(2020, 1, 25, "春节"),
            //    new Date(2020,8,15,"中秋节"),
            //    new Date(2019,5,1,"劳动节"),
            //    new Date(2020,12,25,"元宵节"),
            //    new Date(2020,4,4,"清明节"),
            //};
            //PrintArray(dates);


            MaxHeap<int> maxHeap = new();
            int[] a = { 3, 2, 1, 5, 4 };
            foreach (var item in a)
            {
                maxHeap.Insert(item);
                Console.WriteLine(maxHeap);
            }
            maxHeap.RemoveMax();
            Console.WriteLine(maxHeap);






        }

        //public static void PrintArray<E>(E[] arr) where E : IComparable<E>
        //{
        //    foreach (var item in arr)
        //    {
        //        Console.Write($"{item} ");
        //    }
        //    BubbleSortGeneric.Sort(arr);
        //    Console.WriteLine();
        //    foreach (var item in arr)
        //    {
        //        Console.Write($"{item} ");
        //    }
        //    Console.WriteLine();
        //}
        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            SelectSort.Sort(arr);
            Console.WriteLine();
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static int Func(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException("阶乘必须为正整数");
            }
            return n == 1 || n == 0 ? 1 : n * Func(n - 1);
        }


        public static long Test(HashSet<string> set, List<string> words)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var word in words)
            {
                set.Add(word);
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
        //C#中的SortedSet
        public static long Test(SortedSet<string> set, List<string> words)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var word in words)
            {
                set.Add(word);
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
        //ISet<T>是自己定义的集合接口，来学习算法，并测试自己实现的SortedArray2Set<T>排序数组集合、LinkedList1Set<T>动态数组集合、BST1ISet<T>二叉查找树集合与C#中的SortSet<T>的时间复杂度
        public static long Test(ISet<string> set, List<string> words)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var word in words)
            {
                set.Add(word);
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }


        //C#中的SortDictionary
        public static long Test(SortedDictionary<string, int> sortedDictionary, List<string> words)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var word in words)
            {
                if (!sortedDictionary.ContainsKey(word))
                {
                    sortedDictionary.Add(word, 1);
                }
                else
                {
                    sortedDictionary[word]++;
                }
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
        //C#中的SortDictionary
        public static long Test(Dictionary<string, int> sortedDictionary, List<string> words)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var word in words)
            {
                if (!sortedDictionary.ContainsKey(word))
                {
                    sortedDictionary.Add(word, 1);
                }
                else
                {
                    sortedDictionary[word]++;
                }
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }
        //IDictionary<T>是自己定义的字典接口，来学习算法，并测试自己实现的SortedArray2Dictionary<T>排序数组字典、LinkedList3Dictionary<T>动态数组字典与C#中的SortDictionary<T>的时间复杂度
        public static long Test(IDictionary<string, int> dictionary, List<string> words)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary.Set(word, dictionary.Get(word) + 1);
                }
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }


        //C#中的SortedList
        public static long Test(SortedList<string, int> sortedList, List<string> words)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (var word in words)
            {
                if (!sortedList.ContainsKey(word))
                {
                    sortedList.Add(word, 1);
                }
                else
                {
                    sortedList[word]++;
                }
            }

            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
        }



        //C#中的Stack栈
        public static long Test(Stack<int> stack, int count)
        {
            var timer = new Stopwatch();
            timer.Start();
            for (var i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            for (var i = 0; i < count; i++)
            {
                stack.Pop();
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
        //IStack<T>是自己定义的栈接口，来学习算法，并测试自己实现的Array1Stack<T>数组栈、LinkedList1Stack<T>动态数组栈与C#中的Stack<T>的时间复杂度
        public static long Test(IStack<int> stack, int count)
        {
            var timer = new Stopwatch();
            timer.Start();
            for (var i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            for (var i = 0; i < count; i++)
            {
                stack.Pop();
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }


        //C#中的Queue<>队列
        public static long Test(Queue<int> queue, int count)
        {
            var timer = new Stopwatch();
            timer.Start();
            for (var i = 0; i < count; i++)
            {
                queue.Enqueue(i);
            }

            for (var i = 0; i < count; i++)
            {
                queue.Dequeue();
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
        //IQueue<T>是自己定义的队列接口，来学习算法，并测试自己实现的Array1Queue<T>数组队列、LinkedList2Queue<T>动态数组队列与C#中的Queue<T>的时间复杂度
        public static long Test(IQueue<int> queue, int count)
        {
            var timer = new Stopwatch();
            timer.Start();
            for (var i = 0; i < count; i++)
            {
                queue.Enqueue(i);
            }

            for (var i = 0; i < count; i++)
            {
                queue.Dequeue();
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
    }
}