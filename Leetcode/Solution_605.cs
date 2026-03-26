// 605. Can Place Flowers
public class Solution_605
{
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        if (n == 0)
        {
            return true;
        }

        if (flowerbed.Length < n)
        {
            return false;
        }

        if (flowerbed.Length == 1)
        {
            return flowerbed[0] == 0;
        }

        var leftN = n;

        if (flowerbed[0] == 0 && flowerbed[1] == 0)
        {
            flowerbed[0] = 1;
            leftN--;
        }

        if (leftN == 0)
        {
            return true;
        }

        for (var i = 1; i < flowerbed.Length - 1; i++)
        {
            if (flowerbed[i - 1] == 0 && flowerbed[i] == 0 && flowerbed[i + 1] == 0)
            {
                flowerbed[i] = 1;
                leftN--;

                if (leftN == 0)
                {
                    return true;
                }

                i++;
            }
        }

        if (flowerbed[^2] == 0 && flowerbed[^1] == 0)
        {
            flowerbed[^1] = 1;
            leftN--;
        }

        return leftN == 0;
    }
}