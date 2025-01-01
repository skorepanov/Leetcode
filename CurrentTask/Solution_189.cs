// // 189. Rotate Array
// namespace CurrentTask;
//
// public class Solution
// {
//     public void Rotate(int[] nums, int k)
//     {
//         var length = nums.Length;
//         var normalizedK = k % length;
//
//         var rotatedNums = new int[length];
//         var indexOriginal = length - normalizedK;
//
//         for (var indexRotated = 0; indexRotated < length; indexRotated++)
//         {
//             if (indexOriginal == length)
//             {
//                 indexOriginal = 0;
//             }
//
//             if (indexRotated == length)
//             {
//                 indexRotated = 0;
//             }
//
//             rotatedNums[indexRotated] = nums[indexOriginal];
//
//             indexOriginal++;
//         }
//
//         for (var i = 0; i < length; i++)
//         {
//             nums[i] = rotatedNums[i];
//         }
//     }
// }