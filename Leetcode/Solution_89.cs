// 89. Gray Code
public class Solution_89
{
    public IList<int> GrayCode(int n)
    {
        var grayCode = new List<int>();

        var sequenceLength = 1 << n;

        for (var i = 0; i < sequenceLength; i++)
        {
            var num = i ^ (i >> 1);
            grayCode.Add(num);
        }

        return grayCode;
    }
}