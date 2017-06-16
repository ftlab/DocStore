using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    /// <summary>
    /// Механизм блокирования
    /// </summary>
    /// <typeparam name="TObject">Тип объекта</typeparam>
    /// <typeparam name="TSource">Тип инициатора блокировки</typeparam>
    public interface ILocker<TObject, TSource>
        where TSource : class
    {
        /// <summary>
        /// Транзакция
        /// </summary>
        ITransaction Transaction { get; }

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        void SetLock(
            TObject obj
            , LockType lockType
            , TSource source = null);

        /// <summary>
        /// Усиление блокировки
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        void GainLock(
            TObject obj
            , LockType lockType
            , TSource source = null);

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        void ClearLock(
            TObject obj);
    }
}
