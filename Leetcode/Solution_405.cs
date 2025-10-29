// 405. Convert a Number to Hexadecimal
public class Solution_405
{
    public string ToHex(int num)
    {
        if (num == 0)
        {
            return "0";
        }

        const int BASE = 16;
        var hexChars = "0123456789abcdef".ToCharArray();

        // конвертировать число в беззнаковое 32-битное представление
        // используется метод two's complement
        var unsignedNum = (uint)num;

        var numBase16 = string.Empty;

        while (unsignedNum > 0)
        {
            var remainder = (int)(unsignedNum % BASE);
            unsignedNum /= BASE;

            var hexChar = hexChars[remainder];
            numBase16 = hexChar + numBase16;
        }

        return numBase16;
    }
}