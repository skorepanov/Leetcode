// 1502. Can Make Arithmetic Progression From Sequence
public class Solution_1502
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        Array.Sort(arr);

        var diff = arr[1] - arr[0];

        for (var i = 2; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] != diff)
            {
                return false;
            }
        }

        return true;
    }
}