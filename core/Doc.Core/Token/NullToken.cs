namespace Doc.Core
{
    /// <summary>
    /// Токен Null ссылки
    /// </summary>
    public class NullToken : BaseToken
    {
        /// <summary>
        /// Экземпляр
        /// </summary>
        public static NullToken Instance = new NullToken();

        /// <summary>
        /// Ctor
        /// </summary>
        private NullToken() { }

        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.Null;

        /// <summary>
        /// Отображение
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{NULL}";
        }
    }
}
