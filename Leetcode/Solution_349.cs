// 349. Intersection of Two Arrays
#region 1 вариант - Intersect & Distinct - Runtime 5ms, Beats 31.81%
public class Solution_349_1
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var duplicates = nums1.Intersect(nums2).Distinct().ToArray();
        return duplicates;
    }
}
#endregion

#region 2 вариант - Два hashSets - Runtime 7ms, Beats 10.85%
public class Solution_349_2
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var hashSet1 = new HashSet<int>(nums1);
        var hashSet2 = new HashSet<int>(nums2);
        var duplicates = hashSet1.Intersect(hashSet2).ToArray();
        return duplicates;
    }
}
#endregion

#region 3 вариант- Без Intersect - Runtime 4ms, Beats 61.53%
public class Solution_349_3
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var hashSet1 = new HashSet<int>(nums1);
        var duplicates = new HashSet<int>();

        foreach (var num in nums2)
        {
            if (hashSet1.Contains(num))
            {
                duplicates.Add(num);
            }
        }

        return duplicates.ToArray();
    }
}
#endregion

#region 4 вариант - Binary Search - Runtime 140 ms, Beats 7.00%
public class Solution_349_4
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return Intersection(nums2, nums1);
        }

        var intersection = new HashSet<int>();
        var sortedNums2 = nums2.Order().ToArray();

        foreach (var num in nums1)
        {
            if (IsContains(num, sortedNums2))
            {
                intersection.Add(num);
            }
        }

        return intersection.ToArray();
    }

    private bool IsContains(int num, int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] == num)
            {
                return true;
            }

            if (nums[middle] > num)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return false;
    }
}
#endregion