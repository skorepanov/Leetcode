// 11. Container With Most Water
public class Solution_11
{
    public int MaxArea(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;
        var maxVolume = 0;

        while (left < right)
        {
            if (height[left] == 0)
            {
                left++;
                continue;
            }

            if (height[right] == 0)
            {
                right--;
                continue;
            }

            var currentHeight = Math.Min(height[left], height[right]);
            var currentVolume = currentHeight * (right - left);

            if (currentVolume > maxVolume)
            {
                maxVolume = currentVolume;
            }

            if (height[left] <= height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxVolume;
    }
}