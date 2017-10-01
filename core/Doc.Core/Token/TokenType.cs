namespace Doc.Core
{
    /// <summary>
    /// Тип токена
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// Начало свойства
        /// </summary>
        StartProperty,

        /// <summary>
        /// Окончание свойства
        /// </summary>
        EndProperty,

        /// <summary>
        /// Начало атрибута
        /// </summary>
        StartAttribute,

        /// <summary>
        /// Окончание атрибута
        /// </summary>
        EndAttribute,

        /// <summary>
        /// Начало объекта
        /// </summary>
        StartObject,

        /// <summary>
        /// Окончание объекта
        /// </summary>
        EndObject,

        /// <summary>
        /// Начало массива
        /// </summary>
        StartArray,

        /// <summary>
        /// Окончание массива
        /// </summary>
        EndArray,

        /// <summary>
        /// Строка
        /// </summary>
        String,

        /// <summary>
        /// Null ссылка
        /// </summary>
        Null,
    }
}