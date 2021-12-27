namespace DataStructures
{
    public class TestSearch
    {
        public static int BinarySearch(int[] arr, int target)
        {
            var l = 0;
            var r = arr.Length - 1;

            while (l <= r)
            {
                //当l或r是大整型值时，mid的值会溢出，不能用加法，改用减法
                // var mid = (l + r) / 2;
                var mid = l + (r - 1) / 2;
                if (target < arr[mid])
                {
                    r = mid - 1;
                }
                else if (target > arr[mid])
                {
                    l = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}