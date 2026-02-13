// 204. Count Primes
public class Solution_204
{
    /// <summary>
    /// Sieve of Eratosthenes
    /// </summary>
    public int CountPrimes(int n)
    {
        if (n <= 2)
        {
            return 0;
        }

        var compounds = new bool[n];

        compounds[0] = true;
        compounds[1] = true;

        for (var i = 2; i < n; i++)
        {
            if (compounds[i])
            {
                continue;
            }

            for (var j = 2; i * j < n; j++)
            {
                compounds[i * j] = true;
            }
        }

        return compounds.Count(p => !p);
    }
}