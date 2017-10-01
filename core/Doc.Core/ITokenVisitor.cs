using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Посетитель токенов
    /// </summary>
    public interface ITokenVisitor
    {
        /// <summary>
        /// Посетить
        /// </summary>
        /// <param name="reader">считыватель</param>
        void Visit(ITokenReader reader);
    }
}
