using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Core
{
    /// <summary>
    /// Тип документа
    /// </summary>
    public interface IDocType<out TType>
    {
        /// <summary>
        /// Идентификатор типа
        /// </summary>
        TType TypeId { get; }

        /// <summary>
        /// Наименование типа документа
        /// </summary>
        string Name { get; }
    }
}
