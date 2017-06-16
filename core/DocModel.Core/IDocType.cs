using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Core
{
    /// <summary>
    /// Тип документа
    /// </summary>
    public interface IDocType
    {
        /// <summary>
        /// Идентификатор типа
        /// </summary>
        ushort TypeId { get; }

        /// <summary>
        /// Наименование типа документа
        /// </summary>
        string Name { get; }
    }
}
