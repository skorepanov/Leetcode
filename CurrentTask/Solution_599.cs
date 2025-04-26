// 599. Minimum Index Sum of Two Lists
namespace CurrentTask;

#region Вариант 1 - Runtime 18 ms, Beats 35.80%
public class Solution_599_1
{
    public string[] FindRestaurant(string[] list1, string[] list2)
    {
        var indexSumsToStrings = new Dictionary<int, List<string>>();
        var secondStringHashSet = new HashSet<string>(list2);

        for (var i = 0; i < list1.Length; i++)
        {
            if (!secondStringHashSet.Contains(list1[i]))
            {
                continue;
            }

            for (var j = 0; j < list2.Length; j++)
            {
                if (list1[i] != list2[j])
                {
                    continue;
                }

                var indexSum = i + j;

                if (indexSumsToStrings.ContainsKey(indexSum))
                {
                    indexSumsToStrings[indexSum].Add(list1[i]);
                }
                else
                {
                    indexSumsToStrings.Add(indexSum, [list1[i]]);
                }
            }
        }

        var stringsWithMinIndexSum = indexSumsToStrings
            .MinBy(pair => pair.Key)
            .Value
            .ToArray();

        return stringsWithMinIndexSum;
    }
}
#endregion

#region Вариант 2 - Runtime 8 ms, Beats 59.39%
public class Solution_599_2
{
    public string[] FindRestaurant(string[] list1, string[] list2)
    {
        var secondStringHashSet = new HashSet<string>(list2);
        var minIndexSum = int.MaxValue;
        var stringsWithMinSum = new List<string>();

        for (var i = 0; i < list1.Length; i++)
        {
            if (!secondStringHashSet.Contains(list1[i]))
            {
                continue;
            }

            for (var j = 0; j < list2.Length; j++)
            {
                var indexSum = i + j;

                if (indexSum > minIndexSum)
                {
                    break;
                }

                if (list1[i] != list2[j])
                {
                    continue;
                }

                if (indexSum == minIndexSum)
                {
                    stringsWithMinSum.Add(list1[i]);
                }
                else
                {
                    minIndexSum = indexSum;
                    stringsWithMinSum = [list1[i]];
                }
            }
        }

        return stringsWithMinSum.ToArray();
    }
}
#endregion

#region Вариант 3 - Runtime 5 ms, Beats 98.30%
public class Solution_599_3
{
    public string[] FindRestaurant(string[] list1, string[] list2)
    {
        var minIndexSum = int.MaxValue;
        var stringsWithMinSum = new List<string>();

        var secondStringToIndexPairs = new Dictionary<string, int>();

        for (var i = 0; i < list2.Length; i++)
        {
            secondStringToIndexPairs.Add(list2[i], i);
        }

        for (var i = 0; i < list1.Length; i++)
        {
            if (i > minIndexSum)
            {
                break;
            }

            if (!secondStringToIndexPairs.ContainsKey(list1[i]))
            {
                continue;
            }

            var j = secondStringToIndexPairs[list1[i]];

            var indexSum = i + j;

            if (indexSum > minIndexSum)
            {
                break;
            }

            if (indexSum == minIndexSum)
            {
                stringsWithMinSum.Add(list1[i]);
            }
            else
            {
                minIndexSum = indexSum;
                stringsWithMinSum = [list1[i]];
            }
        }

        return stringsWithMinSum.ToArray();
    }
}
#endregion