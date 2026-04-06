// 151. Reverse Words in a String
public class Solution_151
{
    public string ReverseWords(string s)
    {
        var words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var invertedWords = words.Reverse().ToList();
        return string.Join(" ", invertedWords);
    }
}