// 718. Maximum Length of Repeated Subarray
public class Solution_718
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        var cache = new int[nums1.Length + 1, nums2.Length + 1];

        var answer = 0;

        for (var i1 = nums1.Length - 1; i1 >= 0; i1--)
        {
            for (var i2 = nums2.Length - 1; i2 >= 0; i2--)
            {
                if (nums1[i1] != nums2[i2])
                {
                    continue;
                }

                cache[i1, i2] = cache[i1 + 1, i2 + 1] + 1;

                answer = Math.Max(answer, cache[i1, i2]);
            }
        }

        return answer;
    }
}