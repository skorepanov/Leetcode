// 504. Base 7
public class Solution_504
{
    public string ConvertToBase7(int num)
    {
        if (num == 0)
        {
            return "0";
        }

        var numberBase7 = string.Empty;
        var absoluteNumber = Math.Abs(num);

        while (absoluteNumber != 0)
        {
            numberBase7 = (absoluteNumber % 7) + numberBase7;
            absoluteNumber /= 7;
        }

        return num > 0
            ? numberBase7
            : "-" + numberBase7;
    }
}