// 1136. Parallel Courses
public class Solution_1136
{
    public int MinimumSemesters(int n, int[][] relations)
    {
        var graph = GetGraph(n, relations);
        var coursesWithoutPrerequisites = GetCoursesWithoutPrerequisites(graph);

        if (coursesWithoutPrerequisites.Length == 0)
        {
            return -1;
        }

        var pendingCourses = new Queue<int>();

        foreach (var course in coursesWithoutPrerequisites)
        {
            graph.Remove(course);
            pendingCourses.Enqueue(course);
        }

        var semesterCount = 0;
        var visitedCourseCount = 0;

        while (pendingCourses.Count > 0)
        {
            semesterCount++;
            var courseInSemesterCount = pendingCourses.Count;

            for (var i = 0; i < courseInSemesterCount; i++)
            {
                var currentCourse = pendingCourses.Dequeue();
                visitedCourseCount++;

                RemovePrerequisite(currentCourse, graph);

                coursesWithoutPrerequisites = GetCoursesWithoutPrerequisites(graph);

                foreach (var course in coursesWithoutPrerequisites)
                {
                    graph.Remove(course);
                    pendingCourses.Enqueue(course);
                }
            }
        }

        return visitedCourseCount == n
            ? semesterCount
            : -1;
    }

    private Dictionary<int, HashSet<int>> GetGraph(int numCourses, int[][] prerequisites)
    {
        var graph = Enumerable
            .Range(start: 1, count: numCourses)
            .ToDictionary(v => v, _ => new HashSet<int>());

        foreach (var prerequisite in prerequisites)
        {
            var courseFrom = prerequisite[0];
            var courseTo = prerequisite[1];

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