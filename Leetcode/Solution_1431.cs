// 1431. Kids With the Greatest Number of Candies
public class Solution_1431
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var maxCandyCount = candies.Max();

        var hasGreatestNumber = candies
            .Select(c => c + extraCandies >= maxCandyCount)
            .ToList();

        return hasGreatestNumber;
    }
}