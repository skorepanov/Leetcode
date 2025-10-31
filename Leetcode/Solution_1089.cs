// 1089. Duplicate Zeros
public class Solution_1089
{
    public void DuplicateZeros(int[] arr)
    {
        for (var i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] == 0)
            {
                for (var right = arr.Length - 1; right > i; right--)
                {
                    arr[right] = arr[right - 1];
                }

                arr[i + 1] = 0;
                i++;
            }
        }
    }
}