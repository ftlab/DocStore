using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.Lock
{
    /// <summary>
    /// Результат размещения блокировки
    /// </summary>
    public enum LockResult
    {
        /// <summary>
        /// Получено успешно
        /// </summary>
        Granted = 0,

        /// <summary>
        /// Получено успешно после ожидания
        /// </summary>
        GrantedAfterWait = 1,

        /// <summary>
        /// Таймаут
        /// </summary>
        Timeouted = -1,

        /// <summary>
        /// Отмена запроса
        /// </summary>
        Canceled = -2,

        /// <summary>
        /// Взаимная блокировка
        /// </summary>
        Deadlock = -3,

        /// <summary>
        /// Неожидаемый результат
        /// </summary>
        NotExpected = -999,
    }
}
