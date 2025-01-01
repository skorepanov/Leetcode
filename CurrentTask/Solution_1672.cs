// 1672. Richest Customer Wealth
public class Solution_1672
{
    public int MaximumWealth(int[][] accounts)
    {
        var maxWealth = int.MinValue;

        foreach (var accountSums in accounts)
        {
            var accountTotalSum = accountSums.Sum();
            maxWealth = Math.Max(maxWealth, accountTotalSum);
        }

        return maxWealth;
    }
}