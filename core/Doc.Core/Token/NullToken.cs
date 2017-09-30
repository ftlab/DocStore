namespace Doc.Core
{
    public class NullToken : BaseToken
    {
        public static NullToken Instance = new NullToken();

        private NullToken() { }

        public override TokenType Type => TokenType.Null;

        public override string ToString()
        {
            return "{NULL}";
        }
    }
}
