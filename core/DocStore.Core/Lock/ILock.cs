using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.Lock
{
    /// <summary>
    /// Механизм получения блокировки
    /// </summary>
    public interface ILock : IDisposable
    {
        /// <summary>
        /// Получить блокировку
        /// </summary>
        /// <param name="resource">ресурс</param>
        /// <param name="mode">режим</param>
        /// <param name="owner">владелец</param>
        /// <param name="timeout">таймаут</param>
        /// <returns></returns>
        LockResult GetLock(
            string resource
            , LockMode mode
            , string owner = null
            , TimeSpan? timeout = null);
    }
}
