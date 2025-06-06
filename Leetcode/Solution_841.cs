// 841. Keys and Rooms
public class Solution_841
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        var visitedRooms = new HashSet<int>();
        visitedRooms.Add(0);

        var pendingRooms = new Queue<int>();
        pendingRooms.Enqueue(0);

        while (pendingRooms.Count > 0)
        {
            var room = pendingRooms.Dequeue();
            var newRooms = rooms.ElementAt(room);

            foreach (var newRoom in newRooms)
            {
                if (visitedRooms.Contains(newRoom))
                {
                    continue;
                }

                visitedRooms.Add(newRoom);
                pendingRooms.Enqueue(newRoom);
            }
        }

        return visitedRooms.Count == rooms.Count;
    }
}
