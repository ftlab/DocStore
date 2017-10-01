namespace Doc.Core
{
    public class EndObjectToken : BaseToken
    {
        public static EndObjectToken Instance = new EndObjectToken();

        private EndObjectToken() { }

        public override TokenType Type => TokenType.EndObject;
    }
}
