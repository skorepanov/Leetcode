// 13. Roman to Integer
public class Solution_13
{
    public int RomanToInt(string s)
    {
        var number = 0;

        for (var i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                // M = 1000
                case 'M':
                    number += 1000;
                    break;

                // D = 500
                case 'D':
                    number += 500;
                    break;

                // C = 100
                case 'C' when i + 1 < s.Length && s[i + 1] == 'D':
                    number += 400;
                    i++;
                    break;
                case 'C' when i + 1 < s.Length && s[i + 1] == 'M':
                    number += 900;
                    i++;
                    break;
                case 'C':
                    number += 100;
                    break;

                // L = 50
                case 'L':
                    number += 50;
                    break;

                // X = 10
                case 'X' when i + 1 < s.Length && s[i + 1] == 'L':
                    number += 40;
                    i++;
                    break;
                case 'X' when i + 1 < s.Length && s[i + 1] == 'C':
                    number += 90;
                    i++;
                    break;
                case 'X':
                    number += 10;
                    break;

                // V = 5
                case 'V':
                    number += 5;
                    break;

                // I = 1
                case 'I' when i + 1 < s.Length && s[i + 1] == 'V':
                    number += 4;
                    i++;
                    break;
                case 'I' when i + 1 < s.Length && s[i + 1] == 'X':
                    number += 9;
                    i++;
                    break;
                case 'I':
                    number += 1;
                    break;
            }
        }

        return number;
    }
}