public class Solution
{
    public int NumberOfSteps(int num)
    {
        var attemptCount = 0;
        var reducingNum = num;

        while (reducingNum > 0)
        {
            if (reducingNum % 2 == 0)
            {
                reducingNum /= 2;
            }
            else
            {
                reducingNum--;
            }

            attemptCount++;
        }


        return attemptCount;
    }
}