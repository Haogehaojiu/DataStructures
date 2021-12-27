namespace DataStructures
{
    public class SelectSort
    {
        public static void Sort(int[] arr)
        {
            var n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                var min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                (arr[i], arr[min]) = (arr[min], arr[i]);
                //Swap(arr, i, min);
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
