// 121. Best Time to Buy and Sell Stock
public class Solution_121
{
    public int MaxProfit(int[] prices)
    {
        var min = int.MaxValue;
        var profit = 0;

        foreach (var price in prices)
        {
            if (price < min)
            {
                min = price;
            }
            else if (price - min > profit)
            {
                profit = price - min;
            }
        }

        return profit;
    }
}