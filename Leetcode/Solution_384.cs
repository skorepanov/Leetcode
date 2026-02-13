// 384. Shuffle an Array

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */

public class Solution_384
{
    private int[] _originalNums;

    public Solution_384(int[] nums)
    {
        _originalNums = nums;
    }

    public int[] Reset()
    {
        return _originalNums;
    }

    public int[] Shuffle()
    {
        var shuffledNums = _originalNums.ToArray();
        Random.Shared.Shuffle(shuffledNums);
        return shuffledNums;
    }
}