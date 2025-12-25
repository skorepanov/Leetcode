// 122. Best Time to Buy and Sell Stock II
#region Вариант 1 - Сложнее для понимания - Runtime 1 ms, Beats 12.11%
public class Solution_122_1
{
    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 1)
        {
            return 0;
        }

        var maxProfit = 0;
        var today = 0;
        var bought = (int?)null;

        while (today < prices.Length)
        {
            // если цена не изменилась
            if (prices[today] == prices[today + 1])
            {
                today++;
            }
            // если цена стала расти
            else if (prices[today] < prices[today + 1])
            {
                if (bought is null)
                {
                    bought = prices[today];
                }

                while (today + 1 < prices.Length
                    && prices[today] < prices[today + 1])
                {
                    today++;
                }

                maxProfit += prices[today] - bought.Value;
                bought = null;
                today++;
            }
            // если цена стала падать
            else if (prices[today] > prices[today + 1])
            {
                if (bought is not null)
                {
                    maxProfit += prices[today] - bought.Value;
                }

                while (today + 1 < prices.Length
                    && prices[today] > prices[today + 1])
                {
                    today++;
                }

                bought = prices[today];
                today++;
            }

            if (today + 1 == prices.Length)
            {
                if (prices[today - 1] >= prices[today])
                {
                    return maxProfit;
                }

                if (bought is not null)
                {
                    maxProfit += prices[today] - bought.Value;
                }

                return maxProfit;
            }
        }

        return maxProfit;
    }
}
#endregion

#region Вариант 2 - Проще, быстрее - Runtime 0 ms, Beats 100.00%
public class Solution_122_2
{
    public int MaxProfit(int[] prices)
    {
        var today = 0;
        var valley = prices[0];
        var peak = prices[0];
        var maxProfit = 0;

        while (today < prices.Length - 1)
        {
            while (today < prices.Length - 1
                && prices[today] >= prices[today + 1])
            {
                today++;
            }

            valley = prices[today];

            while (today < prices.Length - 1
                && prices[today] <= prices[today + 1])
            {
                today++;
            }

            peak = prices[today];

            maxProfit += peak - valley;
        }

        return maxProfit;
    }
}
#endregion
