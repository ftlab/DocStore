using System;

namespace Doc.Core
{
    /// <summary>
    /// Допустимые типы данных
    /// </summary>
    [Flags]
    public enum SchemaType
    {
        /// <summary>
        /// Не специфицировано
        /// </summary>
        None = 0,

        /// <summary>
        /// Строка
        /// </summary>
        String = 1,

        /// <summary>
        /// Натуральное число
        /// </summary>
        Number = 2,

        /// <summary>
        /// Целое число
        /// </summary>
        Integer = 4,

        /// <summary>
        /// Битовый тип
        /// </summary>
        Boolean = 8,

        /// <summary>
        /// Ссылка
        /// </summary>
        Link = 16,

        /// <summary>
        /// Массив
        /// </summary>
        Array = 32,

        /// <summary>
        /// Объект
        /// </summary>
        Object = 64,

        /// <summary>
        /// Значение допускающее ноль
        /// </summary>
        Null = 2^31,
    }
}
