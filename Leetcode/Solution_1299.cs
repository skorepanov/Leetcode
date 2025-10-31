// 1299. Replace Elements with Greatest Element on Right Side
public class Solution_1299
{
    public int[] ReplaceElements(int[] arr)
    {
        var max = arr[^1];
        var current = arr[^1];
        arr[^1] = -1;

        for (var i = arr.Length - 2; i >= 0; i--)
        {
            current = arr[i];
            arr[i] = max;
            max = Math.Max(current, max);
        }

        return arr;
    }
}