// 412. Fizz Buzz
public class Solution_412
{
    public IList<string> FizzBuzz(int n)
    {
        var answers = new string[n];

        for (var i = 1; i <= n; i++)
        {
            var isDivisibleBy3 = i % 3 == 0;
            var isDivisibleBy5 = i % 5 == 0;

            if (isDivisibleBy3 && isDivisibleBy5)
            {
                answers[i - 1] = "FizzBuzz";
            }
            else if (isDivisibleBy3)
            {
                answers[i - 1] = "Fizz";
            }
            else if (isDivisibleBy5)
            {
                answers[i - 1] = "Buzz";
            }
            else
            {
                answers[i - 1] = i.ToString();
            }
        }

        return answers;
    }
}
