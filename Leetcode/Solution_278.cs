// 278. First Bad Version

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version);
*/

public class Solution_278 : VersionControl_278
{
    public int FirstBadVersion(int n)
    {
        var left = 0;
        var right = n;

        while (left < right)
        {
            var middle = left + (right - left) / 2;
            var isBad = IsBadVersion(middle);

            if (isBad)
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }
}

// !!! мок
public class VersionControl_278
{
    public bool IsBadVersion(int version)
    {
        return default;
    }
}
