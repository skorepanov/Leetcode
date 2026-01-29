// 983. Minimum Cost For Tickets
public class Solution_983
{
    private HashSet<int> _days;
    private int _maxDay;
    private int[] _costs;
    private int[] _cache;

    public int MincostTickets(int[] days, int[] costs)
    {
        _days = days.ToHashSet();
        _maxDay = days[^1];
        _costs = costs;

        _cache = new int[_maxDay + 1];

        return Dp(day: 1);
    }

    private int Dp(int day)
    {
        if (day > _maxDay)
        {
            return 0;
        }

        if (!_days.Contains(day))
        {
            return Dp(day + 1);
        }

        if (_cache[day] != 0)
        {
            return _cache[day];
        }

        var optionFor1Day = _costs[0] + Dp(day + 1);
        var optionFor7Day = _costs[1] + Dp(day + 7);
        var optionFor30Day = _costs[2] + Dp(day + 30);

        _cache[day] = new[]
        {
            optionFor1Day,
            optionFor7Day,
            optionFor30Day
        }.Min();

        return _cache[day];
    }
}