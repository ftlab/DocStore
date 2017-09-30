namespace Doc.Core
{
    public class Token : IToken
    {
        public TokenType Type { get; set; }

        public string Path { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            return $"{Type}, {Path}: {Value}";
        }
    }
}
