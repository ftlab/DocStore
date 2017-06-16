using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    /// <summary>
    /// Режим блокирования
    /// </summary>
    public enum LockType : byte
    {
        /// <summary>
        /// Совмещаемая блокировка
        /// </summary>
        Shared = 0,

        /// <summary>
        /// Блокировка обновления
        /// </summary>
        Update = 1,

        /// <summary>
        /// Монопольная блокировка
        /// </summary>
        Exclusive = 2,
    }
}
