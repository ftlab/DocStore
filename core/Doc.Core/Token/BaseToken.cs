using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Базовый токен
    /// </summary>
    public abstract class BaseToken : IToken
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public abstract TokenType Type { get; }

        /// <summary>
        /// Отображение
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Type}";
        }
    }
}
