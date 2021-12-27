using System;
namespace DataStructures
{
    //原地堆排序O(logN)
    //时间复杂度和空间复杂度比最大堆要好很多，
    public class HeapSort2
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = (n - 1 - 1) / 2; i >= 0; i--)
            {
                Sink(arr, i, n - 1);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Sink(arr, 0, i - 1);
            }

        }

        //元素下沉
        private static void Sink(int[] arr, int v, int N)
        {
            while (2 * v + 1 <= N)
            {
                var j = 2 * v + 1;
                if (j + 1 <= N && arr[j + 1].CompareTo(arr[j]) > 0)
                    j++;
                if (arr[v].CompareTo(arr[j]) >= 0)
                    break;
                (arr[v], arr[j]) = (arr[j], arr[v]);
                v = j;
            }
        }
    }
}
