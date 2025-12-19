// 1770. Maximum Score from Performing Multiplication Operations
public class Solution_1770
{
    private int[][] _cache;
    private int[] _nums;
    private int[] _multipliers;
    private int _n;
    private int _m;

    public int MaximumScore(int[] nums, int[] multipliers)
    {
        _n = nums.Length;
        _m = multipliers.Length;
        _nums = nums;
        _multipliers = multipliers;

        _cache = new int[_m][];

        for (var i = 0; i < _m; i++)
        {
            _cache[i] = new int[_m];
        }

        return Dp(i: 0, left: 0);
    }

    private int Dp(int i, int left)
    {
        if (i == _m)
        {
            return 0;
        }

        var multiplier = _multipliers[i];
        var right = _n - 1 - (i - left);

        if (_cache[i][left] == 0)
        {
            var valueFromLeft = multiplier * _nums[left] + Dp(i + 1, left + 1);
            var valueFromRight = multiplier * _nums[right] + Dp(i + 1, left);

            _cache[i][left] = Math.Max(valueFromLeft, valueFromRight);
        }

        return _cache[i][left];
    }
}