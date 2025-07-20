// 702. Search in a Sorted Array of Unknown Size
public class Solution_702
{
    public int Search(ArrayReader reader, int target)
    {
        var left = 0;
        var right = 1;

        while (reader.Get(right) < target)
        {
            left = right;
            right *= 2;
        }

        while (left <= right)
        {
            var middle = left + (right - left) / 2;
            var value = reader.Get(middle);

            if (value == target)
            {
                return middle;
            }

            if (target > value)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return -1;
    }

    public class ArrayReader
    {
        public int Get(int index)
        {
            return default;
        }
    }
}