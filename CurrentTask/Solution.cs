// 118. Pascal's Triangle
namespace CurrentTask;

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var triangle = new List<IList<int>>
        {
            new List<int> { 1 }
        };

        if (numRows == 1)
        {
            return triangle;
        }

        for (var i = 2; i <= numRows; i++)
        {
            var triangleRow = new List<int>
            {
                1
            };

            for (var k = 0; k < i - 2; k++)
            {
                var previousRow = triangle[i - 2];
                triangleRow.Add(previousRow[k] + previousRow[k + 1]);
            }

            triangleRow.Add(1);
            triangle.Add(triangleRow);
        }

        return triangle;
    }
}