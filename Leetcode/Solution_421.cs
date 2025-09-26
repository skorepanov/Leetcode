// 421. Maximum XOR of Two Numbers in an Array
public class Solution_421
{
    public int FindMaximumXOR(int[] nums)
    {
        var maxNum = nums.Max();
        var length = Convert.ToString(maxNum, toBase: 2).Length;

        var maxXor = 0;
        var root = new TrieNode();

        foreach (var num in nums)
        {
            var node = root;
            var xorNode = root;
            var currXor = 0;

            for (var i = length - 1; i >= 0; i--)
            {
                var bit = (num >> i) & 1;
                var toggledBit = bit ^ 1;

                if (node.Children[bit] is null)
                {
                    var newNode = new TrieNode();
                    node.Children[bit] = newNode;
                }

                node = node.Children[bit];

                if (xorNode.Children[toggledBit] != null)
                {
                    currXor |= 1 << i;
                    xorNode = xorNode.Children[toggledBit];
                }
                else
                {
                    xorNode = xorNode.Children[bit];
                }
            }

            maxXor = Math.Max(maxXor, currXor);
        }

        return maxXor;
    }

    private class TrieNode
    {
        public readonly TrieNode[] Children = new TrieNode[2];
    }
}