// // 151. Reverse Words in a String
// namespace CurrentTask;
//
// public class Solution
// {
//     public string ReverseWords(string s)
//     {
//         var words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
//         var inverted = words.Select(w => w.Trim()).Reverse().ToList();
//         return string.Join(" ", inverted);
//
//
//         // other solution - too long
//         // var inverted = new StringBuilder();
//         // var currentWordLength = 0;
//         //
//         // for (var i = s.Length - 1; i >= 0; i--)
//         // {
//         //     if (s[i] == ' ')
//         //     {
//         //         if (currentWordLength == 0)
//         //         {
//         //             continue;
//         //         }
//         //
//         //         var currentWord = s.Substring(i + 1, currentWordLength);
//         //
//         //         if (inverted.Length > 0)
//         //         {
//         //             inverted.Append(' ');
//         //         }
//         //
//         //         inverted.Append($"{currentWord}");
//         //         currentWordLength = 0;
//         //     }
//         //     else
//         //     {
//         //         currentWordLength++;
//         //     }
//         // }
//         //
//         // if (s[0] != ' ')
//         // {
//         //     var currentWord = s.Substring(0, currentWordLength);
//         //
//         //     if (inverted.Length > 0)
//         //     {
//         //         inverted.Append(' ');
//         //     }
//         //
//         //     inverted.Append($"{currentWord}");
//         // }
//         //
//         // return inverted.ToString();
//     }
// }