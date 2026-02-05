// 1472. Design Browser History

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */

public class BrowserHistory
{
    private readonly Stack<string> _backUrls = new();
    private readonly Stack<string> _forwardUrls = new();

    public BrowserHistory(string homepage)
    {
        _backUrls.Push(homepage);
    }

    public void Visit(string url)
    {
        _backUrls.Push(url);
        _forwardUrls.Clear();
    }

    public string Back(int steps)
    {
        while (_backUrls.Count > 1 && steps > 0)
        {
            var url = _backUrls.Pop();
            _forwardUrls.Push(url);
            steps--;
        }

        return _backUrls.Peek();
    }

    public string Forward(int steps)
    {
        while (_forwardUrls.Count > 0 && steps > 0)
        {
            var url = _forwardUrls.Pop();
            _backUrls.Push(url);
            steps--;
        }

        return _backUrls.Peek();
    }
}