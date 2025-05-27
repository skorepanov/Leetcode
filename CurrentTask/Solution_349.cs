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

#region 2 вариант - два hashSets - Runtime 7ms, Beats 10.85%
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

#region 3 вариант- без Intersect - Runtime 4ms, Beats 61.53%
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