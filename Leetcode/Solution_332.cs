// 332. Reconstruct Itinerary
public class Solution_332
{
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        var nodesToVisit = GetNodesToVisit(tickets);
        var smallestItinerary = new LinkedList<string>();

        FindItinerary(currentNode: "JFK", nodesToVisit, smallestItinerary);

        return smallestItinerary.ToList();
    }

    private void FindItinerary(
        string currentNode,
        Dictionary<string, PriorityQueue<string, string>> nodesToVisit,
        LinkedList<string> smallestItinerary)
    {
        if (nodesToVisit.ContainsKey(currentNode))
        {
            var adjacentNodes = nodesToVisit[currentNode];

            while (adjacentNodes.Count > 0)
            {
                var nodeTo = adjacentNodes.Dequeue();
                FindItinerary(nodeTo, nodesToVisit, smallestItinerary);
            }
        }

        smallestItinerary.AddFirst(currentNode);
    }

    private Dictionary<string, PriorityQueue<string, string>> GetNodesToVisit(
        IList<IList<string>> tickets)
    {
        var nodesToVisit = new Dictionary<string, PriorityQueue<string, string>>();

        foreach (var ticket in tickets)
        {
            var nodeFrom = ticket[0];
            var nodeTo = ticket[1];

            if (!nodesToVisit.ContainsKey(nodeFrom))
            {
                nodesToVisit.Add(nodeFrom, new PriorityQueue<string, string>());
            }

            nodesToVisit[nodeFrom].Enqueue(nodeTo, nodeTo);
        }

        return nodesToVisit;
    }
}