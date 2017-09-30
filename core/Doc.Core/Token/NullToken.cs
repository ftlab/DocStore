namespace Doc.Core
{
    public class NullToken : IToken
    {
        public static readonly NullToken Value = new NullToken();

        public TokenType Type => TokenType.Null;

        public override string ToString()
        {
            return "{NULL}";
        }
    }
}
