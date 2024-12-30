// // 412. Fizz Buzz
// public class Solution
// {
//     public IList<string> FizzBuzz(int n)
//     {
//         var answers = new List<string>();
//
//         for (var i = 1; i <= n; i++)
//         {
//             var isDivisibleBy3 = i % 3 == 0;
//             var isDivisibleBy5 = i % 5 == 0;
//
//             if (isDivisibleBy3 && isDivisibleBy5)
//             {
//                 answers.Add("FizzBuzz");
//             }
//             else if (isDivisibleBy3)
//             {
//                 answers.Add("Fizz");
//             }
//             else if (isDivisibleBy5)
//             {
//                 answers.Add("Buzz");
//             }
//             else
//             {
//                 answers.Add(i.ToString());
//             }
//         }
//
//         return answers;
//     }
// }
