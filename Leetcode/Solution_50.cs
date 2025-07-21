// 50. Pow(x, n)

#region Solution 1 - Runtime 4 ms, Beats 6.35%
public class Solution_50_1
{
    public double MyPow(double x, int n)
    {
        if (x == 0)
        {
            return 0;
        }

        if (x == 1 || n == 0)
        {
            return 1;
        }

        if (x == -1)
        {
            return n % 2 == 0 ? -x : x;
        }

        return n > 0
            ? GetPositivePow(x, n)
            : GetNegativePow(x, n);
    }

    private double GetPositivePow(double x, int n)
    {
        var pow = 1d;

        for (var i = 1; i <= n; i++)
        {
            pow *= x;

            if (Math.Abs(pow) < 0.00001)
            {
                return 0;
            }
        }

        return pow;
    }

    private double GetNegativePow(double x, int n)
    {
        var pow = 1d;

        for (var i = -1; i >= n; i--)
        {
            pow *= (1 / x);

            if (Math.Abs(pow) < 0.00001)
            {
                return 0;
            }
        }

        return pow;
    }
}
#endregion

#region Solution 2 - Binary Exponentiation (Iterative) - Runtime 0 ms, Beats 100.00%
public class Solution_50_2
{
    public double MyPow(double x, int n)
    {
        return BinaryExpression(x, n);
    }

    private double BinaryExpression(double x, long n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (n < 0)
        {
            n = -1 * n;
            x = 1 / x;
        }

        var result = 1d;

        while (n != 0)
        {
            if (n % 2 == 1)
            {
                // x^n => x*x^(n-1)
                result *= x;
                n--;
            }

            // x^n => (x^2)^(n/2)
            x *= x;
            n /= 2;
        }

        return result;
    }
}
#endregion
