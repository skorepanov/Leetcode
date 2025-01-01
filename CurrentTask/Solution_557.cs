// // 557. Reverse Words in a String III
// namespace CurrentTask;
//
// public class Solution
// {
//     public string ReverseWords(string s)
//     {
//         var words = s.Split(' ');
//
//         var invertedWords = words
//             .Select(w => new string(w.Reverse().ToArray()))
//             .ToList();
//
//         return string.Join(" ", invertedWords);
//     }
// }