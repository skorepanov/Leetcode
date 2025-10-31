// 1346. Check If N and Its Double Exist
public class Solution_1346
{
    public bool CheckIfExist(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = 0; j < arr.Length; j++)
            {
                if (i != j && arr[i] == 2 * arr[j])
                {
                    return true;
                }
            }
        }

        return false;
    }
}