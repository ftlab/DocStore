namespace Doc.Core
{
    public class StartAttributeToken : BaseToken
    {
        public override TokenType Type => TokenType.StartAttribute;

        public string Name { get; set; }

        public override string ToString()
        {
            return $"@>{Name}";
        }
    }
}
