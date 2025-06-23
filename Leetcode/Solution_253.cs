// 253. Meeting Rooms II

#region Solution 1 - Time Limit Excedeed
public class Solution_253_1
{
    public int MinMeetingRooms(int[][] intervals)
    {
        var roomByTimeRequired = new Dictionary<int, int>();

        foreach (var interval in intervals)
        {
            for (var i = interval[0]; i < interval[1]; i++)
            {
                if (!roomByTimeRequired.ContainsKey(i))
                {
                    roomByTimeRequired.Add(i, 0);
                }

                roomByTimeRequired[i]++;
            }
        }

        return roomByTimeRequired.Values.Max();
    }
}
#endregion

#region Solution 2 - Runtime 13 ms, Beats 24.73%
public class Solution_253_2
{
    public int MinMeetingRooms(int[][] intervals)
    {
        if (intervals.Length == 1)
        {
            return 1;
        }

        var sortedIntervals = intervals.OrderBy(interval => interval[0]).ToArray();

        var requiredRoomCount = 0;
        var endIntervals = new PriorityQueue<int, int>();

        foreach (var interval in sortedIntervals)
        {
            var start = interval[0];
            var end = interval[1];

            endIntervals.Enqueue(end, end);

            while (endIntervals.Peek() <= start)
            {
                endIntervals.Dequeue();
            }

            requiredRoomCount = Math.Max(requiredRoomCount, endIntervals.Count);
        }

        return requiredRoomCount;
    }
}
#endregion
