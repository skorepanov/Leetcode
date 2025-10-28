// 17. Letter Combinations of a Phone Number
using System.Text;

public class Solution_17
{
    private readonly Dictionary<char, string> _numbersToLetters = new()
    {
        ['2'] = "abc",
        ['3'] = "def",
        ['4'] = "ghi",
        ['5'] = "jkl",
        ['6'] = "mno",
        ['7'] = "pqrs",
        ['8'] = "tuv",
        ['9'] = "wxyz"
    };

    public IList<string> LetterCombinations(string digits)
    {
        var currentCombinations = new StringBuilder();
        var allCombinations = new List<string>();

        FindCombinations(digits, currentIndex: 0, currentCombinations, allCombinations);

        return allCombinations;
    }

    private void FindCombinations(
        string digits,
        int currentIndex,
        StringBuilder currentCombination,
        List<string> allCombinations)
    {
        var letters = _numbersToLetters[digits[currentIndex]];

        foreach (var letter in letters)
        {
            currentCombination.Append(letter);

            if (currentCombination.Length == digits.Length)
            {
                allCombinations.Add(currentCombination.ToString());
            }
            else
            {
                for (var i = currentIndex + 1; i < digits.Length; i++)
                {
                    FindCombinations(digits, i, currentCombination, allCombinations);
                }
            }

            currentCombination.Remove(currentCombination.Length - 1, length: 1);
        }
    }
}