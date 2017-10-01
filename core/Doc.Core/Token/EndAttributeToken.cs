namespace Doc.Core
{
    public class EndAttributeToken : BaseToken
    {
        public override TokenType Type => TokenType.EndAttribute;

        public string Name { get; set; }

        public override string ToString()
        {
            return $"@<{Name}";
        }
    }
}
