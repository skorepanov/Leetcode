// 744. Find Smallest Letter Greater Than Target
public class Solution_744
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        var left = 0;
        var right = letters.Length - 1;

        while (left < right)
        {
            var middle = left + (right - left) / 2;

            if (letters[middle] <= target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle;
            }
        }

        return letters[left] > target
            ? letters[left]
            : letters[0];
    }
}