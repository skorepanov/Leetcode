// 269. Alien Dictionary
public class Solution_269
{
    public string AlienOrder(string[] words)
    {
        // key: letter, values: prerequisites
        var (graph, isOk) = GetGraph(words);

        if (!isOk)
        {
            return string.Empty;
        }

        var letterCount = graph.Count;

        var lettersWithoutPrerequisites = GetLettersWithoutPrerequisites(graph);

        if (lettersWithoutPrerequisites.Length == 0)
        {
            return string.Empty;
        }

        var pendingLetters = new Queue<char>();

        foreach (var letter in lettersWithoutPrerequisites)
        {
            graph.Remove(letter);
            pendingLetters.Enqueue(letter);
        }

        var orderedLetters = new List<char>();

        while (pendingLetters.Count > 0)
        {
            var currentLetter = pendingLetters.Dequeue();
            orderedLetters.Add(currentLetter);

            RemovePrerequisite(currentLetter, graph);

            lettersWithoutPrerequisites = GetLettersWithoutPrerequisites(graph);

            foreach (var letter in lettersWithoutPrerequisites)
            {
                graph.Remove(letter);
                pendingLetters.Enqueue(letter);
            }
        }

        return orderedLetters.Count == letterCount
            ? string.Join(string.Empty, orderedLetters)
            : string.Empty;
    }

    private (Dictionary<char, HashSet<char>>, bool) GetGraph(string[] words)
    {
        var graph = new Dictionary<char, HashSet<char>>();

        foreach (var letter in words[0])
        {
            if (!graph.ContainsKey(letter))
            {
                graph.Add(letter, []);
            }
        }

        for (var i = 1; i < words.Length; i++)
        {
            var previousWord = words[i - 1];
            var currentWord = words[i];

            var letterIndex = 0;

            while (previousWord.Length > letterIndex
                && currentWord.Length > letterIndex
                && previousWord[letterIndex] == currentWord[letterIndex])
            {
                if (!graph.ContainsKey(previousWord[letterIndex]))
                {
                    graph.Add(previousWord[letterIndex], []);
                }

                letterIndex++;
            }

            if (previousWord.Length > letterIndex && currentWord.Length == letterIndex)
            {
                return (null, false);
            }

            if (previousWord.Length > letterIndex && currentWord.Length > letterIndex)
            {
                if (!graph.ContainsKey(currentWord[letterIndex]))
                {
                    graph.Add(currentWord[letterIndex], []);
                }

                graph[currentWord[letterIndex]].Add(previousWord[letterIndex]);
                letterIndex++;
            }

            for (var j = letterIndex; j < previousWord.Length; j++)
            {
                if (!graph.ContainsKey(previousWord[j]))
                {
                    graph.Add(previousWord[j], []);
                }
            }

            for (var j = letterIndex; j < currentWord.Length; j++)
            {
                if (!graph.ContainsKey(currentWord[j]))
                {
                    graph.Add(currentWord[j], []);
                }
            }
        }

        return (graph, true);
    }

    private void RemovePrerequisite(
        char letter,
        Dictionary<char, HashSet<char>> prerequisites)
    {
        foreach (var prerequisite in prerequisites)
        {
            if (prerequisite.Value.Contains(letter))
            {
                prerequisite.Value.Remove(letter);
            }
        }
    }

    private char[] GetLettersWithoutPrerequisites(Dictionary<char, HashSet<char>> graph)
    {
        return graph
            .Where(p => p.Value.Count == 0)
            .Select(p => p.Key)
            .ToArray();
    }
}