using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.Lock
{
    /// <summary>
    /// Режим блокирования
    /// </summary>
    public enum LockMode
    {
        /// <summary>
        /// Совмещаемое намерение блокировки
        /// </summary>
        IntentShared = 0,
        /// <summary>
        /// Совмещаемая блокировка
        /// </summary>
        Shared = 1,
        /// <summary>
        /// Блокировка обновления
        /// </summary>
        Update = 2,
        /// <summary>
        /// Эксклюзивное намерение блокировки
        /// </summary>
        IntentExclusive = 3,
        /// <summary>
        /// Эксклюзивная блокировка
        /// </summary>
        Exclusive = 4
    }
}
