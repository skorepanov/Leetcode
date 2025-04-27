// 359. Logger Rate Limiter
namespace CurrentTask;

/*
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */

#region Вариант 1 - Runtime 3 ms, Beats 64.66%
public class Logger_359_1
{
    private readonly Dictionary<string, int> _messageToTimestampPairs;

    public Logger_359_1()
    {
        _messageToTimestampPairs = new ();
    }

    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (!_messageToTimestampPairs.ContainsKey(message))
        {
            _messageToTimestampPairs.Add(message, timestamp);
            return true;
        }

        if (_messageToTimestampPairs[message] + 10 <= timestamp)
        {
            _messageToTimestampPairs[message] = timestamp;
            return true;
        }

        return false;
    }
}
#endregion

#region Вариант 2 - Runtime 31 ms, Beats 7.52%
public class Logger_359_2
{
    private readonly Dictionary<string, int> _messageToTimestampPairs;

    public Logger_359_2()
    {
        _messageToTimestampPairs = new ();
    }

    public bool ShouldPrintMessage(int timestamp, string message)
    {
        var messagesToRemove = _messageToTimestampPairs
            .Where(p => p.Value + 10 < timestamp)
            .Select(p => p.Key)
            .ToList();

        messagesToRemove.ForEach(p => _messageToTimestampPairs.Remove(p));


        if (!_messageToTimestampPairs.ContainsKey(message))
        {
            _messageToTimestampPairs.Add(message, timestamp);
            return true;
        }

        if (_messageToTimestampPairs[message] + 10 <= timestamp)
        {
            _messageToTimestampPairs[message] = timestamp;
            return true;
        }

        return false;
    }
}
#endregion
