// 374. Guess Number Higher or Lower

/**
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution_374 : GuessGame_374
{
    public int GuessNumber(int n)
    {
        var left = 1;
        var right = n;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;
            var compare = guess(middle);

            switch (compare)
            {
                case 0:
                    return middle;
                case -1:
                    right = middle - 1;
                    break;
                case 1:
                    left = middle + 1;
                    break;
            }
        }

        return -1;
    }
}

// !!! мок
public class GuessGame_374
{
    public int guess(int n)
    {
        return -1;
    }
}
