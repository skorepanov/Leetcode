// 790. Domino and Tromino Tiling
public class Solution_790
{
    public int NumTilings(int n)
    {
        if (n <= 2)
        {
            return n;
        }

        const int MODULO = 1_000_000_007;

        // f[k]: number of ways to "fully cover a board" of width k
        var fully = new long[n + 1];
        fully[1] = 1;
        fully[2] = 2;

        // p[k]: number of ways to "partially cover a board" of width k
        var partially = new long[n + 1];
        partially[2] = 1;

        for (var k = 3; k < n + 1; k++)
        {
            fully[k] = (fully[k - 1] + fully[k - 2] + 2 * partially[k - 1]) % MODULO;
            partially[k] = (partially[k - 1] + fully[k - 2]) % MODULO;
        }

        return (int)fully[n];
    }
}