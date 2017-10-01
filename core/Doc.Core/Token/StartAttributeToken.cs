namespace Doc.Core
{
    /// <summary>
    /// Токен начала атрибута
    /// </summary>
    public class StartAttributeToken : BaseToken
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.StartAttribute;

        /// <summary>
        /// Имя атрибута
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отображение
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"@>{Name}";
        }
    }
}
