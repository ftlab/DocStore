namespace Doc.Core
{
    /// <summary>
    /// Токен начала объекта
    /// </summary>
    public class StartObjectToken : BaseToken
    {
        /// <summary>
        /// Экземпляр
        /// </summary>
        public static readonly StartObjectToken Instance = new StartObjectToken();

        /// <summary>
        /// Ctor
        /// </summary>
        private StartObjectToken() { }

        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.StartObject;
    }
}
