using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Тип узла документа
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// Атрибут
        /// </summary>
        Attribute = 0,

        /// <summary>
        /// Свойство
        /// </summary>
        Property = 1,

        Value = 1
    }
}
