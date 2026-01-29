// 1155. Number of Dice Rolls With Target Sum
public class Solution_1155
{
    private int _diceCount;
    private int _faceCount;
    private int _target;
    private const int MODULO = 1000000007;
    private int[][] _cache;

    public int NumRollsToTarget(int n, int k, int target)
    {
        _diceCount = n;
        _faceCount = k;
        _target = target;

        _cache = new int[n + 1][];

        for (var i = 0; i < _cache.Length; i++)
        {
            _cache[i] = new int[target + 1];
            Array.Fill(_cache[i], value: -1);
        }

        return Dp(dice: 0, currentSum: 0);
    }

    private int Dp(int dice, int currentSum)
    {
        if (dice == _diceCount)
        {
            return currentSum == _target
                ? 1
                : 0;
        }

        if (_cache[dice][currentSum] != -1)
        {
            return _cache[dice][currentSum];
        }

        var ways = 0;
        var maxFace = Math.Min(_faceCount, _target - currentSum);

        for (var face = 1; face <= maxFace; face++)
        {
            ways = (ways + Dp(dice + 1, currentSum + face)) % MODULO;
        }

        _cache[dice][currentSum] = ways;

        return _cache[dice][currentSum];
    }
}