// 557. Reverse Words in a String III
public class Solution_557
{
    public string ReverseWords(string s)
    {
        var words = s.Split(' ');

        var invertedWords = words
            .Select(w => new string(w.Reverse().ToArray()))
            .ToList();

        return string.Join(" ", invertedWords);
    }
}