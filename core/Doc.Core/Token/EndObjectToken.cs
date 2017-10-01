namespace Doc.Core
{
    /// <summary>
    /// Токен окончания объекта
    /// </summary>
    public class EndObjectToken : BaseToken
    {
        /// <summary>
        /// Экземпляр
        /// </summary>
        public static EndObjectToken Instance = new EndObjectToken();

        /// <summary>
        /// Ctor
        /// </summary>
        private EndObjectToken() { }

        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.EndObject;
    }
}
