// 288. Unique Word Abbreviation

/**
 * Your ValidWordAbbr object will be instantiated and called as such:
 * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
 * bool param_1 = obj.IsUnique(word);
 */

public class ValidWordAbbr_288
{
    private readonly Dictionary<string, HashSet<string>> _abbreviationToWordsPairs;

    public ValidWordAbbr_288(string[] dictionary)
    {
        _abbreviationToWordsPairs = new Dictionary<string, HashSet<string>>();

        foreach (var word in dictionary)
        {
            var abbreviation = GetAbbreviation(word);

            if (!_abbreviationToWordsPairs.ContainsKey(abbreviation))
            {
                _abbreviationToWordsPairs.Add(abbreviation, []);
            }

            _abbreviationToWordsPairs[abbreviation].Add(word);
        }
    }

    public bool IsUnique(string word)
    {
        var abbreviation = GetAbbreviation(word);

        if (!_abbreviationToWordsPairs.ContainsKey(abbreviation))
        {
            return true;
        }

        var wordsWithSameAbbreviations = _abbreviationToWordsPairs[abbreviation];

        if (wordsWithSameAbbreviations.Contains(word)
         && wordsWithSameAbbreviations.Count == 1)
        {
            return true;
        }

        return false;
    }

    private string GetAbbreviation(string word)
    {
        if (word.Length <= 2)
        {
            return word;
        }

        return word[0] + (word.Length - 2).ToString() + word[^1];
    }
}