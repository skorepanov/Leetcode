// 150. Evaluate Reverse Polish Notation
public class Solution_150
{
    private Dictionary<string, Func<int, int, int>> _operators
        = new()
        {
            ["+"] = (a, b) => a + b,
            ["-"] = (a, b) => a - b,
            ["*"] = (a, b) => a * b,
            ["/"] = (a, b) => a / b,
        };

    public int EvalRPN(string[] tokens)
    {
        var results = new Stack<int>();

        int operand1, operand2;

        foreach (var token in tokens)
        {
            if (!_operators.ContainsKey(token))
            {
                results.Push(int.Parse(token));
                continue;
            }

            operand2 = results.Pop();
            operand1 = results.Pop();
            var result = _operators[token](operand1, operand2);
            results.Push(result);
        }

        return results.Pop();
    }
}