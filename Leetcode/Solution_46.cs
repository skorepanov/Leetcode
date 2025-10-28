// 46. Permutations
public class Solution_46
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var currentPermutations = new List<int>();
        var allPermutations = new List<IList<int>>();

        FindPermutations(nums, ref currentPermutations, allPermutations);

        return allPermutations;
    }

    private void FindPermutations(
        int[] nums,
        ref List<int> currentPermutations,
        List<IList<int>> allPermutations)
    {
        if (currentPermutations.Count == nums.Length)
        {
            allPermutations.Add(currentPermutations);
            currentPermutations = currentPermutations.ToList();
            return;
        }

        foreach (var num in nums)
        {
            if (currentPermutations.Contains(num))
            {
                continue;
            }

            currentPermutations.Add(num);

            FindPermutations(nums, ref currentPermutations, allPermutations);

            currentPermutations.Remove(num);
        }
    }
}