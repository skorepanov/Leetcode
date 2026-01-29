// 714. Best Time to Buy and Sell Stock with Transaction Fee
public class Solution_714
{
    public int MaxProfit(int[] prices, int fee)
    {
        var n = prices.Length;

        var free = new int[n];
        var hold = new int[n];

        // In order to hold a stock on day 0,
        // we have no other choice but to buy it for prices[0]
        hold[0] = -prices[0];

        for (var i = 1; i < n; i++)
        {
            hold[i] = Math.Max(hold[i - 1], free[i - 1] - prices[i]);
            free[i] = Math.Max(free[i - 1], hold[i - 1] + prices[i] - fee);
        }

        return free[n - 1];
    }
}