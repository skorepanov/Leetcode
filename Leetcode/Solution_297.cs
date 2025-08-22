// 297. Serialize and Deserialize Binary Tree
using System.Text.Json;

public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root is null)
        {
            return null;
        }

        var serializableRoot = ToSerializable(root);

        var options = new JsonSerializerOptions
        {
            MaxDepth = 10000
        };

        return JsonSerializer.Serialize(serializableRoot, options);
    }

    private SerializableTreeNode ToSerializable(TreeNode node)
    {
        if (node is null)
        {
            return null;
        }

        var serializableNode = new SerializableTreeNode
        {
            Value = node.val,
            Left = ToSerializable(node.left),
            Right = ToSerializable(node.right)
        };

        return serializableNode;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return null;
        }

        var options = new JsonSerializerOptions
        {
            MaxDepth = 10000
        };

        var serializableRoot = JsonSerializer
            .Deserialize<SerializableTreeNode>(data, options);

        return FromSerializable(serializableRoot);
    }

    private TreeNode FromSerializable(SerializableTreeNode serializableNode)
    {
        if (serializableNode is null)
        {
            return null;
        }

        var node = new TreeNode(serializableNode.Value)
        {
            left = FromSerializable(serializableNode.Left),
            right = FromSerializable(serializableNode.Right)
        };

        return node;
    }

    private class SerializableTreeNode
    {
        public int Value { get; set; }
        public SerializableTreeNode Left { get; set; }
        public SerializableTreeNode Right { get; set; }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }
}
