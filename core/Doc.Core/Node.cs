namespace Doc.Core
{
    public class Node : INode
    {
        public NodeType Type { get; set; }

        public string Path { get; set; }

        public string Value { get; set; }
    }
}
