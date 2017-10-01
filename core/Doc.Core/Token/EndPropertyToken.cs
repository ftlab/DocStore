namespace Doc.Core
{
    /// <summary>
    /// Токен окончания свойства
    /// </summary>
    public class EndPropertyToken : BaseToken
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.EndProperty;

        /// <summary>
        /// Имя свойства
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отображение
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"<{Name}";
        }
    }
}
