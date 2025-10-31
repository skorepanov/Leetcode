// 941. Valid Mountain Array
public class Solution_941
{
    public bool ValidMountainArray(int[] arr)
    {
        if (arr.Length < 3)
        {
            return false;
        }

        if (arr[1] < arr[0])
        {
            return false;
        }

        var shouldIncrease = true;

        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                return false;
            }

            if (shouldIncrease && arr[i - 1] > arr[i])
            {
                shouldIncrease = false;
            }

            if (!shouldIncrease && arr[i - 1] < arr[i])
            {
                return false;
            }
        }

        if (shouldIncrease)
        {
            return false;
        }

        return true;
    }
}
