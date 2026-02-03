// 860. Lemonade Change
public class Solution_860
{
    public bool LemonadeChange(int[] bills)
    {
        var coin5Count = 0;
        var coin10Count = 0;

        foreach (var bill in bills)
        {
            switch (bill)
            {
                case 5:
                    coin5Count++;
                    break;
                case 10:
                    if (coin5Count == 0)
                    {
                        return false;
                    }

                    coin5Count--;
                    coin10Count++;
                    break;
                case 20:
                    // 10 + 5
                    if (coin10Count > 0 && coin5Count > 0)
                    {
                        coin5Count--;
                        coin10Count--;
                        break;
                    }

                    // 5 + 5 + 5
                    if (coin5Count >= 3)
                    {
                        coin5Count -= 3;
                        break;
                    }

                    return false;
            }
        }

        return true;
    }
}