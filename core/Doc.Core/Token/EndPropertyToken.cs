namespace Doc.Core
{
    public class EndPropertyToken : BaseToken
    {
        public override TokenType Type => TokenType.EndProperty;

        public string Name { get; set; }

        public override string ToString()
        {
            return $"<{Name}";
        }
    }
}
