namespace Doc.Core
{
    public class StartObjectToken : BaseToken
    {
        public static readonly StartObjectToken Instance = new StartObjectToken();

        private StartObjectToken() { }

        public override TokenType Type => TokenType.StartObject;
    }
}
