// 238. Product of Array Except Self
public class Solution_238
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var prefixProducts = new int[nums.Length];
        prefixProducts[0] = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            prefixProducts[i] = prefixProducts[i - 1] * nums[i - 1];
        }

        var suffixProducts = new int[nums.Length];
        suffixProducts[^1] = 1;

        for (var i = nums.Length - 2; i >= 0; i--)
        {
            suffixProducts[i] = suffixProducts[i + 1] * nums[i + 1];
        }

        var productsExpectSelf = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            productsExpectSelf[i] = prefixProducts[i] * suffixProducts[i];
        }

        return productsExpectSelf;
    }
}