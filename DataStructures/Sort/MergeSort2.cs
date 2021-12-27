using System;
namespace DataStructures
{
    //归并排序 优化
    public class MergeSort2
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];
            Sort(arr, temp, 0, n - 1);
        }
        private static void Sort(int[] arr, int[] temp, int l, int r)
        {

            if (r - l + 1 <= 15)
            {
                InserSort.Sort1(arr, l, r);
                return;
            }

            int mid = l + (r - l) / 2;

            Sort(arr, temp, l, mid);
            Sort(arr, temp, mid + 1, r);

            if (arr[mid] > arr[mid + 1])
                Merge(arr, temp, l, mid, r);
        }
        //将arr[l...mid]和arr[mid...r]两部分有序排列的两组进行归并
        private static void Merge(int[] arr, int[] temp, int l, int mid, int r)
        {

            int i = l;
            int j = mid + 1;
            int k = l;

            //左右半边都有元素
            while (i <= mid && j <= r)
            {
                if (arr[i] < arr[j])
                {
                    temp[k++] = arr[i++];
                    //上面一句与下面三句作用一样，更简洁的写法
                    //temp[k] = arr[i];
                    //k++;
                    //i++;
                }
                //arr[i] > arr[j]
                else
                {
                    temp[k++] = arr[j++];
                    //上面一句与下面三句作用一样，更简洁的写法
                    //temp[k] = arr[j];
                    //k++;
                    //j++;
                }
            }
            //左半边有元素，右半边元素用尽，取左半边元素放入temp
            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }
            //右半边有元素，左半边元素用尽，取右半边元素放入temp
            while (j <= r)
            {
                temp[k++] = arr[j++];
            }
            //将完成排序的temp数组元素拷贝到原arr数组中
            for (int z = l; z <= r; z++)
            {
                arr[z] = temp[z];
            }
        }
    }
}
