// // 14. Longest Common Prefix
// using System.Text;
//
// namespace CurrentTask;
//
// public class Solution
// {
//     public string LongestCommonPrefix(string[] strs)
//     {
//         if (strs is null || strs.Length == 0 || string.IsNullOrEmpty(strs[0]))
//         {
//             return string.Empty;
//         }
//
//         var prefix = new StringBuilder();
//
//         for (var i = 0; i < strs[0].Length; i++)
//         {
//             foreach (var str in strs)
//             {
//                 if (str.Length <= i || strs[0][i] != str[i])
//                 {
//                     return prefix.ToString();
//                 }
//             }
//
//             prefix.Append(strs[0][i]);
//         }
//
//         return prefix.ToString();
//     }
// }