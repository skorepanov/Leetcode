// 84. Largest Rectangle in Histogram

#region Вариант 1 - Итеративный - Слишком медленный, Runtime 2961 ms, Beats 5.08%
public class Solution_84_1
{
    public int LargestRectangleArea(int[] heights)
    {
        if (heights.Length == 1)
        {
            return heights[0];
        }

        var maxSum = heights.Max();

        if (heights.Length == 2)
        {
            maxSum = Math.Max(maxSum, Math.Min(heights[0], heights[1]) * 2);
            return maxSum;
        }

        for (var i = 0; i < heights.Length - 1; i++)
        {
            var maxHeightToSum = Math.Min(heights[i], heights[i + 1]);

            if (maxHeightToSum == 0)
            {
                continue;
            }

            var possibleMaxSum = maxHeightToSum * heights.Length;

            if (possibleMaxSum <= maxSum)
            {
                continue;
            }

            var currentSum = maxHeightToSum;

            for (var j = i - 1; j >= 0; j--)
            {
                if (heights[j] < maxHeightToSum)
                {
                    break;
                }

                currentSum += maxHeightToSum;
            }

            for (var j = i + 1; j < heights.Length; j++)
            {
                if (heights[j] < maxHeightToSum)
                {
                    break;
                }

                currentSum += maxHeightToSum;
            }

            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}
#endregion

#region Вариант 2 - Devide and Conquer - Слишком медленный
public class Solution_84_2
{
    public int LargestRectangleArea(int[] heights)
    {
        return CalculateArea(heights, start: 0, end: heights.Length - 1);
    }

    private int CalculateArea(int[] heights, int start, int end)
    {
        if (start > end)
        {
            return 0;
        }

        var minIndex = start;

        for (var i = start; i <= end; i++)
        {
            if (heights[minIndex] > heights[i])
            {
                minIndex = i;
            }
        }

        var areaByMinValue = heights[minIndex] * (end - start + 1);

        var leftArea = CalculateArea(heights, start, minIndex - 1);
        var rightArea = CalculateArea(heights, minIndex + 1, end);
        var maxLeftOrRightArea = Math.Max(leftArea, rightArea);

        return Math.Max(areaByMinValue, maxLeftOrRightArea);
    }
}
#endregion

#region Вариант 3 - Stack - Runtime 8 ms, Beats 84.02%
public class Solution_84_3
{
    public int LargestRectangleArea(int[] heights)
    {
        var indexStack = new Stack<int>();
        indexStack.Push(-1);
        var maxArea = 0;

        for (var i = 0; i < heights.Length; i++)
        {
            while (indexStack.Peek() != -1
                && heights[indexStack.Peek()] >= heights[i])
            {
                var currentHeight = heights[indexStack.Pop()];
                var currentWidth = i - indexStack.Peek() - 1;
                maxArea = Math.Max(maxArea, currentHeight * currentWidth);
            }

            indexStack.Push(i);
        }

        while (indexStack.Peek() != -1)
        {
            var currentHeight = heights[indexStack.Pop()];
            var currentWidth = heights.Length - indexStack.Peek() - 1;
            maxArea = Math.Max(maxArea, currentHeight * currentWidth);
        }

        return maxArea;
    }
}
#endregion
