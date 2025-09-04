// 779. K-th Symbol in Grammar
public class Solution_779
{
    private readonly Dictionary<int, int[]> _replacements = new()
    {
        [0] = [0, 1],
        [1] = [1, 0]
    };

    public int KthGrammar(int n, int k)
    {
        if (k == 1)
        {
            return 0;
        }

        var prevKValue = KthGrammar(n - 1, (k + 1) / 2);
        var replacement = _replacements[prevKValue];

        return replacement[(k + 1) % 2];
    }
}
