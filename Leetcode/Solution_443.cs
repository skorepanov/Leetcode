// 443. String Compression
public class Solution_443
{
    public int Compress(char[] chars)
    {
        var sourceIndex = 0;
        var compressedStringIndex = 0;

        while (sourceIndex < chars.Length)
        {
            var symbolCount = 1;

            while (sourceIndex + symbolCount < chars.Length
                && chars[sourceIndex + symbolCount] == chars[sourceIndex])
            {
                symbolCount++;
            }

            chars[compressedStringIndex] = chars[sourceIndex];
            compressedStringIndex++;

            if (symbolCount > 1)
            {
                foreach (var countPart in symbolCount.ToString())
                {
                    chars[compressedStringIndex] = countPart;
                    compressedStringIndex++;
                }
            }

            sourceIndex += symbolCount;
        }

        return compressedStringIndex;
    }
}