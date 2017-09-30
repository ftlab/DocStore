namespace Doc.Core
{
    public class EndPropertyToken : IToken
    {
        public TokenType Type => TokenType.EndProperty;

        public string Name { get; set; }

        public override string ToString()
        {
            return $"<{Name}";
        }
    }
}
