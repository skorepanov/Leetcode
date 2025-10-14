// 428. Serialize and Deserialize N-ary Tree
using System.Text.Json;

public class Codec_428
{
    // Encodes a tree to a single string.
    public string serialize(Node root)
    {
        if (root is null)
        {
            return null;
        }

        var serializableRoot = ToSerializableNode(root);

        var options = new JsonSerializerOptions
        {
            MaxDepth = 10000
        };

        var serializedRoot = JsonSerializer.Serialize(serializableRoot, options);
        return serializedRoot;
    }

    private SerializableNode ToSerializableNode(Node node)
    {
        if (node is null)
        {
            return null;
        }

        var serializableNode = new SerializableNode();
        serializableNode.Value = node.val;

        if (node.children is not null)
        {
            serializableNode.Children = node.children
                .Select(n => ToSerializableNode(n))
                .ToList();
        }

        return serializableNode;
    }

    // Decodes your encoded data to tree.
    public Node deserialize(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            return null;
        }

        var options = new JsonSerializerOptions
        {
            MaxDepth = 10000
        };

        var serializableRoot = JsonSerializer.Deserialize<SerializableNode>(data, options);

        return FromSerializableNode(serializableRoot);
    }

    private Node FromSerializableNode(SerializableNode serializableNode)
    {
        if (serializableNode is null)
        {
            return null;
        }

        var node = new Node(serializableNode.Value);

        if (serializableNode.Children is not null)
        {
            node.children = serializableNode.Children
                .Select(n => FromSerializableNode(n))
                .ToList();
        }

        return node;
    }

    private class SerializableNode
    {
        public int Value { get; set; }
        public List<SerializableNode> Children { get; set; }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}