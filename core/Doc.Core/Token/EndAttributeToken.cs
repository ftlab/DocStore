namespace Doc.Core
{
    /// <summary>
    /// Токен окончания атрибута
    /// </summary>
    public class EndAttributeToken : BaseToken
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.EndAttribute;

        /// <summary>
        /// Имя атрибута
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отображаемое имя
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"@<{Name}";
        }
    }
}
