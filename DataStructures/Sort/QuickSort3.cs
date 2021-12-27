using System;
namespace DataStructures
{
    //三向切分排序
    public class QuickSort3
    {
        private static Random rd = new();

        public static void Sort(int[] arr)
        {
            var n = arr.Length;
            Sort(arr, 0, n - 1);
        }

        private static void Sort(int[] arr, int l, int r)
        {
            //小规模的数据，使用插入排序替代三向切分排序
            if (r - l + 1 <= 15)
            {
                InserSort.Sort1(arr, l, r);
                return;
            }

            var p = l + rd.Next(r - l + 1);

            (arr[l], arr[p]) = (arr[p], arr[l]);

            var v = arr[l];
            //arr[l + 1 ... lt] < v
            var lt = l;
            //arr[gt ... r] > v
            var gt = r + 1;
            //arr[lt + 1 ... i - 1] == v
            var i = l + 1;

            while (i < gt)
            {
                if (arr[i] < v)
                {
                    lt++;
                    (arr[i], arr[lt]) = (arr[lt], arr[i]);
                    i++;
                }
                else if (arr[i] > v)
                {
                    gt--;
                    (arr[i], arr[gt]) = (arr[gt], arr[i]);
                }
                //arr[i] == v
                else
                {
                    i++;
                }
            }

            (arr[l], arr[lt]) = (arr[lt], arr[l]);

            Sort(arr, l, lt);
            Sort(arr, gt, r);
        }
    }
}
