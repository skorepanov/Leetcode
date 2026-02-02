// 1523. Count Odd Numbers in an Interval Range
public class Solution_1523
{
    public int CountOdds(int low, int high)
    {
        var count = 0;

        if (low % 2 == 1)
        {
            low++;
            count++;
        }

        if (high % 2 == 1)
        {
            high--;
            count++;
        }

        count += (high - low) / 2;

        return count;
    }
}