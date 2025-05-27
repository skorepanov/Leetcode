// 119. Pascal's Triangle II
public class Solution_119
{
    public IList<int> GetRow(int rowIndex)
    {
        if (rowIndex == 0)
        {
            return new List<int> { 1 };
        }

        if (rowIndex == 1)
        {
            return new List<int> { 1, 1 };
        }

        if (rowIndex == 2)
        {
            return new List<int> { 1, 2, 1 };
        }

        var halfRow = new List<int> { 1, 2 };

        for (var i = 3; i <= rowIndex; i++)
        {
            var left = halfRow[0];
            var right = halfRow[1];

            for (var j = 1; j < halfRow.Count; j++)
            {
                halfRow[j] = left + right;

                left = right;
                right = j < halfRow.Count - 1 ? halfRow[j + 1] : 0;
            }

            if (i % 2 == 0)
            {
                halfRow.Add(left * 2);
            }
        }

        var resultRow = new List<int>();

        foreach (var row in halfRow)
        {
            resultRow.Add(row);
        }

        if (rowIndex % 2 != 0)
        {
            resultRow.Add(halfRow[^1]);
        }

        for (var i = halfRow.Count - 2; i >= 0; i--)
        {
            resultRow.Add(halfRow[i]);
        }

        return resultRow;
    }
}