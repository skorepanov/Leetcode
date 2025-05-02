// 454. 4Sum II
namespace CurrentTask;

#region Вариант 1 - Runtime 131 ms, Beats 6.19%
public class Solution_454_1
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var fourSumCount = 0;

        var num1AndNum2SumToCountPairs = GetSumOfTwoArrays(nums1, nums2);
        var num3AndNum4SumToCountPairs = GetSumOfTwoArrays(nums3, nums4);

        foreach (var num1AndNum2SumToCountPair in num1AndNum2SumToCountPairs)
        {
            var complement = 0 - num1AndNum2SumToCountPair.Key;

            if (!num3AndNum4SumToCountPairs.ContainsKey(complement))
            {
                continue;
            }

            var countInNum1AndNum2 = num1AndNum2SumToCountPair.Value;
            var countInNum3AndNum4 = num3AndNum4SumToCountPairs[complement];

            fourSumCount += countInNum1AndNum2 * countInNum3AndNum4;
        }

        return fourSumCount;
    }

    private Dictionary<int, int> GetSumOfTwoArrays(int[] nums1, int[] nums2)
    {
        var sumToCountPairs = new Dictionary<int, int>();

        for (var i = 0; i < nums1.Length; i++)
        {
            for (var j = 0; j < nums2.Length; j++)
            {
                var sum = nums1[i] + nums2[j];

                if (!sumToCountPairs.ContainsKey(sum))
                {
                    sumToCountPairs.Add(sum, 0);
                }

                sumToCountPairs[sum]++;
            }
        }

        return sumToCountPairs;
    }
}
#endregion

#region Вариант 2 - Runtime 107 ms, Beats 19.59%
public class Solution_454_2
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var num1AndNum2SumToCountPairs = new Dictionary<int, int>();

        for (var i = 0; i < nums1.Length; i++)
        {
            for (var j = 0; j < nums2.Length; j++)
            {
                var sum = nums1[i] + nums2[j];

                if (!num1AndNum2SumToCountPairs.ContainsKey(sum))
                {
                    num1AndNum2SumToCountPairs.Add(sum, 0);
                }

                num1AndNum2SumToCountPairs[sum]++;
            }
        }

        var sumToCountPairs = 0;

        for (var k = 0; k < nums3.Length; k++)
        {
            for (var l = 0; l < nums4.Length; l++)
            {
                var sum = nums3[k] + nums4[l];

                if (num1AndNum2SumToCountPairs.ContainsKey(-sum))
                {
                    sumToCountPairs += num1AndNum2SumToCountPairs[-sum];
                }
            }
        }

        return sumToCountPairs;
    }
}
#endregion