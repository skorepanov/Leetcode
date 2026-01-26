// 1335. Minimum Difficulty of a Job Schedule
public class Solution_1335
{
    private int _totalJobCount;
    private int _totalDayCount;
    private int[][] _cache;
    private int[] _jobDifficulty;
    private int[] _hardestJobRemaining;

    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        if (jobDifficulty.Length < d)
        {
            return -1;
        }

        _totalDayCount = d;
        _totalJobCount = jobDifficulty.Length;
        _jobDifficulty = jobDifficulty;

        FillHardestJobRemaining();
        InitializeCache();

        return Dp(i: 0, day: 1);
    }

    private void FillHardestJobRemaining()
    {
        _hardestJobRemaining = new int[_totalJobCount];
        var hardestJob = 0;

        for (var i = _totalJobCount - 1; i >= 0; i--)
        {
            hardestJob = Math.Max(hardestJob, _jobDifficulty[i]);
            _hardestJobRemaining[i] = hardestJob;
        }
    }

    private void InitializeCache()
    {
        _cache = new int[_totalJobCount][];

        for (var i = 0; i < _totalJobCount; i++)
        {
            _cache[i] = new int[_totalDayCount + 1];
            Array.Fill(_cache[i], value: -1);
        }
    }

    private int Dp(int i, int day)
    {
        // base case, it's the last day so we need to finish all the jobs
        if (day == _totalDayCount)
        {
            return _hardestJobRemaining[i];
        }

        if (_cache[i][day] != -1)
        {
            return _cache[i][day];
        }

        var best = int.MaxValue;
        var hardest = 0;

        // iterate through the options and choose the best
        for (var j = i; j < _totalJobCount - (_totalDayCount - day); j++)
        {
            hardest = Math.Max(hardest, _jobDifficulty[j]);

            // recurrence relation
            best = Math.Min(best, hardest + Dp(j + 1, day + 1));
        }

        _cache[i][day] = best;

        return _cache[i][day];
    }
}