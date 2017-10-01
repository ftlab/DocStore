using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Токен строки
    /// </summary>
    public class StringToken : BaseToken
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.String;

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Отображение
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
