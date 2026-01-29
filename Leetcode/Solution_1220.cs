// 1220. Count Vowels Permutation
public class Solution_1220
{
    public int CountVowelPermutation(int n)
    {
        const int MODULO = 1000000007;

        var prevCountA = 1L;
        var prevCountE = 1L;
        var prevCountI = 1L;
        var prevCountO = 1L;
        var prevCountU = 1L;

        for (var i = 1; i < n; i++)
        {
            var currCountA = (prevCountE + prevCountI + prevCountU) % MODULO;
            var currCountE = (prevCountA + prevCountI) % MODULO;
            var currCountI = (prevCountE + prevCountO) % MODULO;
            var currCountO = (prevCountI) % MODULO;
            var currCountU = (prevCountI + prevCountO) % MODULO;

            prevCountA = currCountA;
            prevCountE = currCountE;
            prevCountI = currCountI;
            prevCountO = currCountO;
            prevCountU = currCountU;
        }

        return (int)((prevCountA + prevCountE + prevCountI + prevCountO + prevCountU)
              % MODULO);
    }
}