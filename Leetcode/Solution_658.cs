// 658. Find K Closest Elements

#region Solution 1 - Binary search and Sliding window - Runtime 6 ms, Beats 52.27%
public class Solution_658_1
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        if (arr.Length == k)
        {
            return arr;
        }

        var closest = FindClosestElement(arr, x);
        var closestElements = FindClosestElements(arr, k, x, closest);
        return  closestElements;
    }

    private int FindClosestElement(int[] arr, int x)
    {
        var left = 0;
        var right = arr.Length - 1;

        while (left + 1 < right)
        {
            var middle = left + (right - left) / 2;

            if (arr[middle] == x)
            {
                return middle;
            }

            if (arr[middle] > x)
            {
                right = middle;
            }
            else
            {
                left = middle;
            }
        }

        var leftDiff = Math.Abs(x - arr[left]);
        var rightDiff = Math.Abs(x - arr[right]);

        return leftDiff <= rightDiff ? left : right;
    }

    private IList<int> FindClosestElements(int[] arr, int k, int x, int closest)
    {
        var left = closest;
        var right = closest;

        while (right - left + 1 < k)
        {
            if (left == 0)
            {
                right++;
                continue;
            }

            if (right == arr.Length - 1)
            {
                left--;
                continue;
            }

            var leftDiff = Math.Abs(x - arr[left - 1]);
            var rightDiff = Math.Abs(x - arr[right + 1]);

            if (leftDiff <= rightDiff)
            {
                left--;
            }
            else
            {
                right++;
            }
        }

        var closestElements = arr.Skip(left).Take(k).ToArray();
        return closestElements;
    }
}
#endregion

#region Solution 2 - Binary search to find the left bound - Runtime 4 ms, Beats 79.55%
public class Solution_658_2
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        var left = 0;
        var right = arr.Length - k;

        while (left < right)
        {
            var middle = left + (right - left) / 2;

            if (x - arr[middle] > arr[middle + k] - x)
            {
                left = middle + 1;
            }
            else
            {
                right = middle;
            }
        }

        var closestElements = arr.Skip(left).Take(k).ToArray();
        return closestElements;
    }
}
#endregion
