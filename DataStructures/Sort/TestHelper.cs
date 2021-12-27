using System;
using System.Diagnostics;
using System.Reflection;

namespace DataStructures
{
    public class TestHelper
    {
        //生成n个元素的随机数组，每个元素的随机范围是[0,maxValue]
        public static int[] RandomArray(int n, int maxValue)
        {
            Random r = new();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(maxValue + 1);
            }

            return arr;
        }
        //生成n个元素的近乎有序数组
        public static int[] NearlyOrderedArray(int n, int swapTimes)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }
            Random r = new();
            for (int i = 0; i < swapTimes; i++)
            {
                var a = r.Next(n + 1);
                var b = r.Next(n + 1);

                var t = arr[a];
                arr[a] = arr[b];
                arr[b] = t;
            }

            return arr;
        }
        //判断arr是否有序（从小到大）
        public static void IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    throw new ArgumentException("未排序");
            }
        }
        //拷贝arr数组的所有内容得到相同的数组并返回,为了保证所有测试的用例数组都是相同的
        public static int[] CopyArray(int[] arr)
        {
            var n = arr.Length;
            var temp = new int[n];
            for (int i = 0; i < n; i++)
            {
                temp[i] = arr[i];
            }

            return temp;
        }
        //测试sortClassName所对应的排序算法排序arr数组所得到结果的正确性和算法运行时间
        public static void TestSort(string sortClassName, int[] arr)
        {
            Type type = Type.GetType($"DataStructures.{sortClassName}");
            MethodInfo sortMethod = type.GetMethod("Sort");
            object[] paramsarr = new object[] { arr };
            Stopwatch stopwatch = new();
            stopwatch.Start();
            sortMethod.Invoke(null, paramsarr);
            stopwatch.Stop();
            IsSorted(arr);
            Console.WriteLine($"{type.Name}: {stopwatch.ElapsedMilliseconds}ms");
        }
        public static void ShowArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
