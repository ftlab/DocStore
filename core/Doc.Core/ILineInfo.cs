namespace Doc.Core
{

    /// <summary>
    /// Поддержка информации о строке
    /// </summary>
    public interface ILineInfo
    {
        /// <summary>
        /// Номер строки
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// Позиция в строке
        /// </summary>
        int LinePosition { get; }

        /// <summary>
        /// Поддерживает информацию о строке
        /// </summary>
        /// <returns></returns>
        bool HasLineInfo();
    }
}
