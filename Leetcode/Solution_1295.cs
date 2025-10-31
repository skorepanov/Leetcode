// 1295. Find Numbers with Even Number of Digits
public class Solution_1295
{
    public int FindNumbers(int[] nums)
    {
        var evenNumbersCount = 0;

        foreach (var num in nums)
        {
            if (num.ToString().Length % 2 == 0)
            {
                evenNumbersCount++;
            }
        }

        return evenNumbersCount;
    }
}