using System;
namespace DataStructures
{
    //随机快速排序
    public class QuickSort1
    {
        public static void Sort(int[] arr)
        {
            var n = arr.Length;
            Sort(arr, 0, n - 1);
        }

        private static void Sort(int[] arr, int l, int r)
        {
            //选择1：递归出口的条件
            //if (l >= r) return;
            //选择2：小优化，小于等于15长度使用插入排序
            if (r - l + 1 <= 15)
            {
                InserSort.Sort1(arr, l, r);
                return;
            }

            var v = arr[l];
            //arr[l + 1 ... j] < v
            //arr[j + 1 ... i - 1] > v
            var j = l;
            for (int i = l + 1; i <= r; i++)
            {
                if (arr[i] < v)
                {
                    j++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[l], arr[j]) = (arr[j], arr[l]);

            Sort(arr, l, j - 1);
            Sort(arr, j + 1, r);
        }
    }
}
