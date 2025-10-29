// 136. Single Number
#region 1 вариант - С помощью HashSet
public class Solution_136_1
{
    public int SingleNumber(int[] nums)
    {
        var hashset = new HashSet<int>();

        foreach (var num in nums)
        {
            if (hashset.Contains(num))
            {
                hashset.Remove(num);
            }
            else
            {
                hashset.Add(num);
            }
        }

        return hashset.First();
    }
}
#endregion

#region 2 вариант - С помощью XOR
public class Solution_136_2
{
    /*
    a ⊕ 0 = a
    a ⊕ a = 0
    a ⊕ b ⊕ a = (a ⊕ a) ⊕ b = 0 ⊕ b = b
    */

    public int SingleNumber(int[] nums)
    {
        var a = 0;

        foreach (var num in nums)
        {
            a ^= num;
        }

        return a;
    }
}
#endregion
