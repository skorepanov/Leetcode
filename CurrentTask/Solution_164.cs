// 164. Maximum Gap
namespace CurrentTask;

public class Solution_164
{
    private const int NUM_DIGITS = 10;

    public int MaximumGap(int[] nums)
    {
        if (nums.Length < 2)
        {
            return 0;
        }

        var sortedNums = RadixSortByLsd(nums);

        var maxDiff = int.MinValue;

        for (var i = 1; i < sortedNums.Length; i++)
        {
            var currentDiff = Math.Abs(sortedNums[i] - sortedNums[i - 1]);
            maxDiff = Math.Max(maxDiff, currentDiff);
        }

        return maxDiff;
    }

    private int[] RadixSortByLsd(int[] array)
    {
        var maxElement = array.Max();
        var placeVal = 1;

        while (maxElement / placeVal > 0)
        {
            array = CountingSort(array, placeVal);
            placeVal *= 10;
        }

        return array;
    }

    // Используется сортировка подсчётом (простая)
    private int[] CountingSort(int[] array, int placeVal)
    {
        // создать и заполнить массив counts
        var counts = new int[NUM_DIGITS];

        foreach (var element in array)
        {
            var current = element / placeVal;
            counts[current % NUM_DIGITS]++;
        }

        // переписать массив counts начальным индексом каждого элемента
        // для итогового отсортированного массива
        var startingIndex = 0;

        for (var i = 0; i < counts.Length; i++)
        {
            var count = counts[i];
            counts[i] = startingIndex;
            startingIndex += count;
        }

        // заполнить итоговый отсортированный массив
        var sortedArray = new int[array.Length];

        foreach (var element in array)
        {
            var current = element / placeVal;
            sortedArray[counts[current % NUM_DIGITS]] = element;
            counts[current % NUM_DIGITS]++;
        }

        return sortedArray;
    }
}