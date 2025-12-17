// 210. Course Schedule II
public class Solution_210
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var graph = GetGraph(numCourses, prerequisites);
        var coursesWithoutPrerequisites = GetCoursesWithoutPrerequisites(graph);

        if (coursesWithoutPrerequisites.Length == 0)
        {
            return [];
        }

        var pendingCourses = new Queue<int>();

        foreach (var course in coursesWithoutPrerequisites)
        {
            graph.Remove(course);
            pendingCourses.Enqueue(course);
        }

        var orderedCourses = new List<int>();

        while (pendingCourses.Count > 0)
        {
            var currentCourse = pendingCourses.Dequeue();
            orderedCourses.Add(currentCourse);

            RemovePrerequisite(currentCourse, graph);

            coursesWithoutPrerequisites = GetCoursesWithoutPrerequisites(graph);

            foreach (var course in coursesWithoutPrerequisites)
            {
                graph.Remove(course);
                pendingCourses.Enqueue(course);
            }
        }

        return orderedCourses.Count == numCourses
            ? orderedCourses.ToArray()
            : [];
    }

    private Dictionary<int, HashSet<int>> GetGraph(int numCourses, int[][] prerequisites)
    {
        var graph = Enumerable
            .Range(start: 0, count: numCourses)
            .ToDictionary(v => v, _ => new HashSet<int>());

        foreach (var prerequisite in prerequisites)
        {
            var courseTo = prerequisite[0];
            var courseFrom = prerequisite[1];

            graph[courseTo].Add(courseFrom);
        }

        return graph;
    }

    private void RemovePrerequisite(int course, Dictionary<int, HashSet<int>> prerequisites)
    {
        foreach (var prerequisite in prerequisites)
        {
            if (prerequisite.Value.Contains(course))
            {
                prerequisite.Value.Remove(course);
            }
        }
    }

    private int[] GetCoursesWithoutPrerequisites(Dictionary<int, HashSet<int>> graph)
    {
        return graph
            .Where(p => p.Value.Count == 0)
            .Select(p => p.Key)
            .ToArray();
    }
}