using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Токен начала свойства
    /// </summary>
    public class StartPropertyToken : BaseToken
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public override TokenType Type => TokenType.StartProperty;

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
            return $">{Name}";
        }
    }
}
