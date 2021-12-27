namespace DataStructures
{
    public class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            var n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                //减去i，不需要对已经排好序的元素减少重复排序，优化排序时长
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    //Swap(arr, j, j + 1);
                }
            }
        }
        public static void Swap(int[] arr, int i, int j)
        {
            var t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
