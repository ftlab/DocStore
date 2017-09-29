using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Документ
    /// </summary>
    public interface IDoc
    {
        /// <summary>
        /// Обработка документа
        /// </summary>
        /// <typeparam name="T">тип возвращаемого значение</typeparam>
        /// <param name="func">делегат обработки</param>
        /// <returns>возврщаемое значение</returns>
        T Proc<T>(Func<Stream, T> func);

        /// <summary>
        /// Обработка документа
        /// </summary>
        /// <param name="action">делегат обработки</param>
        void Proc(Action<Stream> action);
    }
}
