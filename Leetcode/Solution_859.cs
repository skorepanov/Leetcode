// 859. Buddy Strings
public class Solution_859
{
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length != goal.Length)
        {
            return false;
        }

        if (s == goal)
        {
            return s.ToHashSet().Count != s.Length;
        }

        var indexOfFirstDiff = (int?)null;
        var indexOfSecondDiff = (int?)null;

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == goal[i])
            {
                continue;
            }

            if (indexOfFirstDiff is null)
            {
                indexOfFirstDiff = i;
                continue;
            }

            if (indexOfSecondDiff is null)
            {
                indexOfSecondDiff = i;
                continue;
            }

            return false;
        }

        if (indexOfSecondDiff is null)
        {
            return false;
        }

        return s[indexOfFirstDiff.Value] == goal[indexOfSecondDiff.Value]
            && s[indexOfSecondDiff.Value] == goal[indexOfFirstDiff.Value];
    }
}