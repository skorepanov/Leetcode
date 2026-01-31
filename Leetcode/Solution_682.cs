// 682. Baseball Game
public class Solution_682
{
    public int CalPoints(string[] operations)
    {
        var record = new Stack<int>();

        foreach (var operation in operations)
        {
            switch (operation)
            {
                case "+":
                {
                    var number1 = record.Pop();
                    var number2 = record.Peek();

                    record.Push(number1);
                    record.Push(number1 + number2);
                    continue;
                }
                case "D":
                {
                    var prevNumber = record.Peek();
                    record.Push(prevNumber * 2);
                    continue;
                }
                case "C":
                    record.Pop();
                    continue;
                default:
                {
                    var newNumber = int.Parse(operation);
                    record.Push(newNumber);
                    break;
                }
            }
        }

        return record.Sum();
    }
}