using System;
namespace DataStructures
{
    //堆排序
    public class HeapSort1
    {
        //时间复杂度：O(2NlogN)（建堆O(NlogN)，出堆O(NlogN)）
        //空间复杂度：O(N)
        public static void Sort(int[] arr)
        {
            var n = arr.Length;
            MaxHeap<int> maxHeap = new(n);
            for (int i = 0; i < n; i++)
            {
                maxHeap.Insert(arr[i]);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                arr[i] = maxHeap.RemoveMax();
            }

        }
    }
}
