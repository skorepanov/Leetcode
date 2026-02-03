// 1491. Average Salary Excluding the Minimum and Maximum Salary

#region Вариант 1 - Built-in functions
// Runtime 8 ms, Beats 11.54%
// Memory 42.46 MB, Beats 7.69%
public class Solution_1491_1
{
    public double Average(int[] salary)
    {
        var sum = (double)(salary.Sum() - salary.Min() - salary.Max());

        return sum / (salary.Length - 2);
    }
}
#endregion

#region Вариант 2
// Runtime 0 ms, Beats 100.00%
// Memory 42.00 MB, Beats 30.77%
public class Solution_1491_2
{
    public double Average(int[] salary)
    {
        var sum = 0d;
        var min = int.MaxValue;
        var max = int.MinValue;

        foreach (var val in salary)
        {
            sum += val;

            if (val < min)
            {
                min = val;
            }

            if (val > max)
            {
                max = val;
            }
        }

        sum -= min;
        sum -= max;

        return sum / (salary.Length - 2);
    }
}
#endregion