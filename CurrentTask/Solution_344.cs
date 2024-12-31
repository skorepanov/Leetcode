// // 344. Reverse String
// namespace CurrentTask;
//
// public class Solution
// {
//     public void ReverseString(char[] s)
//     {
//         var i = 0;
//         var k = s.Length - 1;
//
//         while (i < k)
//         {
//             (s[i], s[k]) = (s[k], s[i]);
//             i++;
//             k--;
//         }
//     }
// }