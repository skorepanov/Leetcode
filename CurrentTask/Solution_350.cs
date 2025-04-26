// 350. Intersection of Two Arrays II
namespace CurrentTask;

#region Вариант 1 - Runtime 3 ms, Beats 31.09%
public class Solution_350_1
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var dictionary1 = NumsToDictionary(nums1);
        var dictionary2 = NumsToDictionary(nums2);

        var intersect = new List<int>();

        foreach (var pair1 in dictionary1)
        {
            var num = pair1.Key;

            if (!dictionary2.ContainsKey(num))
            {
                continue;
            }

            var intersectCount = Math.Min(pair1.Value, dictionary2[num]);

            var duplicates = Enumerable.Repeat(num, intersectCount).ToArray();
            intersect.AddRange(duplicates);
        }

        return intersect.ToArray();
    }

    private Dictionary<int, int> NumsToDictionary(int[] nums)
    {
        var dictionary = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (dictionary.ContainsKey(num))
            {
                dictionary[num]++;
            }
            else
            {
                dictionary.Add(num, 1);
            }
        }

        return dictionary;
    }
}
#endregion

#region Вариант 2 - Runtime 1 ms, Beats 96.73%
public class Solution_350_2
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return Intersect(nums2, nums1);
        }

        var dictionary1 = new Dictionary<int, int>();

        foreach (var num1 in nums1)
        {
            if (dictionary1.ContainsKey(num1))
            {
                dictionary1[num1]++;
            }
            else
            {
                dictionary1.Add(num1, 1);
            }
        }

        var intersect = new List<int>();

        foreach (var num2 in nums2)
        {
            if (dictionary1.ContainsKey(num2) && dictionary1[num2] > 0)
            {
                intersect.Add(num2);
                dictionary1[num2]--;
            }
        }

        return intersect.ToArray();
    }
}
#endregion