// 88. Merge Sorted Array
public class Solution_88
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (nums2.Length == 0)
        {
            return;
        }

        var k = 0;
        var currentNums1Length = m;

        for (var i = 0; i < nums1.Length; i++)
        {
            if (nums2[k] < nums1[i] || i >= currentNums1Length)
            {
                for (var right = nums1.Length - 1; right > i; right--)
                {
                    nums1[right] = nums1[right - 1];
                }

                nums1[i] = nums2[k];
                k++;
                currentNums1Length++;

                if (k >= nums2.Length)
                {
                    break;
                }
            }
        }
    }
}