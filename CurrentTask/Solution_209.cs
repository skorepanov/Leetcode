// // 209. Minimum Size Subarray Sum
// namespace CurrentTask;
//
// public class Solution
// {
//     public int MinSubArrayLen(int target, int[] nums)
//     {
//         var minLength = int.MaxValue;
//         var currentSum = 0;
//         var k = 0;
//
//         for (var i = 0; i < nums.Length; i++)
//         {
//             currentSum += nums[i];
//
//             while (currentSum >= target)
//             {
//                 if (i - k + 1 < minLength)
//                 {
//                     minLength = i - k + 1;
//                 }
//
//                 currentSum -= nums[k];
//                 k++;
//             }
//         }
//
//         return minLength == int.MaxValue ? 0 : minLength;
//     }
// }
