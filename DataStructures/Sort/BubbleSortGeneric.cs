using System;
namespace DataStructures
{
    public class BubbleSortGeneric
    {
        public static void Sort<E>(E[] arr) where E : IComparable<E>
        {
            var n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                //减去i，不需要对已经排好序的元素减少重复排序，优化排序时长
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }
    }
}
