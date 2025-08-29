// 119. Pascal's Triangle II

#region Вариант 1 - Итеративно - Runtime 14 ms, Beats 4.06%
public class Solution_119_1
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
#endregion

#region Вариант 2 - Рекурсивно - Runtime 4 ms, Beats 4.64%
public class Solution_119_2
{
    private Dictionary<(int, int), int> _triangle;

    public IList<int> GetRow(int rowIndex)
    {
        _triangle = new Dictionary<(int, int), int>();

        var row = new List<int>();

        for (var i = 0; i <= rowIndex; i++)
        {
            var cell = GetCellValue(rowIndex, i);
            row.Add(cell);
        }

        return row;
    }

    private int GetCellValue(int rowIndex, int cellIndex)
    {
        if (rowIndex == 0 || cellIndex == 0 || cellIndex == rowIndex)
        {
            return 1;
        }

        if (_triangle.ContainsKey((rowIndex, cellIndex)))
        {
            return _triangle[(rowIndex, cellIndex)];
        }

        var value = GetCellValue(rowIndex - 1, cellIndex - 1)
                  + GetCellValue(rowIndex - 1, cellIndex);

        _triangle.Add((rowIndex, cellIndex), value);
        return value;
    }
}
#endregion
